<?php

namespace Core\Http\Components\Session;

Class Session implements SesstionInterface
{
	protected $session;
	protected $destroyableDelegate;

	public function __construct(&$session, callable $destroyableDelegate)
	{
		$this->session = &$session;
		$this->destroyableDelegate = $destroyableDelegate;
	}

	public function get($key)
	{
		return $this->sessions[$key];
	}

	public function set($key, $value)
	{
		$this->sessions[$key] = $value;
	}

	public function getMessage($key)
	{
		return $this->sessions['messages'][$key];
	}

	public function getMessages()
	{
		return $this->sessions['messages'];
	}

	public function addMessage($key, $message)
	{
		$this->sessions['messages'][$key] = $message;
	}

	public function delete($key)
	{
		unset($this->sessions[$key]);
	}

	public function destroy()
	{
		$destroy = $this->destroyableDelegate();
		$destroy();
	}
}