<?php

$demo = "Other";

if ($demo != "Airforces" && $demo != "Other") {
	throw new Exception("too bad", 1);
}

echo "string";