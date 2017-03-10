<?php

$categories = explode(', ', $_GET['categories']);
$tags = explode(', ', $_GET['tags']);
$months = explode(', ', $_GET['months']);

echo "<h2>Categories</h2>";
echo "<ul>";
foreach ($categories as $v) {
	echo "<li>" . $v . "</li>";
}
echo "</ul>";

echo "<h2>Tags</h2>";
echo "<ul>";
foreach ($tags as $v) {
	echo "<li>" . $v . "</li>";
}
echo "</ul>";

echo "<h2>Months</h2>";
echo "<ul>";
foreach ($months as $v) {
	echo "<li>" . $v . "</li>";
}
echo "</ul>";