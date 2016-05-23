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

if (($tablica != null) && ($atribut != null)){
	if($tablica == "enkripcije"){
		$upit="SELECT $atribut FROM $tablica ORDER BY $atribut DESC LIMIT 1";
		 $rezultat=$baza->selectDB($upit);
		 $nesto=$rezultat->fetch_array();
	
		 if ($rezultat->num_rows!=0){
			$ispis = $nesto[$atribut];
			echo $ispis;
		 }
		else {
			$ispis = "0";
			echo $ispis;
		}
	}
	else {
	if(($uvjet != null) && ($vrijednost != null)){
		 $upit="SELECT $atribut FROM $tablica WHERE $uvjet ='$vrijednost'";
		 $rezultat=$baza->selectDB($upit);
		 $nesto=$rezultat->fetch_array();
	
		 if ($rezultat->num_rows!=0){
			$ispis = $nesto[$atribut];
			echo $ispis;
		 }
		else {
			echo "Greska";
		}
	}
	else {
		$upit="SELECT $atribut FROM $tablica";
		$rezultat=$baza->selectDB($upit);
		$ispis = "";
	
		if ($rezultat->num_rows!=0){
			while($nesto=$rezultat->fetch_array()){
				$ispis .= $nesto[$atribut]." ";
			}
			echo $ispis;
		}
		else {
			echo "Greska";
		}
	}
	}
}
else {
	echo "Greska";
}

?>