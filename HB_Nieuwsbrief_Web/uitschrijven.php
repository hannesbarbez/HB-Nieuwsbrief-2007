<?php
require "_lib/_classes/template.class.php";
require "_lib/_includes/functions.inc.php";
require "classes/BizObject.class.php";
require "classes/Inschrijving.class.php";
require "includes/config.inc.php";

$bizObject	= new BizObject();
$mailRAW 	= $_REQUEST['mail'];
$mail		= htmlentities($mailRAW);

if (isset($_REQUEST['postback']))
{
	if (isset($_REQUEST['btnNotOk']))
	{
		header("Location: bedankt.php?status=g");
		exit(0);
	}
	
	$inschrijving = new Inschrijving($mail);
	$bizObject->removeInschrijving($inschrijving);
	header("Location: bedankt.php?status=u");
	exit(0);
}
if (!($bizObject->reedsGeregistreerd($mail)) | $mail == "") 
{
	header("Location: bedankt.php?status=e");
	exit(0);
}

$tpl = new Template();

$topic = "Uitschrijven.";
$title = " - ".$topic;
$content = "U bent reeds ingeschreven onder ". $mail. ". Bent u zeker dat u wilt uitschrijven?";
$headercontent = $topic;

$tpl->set_file("inschrijven_tp",  "templates/uitschrijven.tpl");
$tpl->set_file("header_tp", "templates/header.tpl");
$tpl->set_file("footer_tp", "templates/footer.tpl");

$tpl->set_var("TITLE", $title);
$tpl->set_var("HEADERCONTENT", $headercontent);
$tpl->set_var("CONTENT", $content);
$tpl->set_var("ACTION", $_SERVER['PHP_SELF']);

$tpl->set_var("MSGMAIL", $msgMail);
$tpl->set_var("MSGFOUT", $msgFout);
$tpl->set_var("MAIL", $mail);

$tpl->parse("HEADER",   "header_tp");
$tpl->parse("FOOTER",   "footer_tp");
$tpl->parse("htmlcode", "inschrijven_tp");

$tpl->p("htmlcode");
?>