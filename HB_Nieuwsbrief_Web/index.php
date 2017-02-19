<?php
require "_lib/_classes/template.class.php";
require "_lib/_includes/functions.inc.php";
require "classes/BizObject.class.php";
require "classes/Inschrijving.class.php";
require "includes/config.inc.php";

$rexMail 		= "/^[-_a-z0-9\'+*$^&%=~!?{}]++(?:\.[-_a-z0-9\'+*$^&%=~!?{}]+)*+@(?:(?![-.])[-a-z0-9.]+(?<![-.])\.[a-z]{2,6}|\d{1,3}(?:\.\d{1,3}){3})(?::\d++)?$/iD";	
$msgFoutMail	= "Gebruik a.u.b. een geldig e-mailadres."; //"Vergewis u er a.u.b. van dat dit een geldig e-mailadres is (bv. naam@bedrijf.be).";
$content 		= "Geef uw e-mailadres op om in of uit te schrijven.";
$mail			= $_REQUEST['mail'];
$topic 			= "In- of uitschrijven.";
$title 			= " - ".$topic;
$headercontent 	= $topic;

$bizObject = new BizObject();
$tpl = new Template();
$allOk 	= true;

if (isset($_REQUEST['postback'])) 
{	
	if ($bizObject->reedsGeregistreerd($mail)) {
        header("Location: uitschrijven.php?mail=".$mail);
        exit(0);
    }

	if (!preg_match($rexMail, $mail)) 
	{
		$msgMail = $msgFoutMail;
		$allOk = false;
	}

    if ($allOk) 
	{
        $inschrijving = new Inschrijving($mail);
        $bizObject->addInschrijving($inschrijving);
        header("Location: bedankt.php?status=i");
        exit(0);
    } 
}

$tpl->set_file("inschrijven_tp",  "templates/inschrijven.tpl");
$tpl->set_file("header_tp", "templates/header.tpl");
$tpl->set_file("footer_tp", "templates/footer.tpl");

$tpl->set_var("TITLE", $title);
$tpl->set_var("HEADERCONTENT", $headercontent);
$tpl->set_var("CONTENT", $content);
$tpl->set_var("ACTION", $_SERVER['PHP_SELF']);

$tpl->set_var("MSGMAIL", $msgMail);
$tpl->set_var("MSGFOUT", $msgFout);
$tpl->set_var("MAIL", htmlentities($_REQUEST['mail']));

$tpl->parse("HEADER",   "header_tp");
$tpl->parse("FOOTER",   "footer_tp");
$tpl->parse("htmlcode", "inschrijven_tp");

$tpl->p("htmlcode");
?>