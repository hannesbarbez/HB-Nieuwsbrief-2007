<?php

class BizObject 
{
    // constructor
    function __construct()
	{
        global $dbhost, $dbuser, $dbpw, $dbname;
        $this->link = @mysql_connect($dbhost, $dbuser, $dbpw) or die("Kan momenteel niet verbinden met de server. Probeer het later a.u.b. opnieuw. ");
        @mysql_select_db($dbname, $this->link) or die("De databasenaam is momenteel niet beschikbaar. Probeer het later a.u.b. opnieuw.");
    }  
	
	function reedsGeregistreerd($mail)
	{
        $query 	= "SELECT * FROM inschrijvingen WHERE mail='".addPostSlashes($mail)."'";
        $result = @mysql_query($query) or die("Er is een fout opgetreden bij het registreren. Probeer het later opnieuw.");
        return mysql_num_rows($result) > 0;
    }
	
	function addInschrijving($inschrijving)
	{
		$mail 	= $inschrijving->mail;
		$query 	= "INSERT INTO inschrijvingen(mail) VALUES('".addPostSlashes($mail)."')";
        @mysql_query($query) or die("Kon niet inschrijven. Probeer het later a.u.b. opnieuw.");
	}    
	
	function removeInschrijving($inschrijving)
	{
        $mail 	= $inschrijving->mail;
		$query 	= "DELETE FROM inschrijvingen WHERE inschrijvingen.mail='".addPostSlashes($mail)."'";
        @mysql_query($query) or die("Kon niet uitschrijven. Probeer het later a.u.b. opnieuw.");
    } 
}

?>