<div id="sidebar_container">
        <div class="sidebar">
          <div class="sidebar_item">
            {if isset($smarty.session.id)}
				Korisnik:
					{$smarty.session.korisnik}
					<br>
					<a href="odjava.php" target="">Odjava</a>
			{/if}
			<ul>
			<li><a href="prijava.php">Prijava</a></li>
            <li><a href="registracija.php">Registracija korisnika</a></li>
			{if isset($smarty.session.id)}
				<li><a href="profil.php">Moj profil</a></li>
			{/if}
			</ul>
          </div>
		  
		{if ($smarty.session.tip == 3)}
		  <div class="sidebar_item">
			Admin panel
			<ul>
                <li><a href="upravljaj_sajmom.php">Upravljanje sajmovima</a></li>
				<li><a href="popis_korisnika.php">Popis korisnika</a></li>
				<li><a href="statistike.php">Statistike sustava</a></li>
			</ul>
          </div>
		  {/if}
		  
		  {if ($smarty.session.tip == 3) or ($smarty.session.tip == 2)}
		  <div class="sidebar_item">
			Moderator panel
			<ul>
                <li><a href="pregled_zahtjeva.php">Pregled zahtjeva</a></li>
				<li><a href="moderiraj_sajam.php">Moderiraj sajam</a></li>
				<li><a href="posalji_mail.php">Posalji e-mail</a></li>
			</ul>
          </div>
		  {/if}
		  
        </div>
		</div>