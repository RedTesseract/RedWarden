<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

class Baza{
    
    const server = "localhost";
    const baza = "redwarden";
    const user = "redwarden";
    const password = "redwarden";
    
    private function spojiDB(){
        $mysqli = new mysqli(self::server, self::user, self::password, self::baza);
        $mysqli->set_charset("utf8");
        if($mysqli->connect_errno){
            echo "Neuspjesno spajanje s bazom: ".$mysqli->connect_errno.", ".$mysqli->connect_error;
        }
        return $mysqli;
    }
    
    function selectDB($upit){
        $veza = self::spojiDB();
        
        $rezultat = $veza->query($upit) or trigger_error("Greška kod upita: {$upit} - "."Greška: ".$veza->error ." ".E_USER_ERROR);
        
        if(!$rezultat){
            $rezultat = null;
        }
        $veza->close();
        return $rezultat;
    }
    
    function updateDB($upit, $skripta=""){
        $veza = self::spojiDB();
        
        if($rezultat = $veza->query($upit)){
            $veza->close();
            if($skripta!=""){
                header("Location: $skripta");
            }
            return $rezultat;
        }else{
            echo "Pogreška: ".$veza->error;
            $veza->close();
            return $rezultat;
        }
    }
    
	function zatvoriVezu($veza){
		$veza->close();
	}
	
}