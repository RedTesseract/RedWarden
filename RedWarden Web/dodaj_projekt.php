<?php
session_start();
include './baza.class.php';
$baza = new Baza();
$greske = "";
$datum = date('Y-m-d H:i:s');

$korisnik = $_SESSION['korisnik'];
$korisnik_id = $_SESSION['id'];

if(!isset($_SESSION['korisnik'])) {
        header("Location: prijava.php");
    }

if($_SERVER['REQUEST_METHOD']=="POST"){
    $naziv=$_POST['naziv'];
    
    if(empty($naziv)){
        $greske.="Upišite naziv projekta";
        } 
    
    $upit="INSERT INTO grupni_projekti(grupni_projektiNaziv, dat_kreiranja)"."values('$naziv','$datum')";
    if($baza->updateDB($upit)){
		$upitGP = "SELECT idgrupni_projekti FROM grupni_projekti WHERE dat_kreiranja = '{$datum}'";
		$rezultat = $baza->selectDB($upitGP);
		
		while($red = $rezultat->fetch_array()) {
			$group_id = $red['idgrupni_projekti'];
		}
		
		$upit2="INSERT INTO pripadnici_projekta(grupni_projekti_idgrupni_projekti, korisnik_idkorisnik, nadglednik)"."values('$group_id','$korisnik_id','1')";
		if($baza->updateDB($upit2)){
			header("Location: index.php");
		}
		else{
			$greske.="Greška tijekom rada s bazom";
		}
	}
	else{
		$greske.="Greška tijekom rada s bazom";
	}
}

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
			
			<article id='greske'>
		<?php
		echo $greske;
		?>
        </article>
		
            <form id="prijava" name="prijava" method="POST" action="<?php echo $_SERVER['PHP_SELF']; ?>" enctype="multipart/form-data">
				
				<br><label for="naziv">Naziv projekta: </label>
                    <input type="text" name="naziv" id="naziv" autofocus placeholder="Unesite naziv projekta" size="20" maxlength="30" /><br>
				
				<br><label for="prijava"></label>
				<input type="submit" id="prijava" value="Kreiraj" class="gumb"/>
				<br>
			</form>
			
        </section>
        
		</div>
    </body>
</html>