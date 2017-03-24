<?php

namespace Core;

Class View implements ViewInterface
{
	const VIEWS_FOLDER = 'Views';
    const VIEWS_EXTENSION = '.php';
    
    protected $mvcContext;

    public function __construct(MVCContextInterface $mvcContext)
    {
        $this->mvcContext = $mvcContext;
    }


    public function render($viewName = null, $model = null)
    {
        if ($viewName == null || is_object($viewName)) {
            $model = $viewName;
            $viewName = $this->mvcContext->getControllerName()
                . DIRECTORY_SEPARATOR
                . $this->mvcContext->getAction();
        }

        include self::VIEWS_FOLDER
            .
            DIRECTORY_SEPARATOR
            .
            $viewName
            .
            self::VIEWS_EXTENSION;
    }

    public function url($controllerName, $actionName, ...$args)
    {
        $controller = $this->mvcContext->getControllerName();
        $action = $this->mvcContext->getAction();
        $fulluri = $this->mvcContext->getFullUri();
        $url = $actionName . '/';
        $url .= implode('/', $args);

        return $url;
    }
}