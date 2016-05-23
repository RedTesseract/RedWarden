<?php
// session_start();
include './baza.class.php';
$baza = new Baza();
$datum = date('Y-m-d H:i:s');

if (isset($_POST['tablica'])) {
    $tablica = $_POST['tablica'];
} else {
    $tablica = null;
}
  
if (isset($_POST['id'])) {
    $atribut = $_POST['id'];
} else {
    $atribut = null;
}

if (isset($_POST['unos'])) {
    $unos = $_POST['unos'];
} else {
    $unos = null;
}

if (isset($_POST['uvjet'])) {
    $uvjet = $_POST['uvjet'];
} else {
    $uvjet = null;
}

if (isset($_POST['vrijednost'])) {
    $vrijednost = $_POST['vrijednost'];
} else {
    $vrijednost = null;
}

if (($tablica != null) && ($atribut != null) && ($unos != null)){
	if(($uvjet != null) && ($vrijednost != null)){
		 $upit="UPDATE $tablica set $atribut = '$unos' WHERE $uvjet ='$vrijednost'";
		 if($baza->updateDB($upit)) echo "Uspjeh";
		else {
			echo "Greska";
		}
	}
	else {
		$upit="INSERT INTO $tablica($atribut)"."values('$unos')";
		 if($baza->updateDB($upit)) echo "Uspjeh";
		else {
			echo "Greska";
		}
	}
}
else {
	echo "Greska";
}

?>