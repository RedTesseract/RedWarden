<?php
session_start();
include './baza.class.php';
$baza = new Baza();
$greske = "";
$datum = date('Y-m-d H:i:s');

if($_SERVER['REQUEST_METHOD']=="POST"){
    $korime=$_POST['korime'];
    $lozinka=$_POST['lozinka'];
    $newTime = new DateTime();
    $currentTime = $newTime->format('Y-m-d H:i:s');
    $upit="SELECT * FROM korisnik WHERE korisnicko_ime='$korime'";
    $rezultat=$baza->selectDB($upit);
	$nesto=$rezultat->fetch_array();
	//$blokiraj = $nesto['login_block'];
    
    if(empty($korime) || empty($lozinka)){
        $greske.="Korisničko ime i lozinka moraju biti uneseni ";
        } 
		
	// if($nesto['korisnik_status']!=1){
        // $greske.="Korisnički račun nije aktiviran";
        // } 
    
    if ($rezultat->num_rows!=0 && $nesto['lozinka']==$lozinka){
		// $upitOdblok = "update korisnici set login_block = '0' where id = '{$nesto['id']}'";
		// $rezultatOdblok = $baza->selectDB($upitOdblok);
        $_SESSION['id']=$nesto['idkorisnik'];
		$_SESSION['korisnik']=$nesto['korisnicko_ime'];
        $_SESSION['email']=$nesto['korisnik_email'];
		$_SESSION['tip']=$nesto['tip_korisnika_idtip_korisnika'];
        $_SESSION['prijava']=true;
		
		// $kor_id = $_SESSION['id'];
		// $datum = date('Y-m-d H:i:s');
		// $activity = "korisnik ".$kor_id." prijavljen";
		// $radnja = "prijava";
		// $log="insert into login_history(activity_log, korisnici_id, radnja, vrijeme)"."values ('$activity','$kor_id','$radnja','$datum')";
		// $baza->updateDB($log);
         
        if($_POST['pamti']=='pamti'){
            setcookie("korime", $nesto['korisnicko_ime'], time()+(3600*24*365));
        }
        else{
            setcookie("korime","",time()-1);
        }
        header("Location: index.php");
    } else{
        $greske.="Neuspješna prijava ";
		
		// $kor_id = $_SESSION['id'];
		// $datum = date('Y-m-d H:i:s');
		// $activity = "korisnik ".$kor_id." neuspješna prijava";
		// $radnja = "nprijava";
		// $log="insert into login_history(activity_log, korisnici_id, radnja, vrijeme)"."values ('$activity','$kor_id','$radnja','$datum')";
		// $baza->updateDB($log);
		
		// $blokiraj = $blokiraj + 1;
		// $greske.=$blokiraj;
		// $upitBlok = "update korisnici set login_block = '{$blokiraj}' where korisnicko_ime = '{$nesto['korisnicko_ime']}'";
		// $rezultatBlok = $baza->selectDB($upitBlok);
		// if($blokiraj>2){
			// $greska.="3 neuspješne prijave. Korisnički račun blokiran";
		// }
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
		
			<td><a href="lozinka.php">Zaboravili lozinku?</a></td>
		
            <form id="prijava" name="prijava" method="POST" action="<?php echo $_SERVER['PHP_SELF']; ?>" enctype="multipart/form-data">
				
				<br><label for="korime">Korisničko ime: </label>
                    <input type="text" name="korime" id="korime" autofocus placeholder="Unesite svoje ime" size="20" maxlength="30" value="<?php echo $_COOKIE['korime']; ?>"/><br>
					
				<br><label for="lozinka">Lozinka: </label>
                    <input type="password"  name="lozinka" id="lozinka" placeholder="Lozinka" onblur="provjeriLozinku();"/><br>
					
				<br><label for="pamti">Zapamti me: </label>
                    <input type="checkbox"  name="pamti" id="pamti" value="pamti"/><br>
				
				<br><label for="prijava"></label>
				<input type="submit" id="prijava" value="Prijava" class="gumb"/>
				
			</form>
        </section>

		</div>
    </body>
</html>