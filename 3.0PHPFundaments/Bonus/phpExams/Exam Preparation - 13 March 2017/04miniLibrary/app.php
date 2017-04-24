<?php

session_start();

spl_autoload_register(function($class) {
	require_once $class . '.php';
});

try {
    $db = new \DB\MysqlPDO('mysql:host=localhost; dbname=mini-library; charset=utf8;', 'root', '1718');
} catch(PDOException $e) {
    echo $e->getMessage();
}

$app = new Core\Application();
$bookService = new BookService($db);