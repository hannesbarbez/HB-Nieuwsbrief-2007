<?php
// MISC FUNCTIONS
function addPostSlashes($string) {
    if (get_magic_quotes_gpc()==1) return $string;
    else return addslashes($string);
}

function stripPostSlashes($string) {
    if (get_magic_quotes_gpc()==1) return stripslashes($string);
    else return $string;
}

function showError($info="") {
    $errtpl = new Template("templates");
    $errtpl->set_file("error_tp", "error.tpl");
    $errtpl->set_var("INFO", $info);
    $errtpl->pparse($htmlcode, "error_tp");
    die();
}

// STRING FUNCTIONS
function endsWith($haystack, $needle) {
    return (substr($haystack, strlen($haystack) - strlen($needle)) == $needle);
}

// FILE FUNCTIONS
function isJpg($file) {
    $file = strtolower($file);
    if (endsWith($file, ".jpg")) return true;
    if (endsWith($file, ".jpeg")) return true;
    return false;
}

function getArrFiles($parentDir, $rex="") {
    $files = array();
    $dp = opendir($parentDir) or die("error reading ".$parentDir);
    while ($file = readdir($dp)) {
        if ($file == '.')  continue;
        if ($file == '..') continue;
        if (is_dir($file)) continue;
        if ($rex!="" && !preg_match($rex, $file)) continue;
        $files[] = $file;
    }
    closedir($dp);
    return $files;
}

function getArrDirs($parentDir) {
    $dirs = array();
    $dp = opendir($parentDir) or die("error reading ".$parentDir);
    while ($file = readdir($dp)) {
        if ($file == '.')  continue;
        if ($file == '..') continue;
        if (!is_dir($parentDir.$file)) continue;
        $dirs[] = $file;
    }
    closedir($dp);
    return $dirs;
}

// IMAGE FUNCTIONS
// watermark should be png-8
function addWatermark($photoPath, $waterPath, $pct=50) {
    $watermark = imagecreatefrompng($waterPath);
    $photo     = imagecreatefromjpeg($photoPath);
    $dest_x    = imagesx($photo) - imagesx($watermark);
    $dest_y    = imagesy($photo) - imagesy($watermark);
    imagecopymerge($photo, $watermark, $dest_x, $dest_y, 0, 0, imagesx($watermark), imagesy($watermark), $pct);
    imagejpeg($photo, $photoPath);
    imagedestroy($photo);
    imagedestroy($watermark);
}

function boxScalePhoto($photoPath, $maxW, $maxH=-1) {
    $photo    = imagecreatefromjpeg($photoPath);
    $photoW   = imagesx($photo);
    $photoH   = imagesy($photo);
    if ($photoW/$maxW>$photoH/$maxH) {
        $newW = $maxW;
        $newH = $photoH*$maxW/$photoW;
    } else {
        $newH = $maxH;
        $newW = $photoW*$maxH/$photoH;
    }
    $newPhoto = imagecreatetruecolor($newW, $newH);
    imagecopyresampled($newPhoto, $photo, 0, 0, 0, 0, $newW, $newH, $photoW, $photoH);
    imagejpeg($newPhoto, $photoPath);
    imagedestroy($photo);
    imagedestroy($newPhoto);
}
?>