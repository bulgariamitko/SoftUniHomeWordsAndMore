<?php

namespace Core\Http\Components\Request;

Class Request implements RequestInterface
{
	protected $serverInfo;

	public function __construct($serverInfo)
	{
		$this->serverInfo = $serverInfo;
	}



	public function getReferer()
	{
		return $this->serverInfo['HTTP_REFERER'];
	}
}