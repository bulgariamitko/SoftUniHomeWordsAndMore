<?php
if (session_status() == PHP_SESSION_NONE) {
    session_start();
}
require_once 'MysqlPDO.php';

try {
    $db = new MysqlPDO('mysql:host=localhost; dbname=mini-library; charset=utf8;', 'root', '1718');
} catch(PDOException $e) {
    echo $e->getMessage();
}