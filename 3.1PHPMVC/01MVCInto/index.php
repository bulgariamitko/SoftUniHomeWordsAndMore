<?php
session_start();

require 'vendor/autoload.php';

spl_autoload_register(function($class) {
    $class = str_replace('\\', '/', $class);
    require_once $class . '.php';
});

$selfFolder = str_replace("index.php", "", $_SERVER['PHP_SELF']);
$uri = str_replace($selfFolder, "", $_SERVER['REQUEST_URI']);
$uriParts = explode('/', $_SERVER['REQUEST_URI']);
array_shift($uriParts);
$controllerName = array_shift($uriParts);
$methodName = array_shift($uriParts);
$controllerFullName = 'Controllers\\' . ucfirst($controllerName) . 'Controller';

$mvcContext = new \Core\MVCContext($controllerName, $controllerFullName, $methodName, $uri, $uriParts, $_SERVER['REQUEST_URI']);

$request = new \Core\Http\Components\Request\Request($_SERVER);
$session = new \Core\Http\Components\Session\Session($_SESSION, function() {
	session_destroy();
});
$app = new \Core\Application($mvcContext, $request, $session);
$app->addDependency(\Core\ViewInterface::class, \Core\View::class);
$app->addResolveDependency(\Core\MVCContextInterface::class, $mvcContext);
$app->addResolveDependency(\Core\Http\Components\Request\RequestInterface::class, $request);
$app->addResolveDependency(\Core\Http\Components\Session\SessionInterface::class, $session);
$app->start();