<?php
require_once 'MysqlPDO.php';

try {
    $connection = new MysqlPDO('mysql:host=localhost; dbname=Ski; charset=utf8;', 'root', '1718');
} catch(PDOException $e) {
    echo $e->getMessage();
}