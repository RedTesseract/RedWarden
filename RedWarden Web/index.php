<?php
session_start();
include './baza.class.php';
$baza = new Baza();
$datum = date('Y-m-d H:i:s');

$korisnik = $_SESSION['korisnik'];
$korisnik_id = $_SESSION['id'];

$upit = "select * from enkripcije where korisnik_idkorisnik = '{$korisnik_id}'";
$rezultat = $baza->selectDB($upit);

$ispis = "<table><thead><tr><th>Naziv</th><th>Veličina</th><th>Datum</th><th>Tip</th><th>Dohvati podatke</th></tr></thead><tbody>";

	while($red = $rezultat->fetch_array()){
		$ispis .="<tr>";
		$tren = $red['idenkripcije'];
		$ispis .= "<td>".$red['naziv_datoteke']."</td>";
		$ispis .= "<td>".$red['velicina']."</td>";
		$ispis .= "<td>".$red['datum']."</td>";
		$ispis .= "<td>".$red['tip']."</td>";
		$ispis .= "<td><a href='dohvati.php?kljuc={$tren}'".$tren.">Dohvati</a></td>";
		$ispis .= "</tr>" ;
	}

$ispis .="</tbody></table>";

$upit2 = "select * from pripadnici_projekta where korisnik_idkorisnik = '{$korisnik_id}'";
$rezultat2 = $baza->selectDB($upit2);

$ispis2 = "<table><thead><tr><th>Naziv</th><th>Detalji</th></tr></thead><tbody>";

	while($red2 = $rezultat2->fetch_array()){
		$grupa = $red2['grupni_projekti_idgrupni_projekti'];
		$upit3 = "select * from grupni_projekti where idgrupni_projekti = '{$grupa}'";
		$rezultat3 = $baza->selectDB($upit3);
		while($red3 = $rezultat3->fetch_array()){
			$ispis2 .="<tr>";
			$ispis2 .= "<td>".$red3['grupni_projektiNaziv']."</td>";
			$ispis2 .= "<td><a href='detalji_projekta.php?kljuc={$tren}'".$tren.">Detalji</a></td>";
			$ispis2 .= "</tr>" ;
		}
	}

$ispis2 .="</tbody></table>";

include_once '_header.php';
include_once '_navigacija.php';
?>
		<section id="sadrzaj2">
			Korisnik: 
			<?php
			if(isset($_SESSION['korisnik'])){
			echo "".$_SESSION['korisnik']."";
			echo "<br><p><a href='odjava.php' target=''>Odjava</a></p>";
			}
			?>
		</section>
        <section id="sadrzaj">
			
			<h1>Vaše enkripcije</h1>
			<?php
				echo $ispis;
			?>
			
			<h1>Grupni projekti</h1>
			<a href="dodaj_projekt.php" target="">Dodaj novi grupni projekt</a>
			<?php
				echo $ispis2;
			?>
			
        </section>
        
		</div>
    </body>
</html>