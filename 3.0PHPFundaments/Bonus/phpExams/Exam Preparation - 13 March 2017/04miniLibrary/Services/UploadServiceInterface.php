<?php

interface UploadServiceInterface
{
	public function upload($fileInfo, $destination) : string;
}