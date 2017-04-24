<?php

Class UploadService
{
	public function upload($fileInfo, $destination) : string
	{
  		if (!strstr($fileInfo['type'], "image") === false) {
  			throw new Exception("Invalid image format");
  		}

		$fileName = $destination . DIRECTORY_SEPARATOR . uniqid() . '_' . $fileInfo['Name'];

		$result = move_uploaded_file($fileInfo['tmp_name'], $fileName);

		$fileName = dirname($_SERVER['PHP_SELF']) . DIRECTORY_SEPARATOR . $fileName;

		if ($result == false) {
			throw new Exception("Upload failed");
		}

		return $fileName;
	}
}