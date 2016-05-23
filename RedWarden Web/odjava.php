<?php
session_start();
include 'baza.class.php';
$baza = new baza();

// $kor_id = $_SESSION['id'];
// $datum = date('Y-m-d H:i:s');
// $activity = "korisnik ".$kor_id." odlogiran";
// $radnja = "odjava";
// $log="insert into login_history(activity_log, korisnici_id, radnja, vrijeme)"."values ('$activity','$kor_id','$radnja','$datum')";
// $baza->updateDB($log);

session_destroy();
header("Location:prijava.php");
?>
