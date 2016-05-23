<?php
session_start();
include_once './baza.class.php';
$baza = new Baza();
$greske = "";
$datum_reg = date('Y-m-d H:i:s');

if($_SERVER['REQUEST_METHOD']=="POST"){
    $ime = $_POST['ime'];
    $prezime = $_POST['prezime'];
    $email = $_POST['email'];
    $korime = $_POST['korime'];
    $lozinka = $_POST['lozinka'];
	$datumr = $_POST['datumr'];
	$spol = $_POST['spol'];
	
	if(empty($ime) || empty($prezime) || empty($email) || empty($korime) || empty($lozinka) || empty($datumr)){
		$greske .="Nisu svi podaci uneseni u registracijsku formu";
	}
    
    if(!filter_var($email, FILTER_VALIDATE_EMAIL)){
        $greske .="Netočno strukturirana e-mail adresa";
    }
	
	 $upit = "select * from korisnik where korisnik_email ='".$email."'";
     $rezultat_email = $baza->selectDB($upit);
        
     if($rezultat_email->num_rows != 0){
		$greske .= "Email je već zauzet";
	 }
	 
	 $upit = "select * from korisnik where korisnicko_ime ='".$korime."'";
     $rezultat_korime = $baza->selectDB($upit);
        
     if($rezultat_korime->num_rows != 0){
		$greske .= "Korisničko ime je već zauzeto";
	 }
	 
	 $provjera_slova_ime = ucfirst($ime);
	 $provjera_slova_prezime = ucfirst($prezime);
	 if(($ime != $provjera_slova_ime) || ($prezime != $provjera_slova_prezime)){
		 $greske .= "Ime i prezime moraju zapocinjati velikim slovom";
	 }
    
    if(empty($greske)){
            $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
			$charactersLength = strlen($characters);
			$random = '';
			for ($i = 0; $i < 10; $i++) {
				$random .= $characters[rand(0, $charactersLength - 1)];
			}
			
			$upit = "insert into korisnik(ime, prezime, korisnik_email, korisnicko_ime, lozinka, datum_rod, spol, datum_reg, akt_kod, tip_korisnika_idtip_korisnika)"."values ('$ime','$prezime','$email','$korime','$lozinka','$datumr','$spol','$datum_reg','$random','1')";
            
            if($baza->updateDB($upit)){
                // $primatelj = $email;
                // $naslov = "Aktivacija korisnickog racuna";
                // $poruka = "Poštovani/a, molimo vas da aktivirate svoj korisnički račun "."http://redtesseract.sexy/redwarden/aktivacija.php?kljuc=$random";
                // mail($primatelj, $naslov, $poruka);
				//header("Location:popis_korisnika.php");
				
				//$kor_id = $_SESSION['id'];
				// $datum = date('Y-m-d H:i:s');
				// $activity = "korisnik ".$ime." ".$prezime." registriran";
				// $radnja = "registracija";
				// $log="insert into login_history(activity_log, radnja, vrijeme)"."values ('$activity','$radnja','$datum')";
				// $baza->updateDB($log);
				
				echo "
				<script type=\"text/javascript\">
					window.location = 'http://redtesseract/redwarden/prijava.php';
				</script>";
            } else{
                $greske .= "Greška prilikom rada s bazom podataka";
            }
        }
    }
include_once '_header.php';
include_once '_navigacija.php';
?>
		
        <section id="sadrzaj">
		<article id='greske'>
		<?php
		echo $greske;
		?>
        </article> 
            <form name="registracija" id="registracija" method="POST" action="<?php echo $_SERVER['PHP_SELF']; ?>" enctype="multipart/form-data">
                  
                  <br><label for="ime">Ime: </label>
                    <input type="text" name="ime" id="ime" placeholder="Unesite svoje ime" size="20" maxlength="30" /><br>

                  <br><label for="prezime">Prezime: </label>
                    <input type="text"  name="prezime" id="prezime" placeholder="Unesite svoje prezime" size="20" maxlength="50" /><br>
				  
				  <br><label for="email">E-mail: </label>
                    <input type="email"  name="email" id="email" placeholder="Unesite svoj email" /><br>
                    
                  <br><label for="korime">Korisničko ime: </label>
                    <input type="text"  name="korime" id="korime" placeholder="Korisničko ime" size="20" pattern=".{5,}" maxlength="30"/><br>
                    
                  <br><label for="lozinka">Lozinka: </label>
                    <input type="text"  name="lozinka" id="lozinka" placeholder="Lozinka" /><br>
				  
				  <br><label for="datumr">Datum rođenja: </label>
                    <input type="date"  name="datumr" id="datumr" placeholder="YYYY-MM-DD"/><br>
				
				  <br><label for="spol" id="lspol">Spol: </label>
					<br><input class="kutija" type="radio" name="spol" id="spol1" value="0"/>M
					<br><input class="kutija" type="radio" name="spol" id="spol2" value="1"/>Ž
					<br><input class="kutija" type="radio" name="spol" id="spol3" value="2"/>?
                  <br>
                    
                  <br><input type="submit" value="Registriraj" class="gumb"/>
                  <input type="reset" value="Reset" class="gumb"/><br>
            </form>
        </section>

		</div>
    </body>
</html>
