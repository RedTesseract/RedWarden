<?php
// session_start();
include './baza.class.php';
$baza = new Baza();
$datum = date('Y-m-d H:i:s');

if (isset($_POST['UserName'])) {
    $UserName = $_POST['UserName'];
} else {
    $UserName = null;
}
  
if (isset($_POST['Password'])) {
    $Password = $_POST['Password'];
} else {
    $Password = null;
}

if (($UserName != null) && ($Password != null)){
	$upit="SELECT * FROM korisnik WHERE korisnicko_ime='$UserName'";
    $rezultat=$baza->selectDB($upit);
    $nesto=$rezultat->fetch_array();
	
	if ($rezultat->num_rows!=0 && $nesto['lozinka']==$Password){
		echo "Valja";
	}
	else {
		echo "Greska";
	}
}
else {
	echo "Greska";
}

?>