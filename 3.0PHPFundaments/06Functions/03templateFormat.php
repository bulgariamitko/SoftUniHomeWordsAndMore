<?php

// $input = 'Who was the forty-second president of the U.S.A.?, William Jefferson Clinton';

// $input = 'Dry ice is a frozen form of which gas?, Carbon Dioxide, What is the brightest star in the night sky?, Sirius';

$input = trim(fgets(STDIN));

$sentences = explode(',', $input);

echo "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
echo "<quiz>\n";
for ($i=0; $i < count($sentences); $i += 2) { 
	echo "  <question>\n    {$sentences[$i]}\n  </question>\n";
    echo "  <answer>\n    {$sentences[$i+1]}\n  </answer>\n";
}
echo "</quiz>";
