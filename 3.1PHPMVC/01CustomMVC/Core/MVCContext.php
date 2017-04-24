<?php

namespace Core;

Class MVCContext implements MVCContextInterface
{
	protected $controllerName;
	protected $controllerFullName;
	protected $action;
	protected $uri;
    protected $fullUri;
    protected $args;

	public function __construct($controllerName, $controllerFullName, $action, $uri, $args, $fullUri)
	{
		$this->controllerName = $controllerName;
		$this->controllerFullName = $controllerFullName;
		$this->action = $action;
		$this->uri = $uri;
        $this->args = $args;
        $this->fullUri = $fullUri;
	}

    public function getControllerName()
    {
        return $this->controllerName;
    }

    public function getControllerFullName()
    {
        return $this->controllerFullName;
    }

    public function getAction()
    {
        return $this->action;
    }

    public function getURI()
    {
        return $this->uri;
    }

    /**
     * Sets the value of controllerName.
     *
     * @param mixed $controllerName the controller name
     *
     * @return self
     */
    protected function setControllerName($controllerName)
    {
        $this->controllerName = $controllerName;

        return $this;
    }

    /**
     * Sets the value of controllerFullName.
     *
     * @param mixed $controllerFullName the controller full name
     *
     * @return self
     */
    protected function setControllerFullName($controllerFullName)
    {
        $this->controllerFullName = $controllerFullName;

        return $this;
    }

    /**
     * Sets the value of action.
     *
     * @param mixed $action the action
     *
     * @return self
     */
    protected function setAction($action)
    {
        $this->action = $action;

        return $this;
    }

    /**
     * Gets the value of args.
     *
     * @return mixed
     */
    public function getArgs()
    {
        return $this->args;
    }

    /**
     * Sets the value of args.
     *
     * @param mixed $args the args
     *
     * @return self
     */
    protected function setArgs($args)
    {
        $this->args = $args;

        return $this;
    }

    /**
     * Gets the value of fullUri.
     *
     * @return mixed
     */
    public function getFullUri()
    {
        return $this->fullUri;
    }
}