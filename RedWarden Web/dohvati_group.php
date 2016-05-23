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
		$upit = "SELECT $atribut FROM $tablica WHERE korisnik_idkorisnik = '$vrijednost' GROUP BY korisnik_idkorisnik";

		$rezultat=$baza->selectDB($upit);
		$ispis = "";
	
		if ($rezultat->num_rows!=0){
			while($nesto=$rezultat->fetch_array()){
				$ispis .= $nesto[$atribut]."";
				$ispis .= $nesto['grupni_projekti_idgrupni_projekti']." ";
			}
			
			$upit2 = "SELECT grupni_projekti_idgrupni_projekti FROM $tablica WHERE korisnik_idkorisnik = '$vrijednost'";
			$rezultat2=$baza->selectDB($upit2);
			
			while($nesto2=$rezultat2->fetch_array()){
				$ispis .= $nesto2['grupni_projekti_idgrupni_projekti']." ";
			}
			echo $ispis;
		}
		else {
			echo "Greska";
		}
	}
else {
	echo "Greska";
}

?>