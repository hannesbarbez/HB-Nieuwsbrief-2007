<?php
require "_lib/_classes/template.class.php";
$tpl = new Template();

$topic 				= "Bedankt.";
$title 				= " - ".$topic;
$headercontent 		= $topic;
$ingeschreven 		= "U bent nu ingeschreven.";
$uitgeschreven 		= "U bent nu uitgeschreven.";
$geenWijzigingen 	= "Er werden geen wijzigingen doorgevoerd.";
$error				= "Er is een fout opgetreden. Gelieve terug te keren en opnieuw te proberen.";
$status 			= $_REQUEST['status'];
$content 			= "Bedankt. ";

switch ($status)
{
	case "i":
	$content .= $ingeschreven;
	break;
	case "u":
	$content .= $uitgeschreven;
	break;
	case "g":
	$content .= $geenWijzigingen;
	break;
	case "e":
	$content =  $error;
	break;
}

$tpl->set_file("inschrijven_tp",  "templates/index.tpl");
$tpl->set_file("header_tp", "templates/header.tpl");
$tpl->set_file("footer_tp", "templates/footer.tpl");

$tpl->set_var("TITLE", $title);
$tpl->set_var("HEADERCONTENT", $headercontent);
$tpl->set_var("CONTENT", $content);

$tpl->parse("HEADER",   "header_tp");
$tpl->parse("FOOTER",   "footer_tp");
$tpl->parse("htmlcode", "inschrijven_tp");

$tpl->p("htmlcode");
?>