<?php
session_start();
include './baza.class.php';
$baza = new Baza();
$datum = date('Y-m-d H:i:s');
$sat = date('H');
(int)$sat = intval($sat) + 1;
$dan = date('d');

if(!isset($_SESSION['korisnik'])) {
        header("Location: prijava.php");
    }

$korisnik = $_SESSION['korisnik'];
$korisnik_id = $_SESSION['id'];
    
$upit = "select * from enkripcije where korisnik_idkorisnik = '{$korisnik_id}'";
$rezultat = $baza->selectDB($upit);

while($red = $rezultat->fetch_array()){
		$idenc = $red['idenkripcije'];
		$lozinka = $red['lozinka'];
		$prim_param_a = $red['prim_param_a'];
		$prim_param_b = $red['prim_param_b'];
	}
	
$arr = str_split($lozinka);
$lozinka_enc = "";

foreach ($arr as &$znak){
	$temp = ord($znak);
	(int)$temp2 = intval($temp) + intval($sat) + intval($dan) + intval($prim_param_a) + intval($prim_param_b);
	
	if(intval($temp)>47 && intval($temp)<58) {
		while($temp2>57) $temp2 -= 10;
	}
	if(intval($temp)>64 && intval($temp)<91) {
		while($temp2>90) $temp2 -= 26;
	}
	if(intval($temp)>96 && intval($temp)<123) {
		while($temp2>122) $temp2 -= 26;
	}
	
	$lozinka_enc .= chr($temp2);
}

include_once '_header.php';
include_once '_navigacija.php';
?>
		<section id="sadrzaj2">
			<?php
			echo "Korisnik: ".$_SESSION['korisnik']."";
			?>
			<a href="odjava.php" target="">Odjava</a>
		</section>
        <section id="sadrzaj">
			
			<h1>Generirana šifra</h1>
			<?php
				echo $lozinka_enc;
			?>
			
        </section>
        
		</div>
    </body>
</html>