<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Sum Two Numbers</title>
</head>
<body>
<?php 
	$num = $_POST['num'] ?? 0;

	if (!empty($_POST['submit'])) {
		echo "<h1>Result:</h1>";
		$splittedNum = str_split($num);
		$arrayOfNums = [];
		$finalOutput = [];

		if (count($splittedNum) < 3) {
			echo "no";
		} else {
			// echo "<pre>";
			// print_r($splittedNum);
			// echo "</pre>";
			for ($i=0; $i < count($splittedNum); $i++) { 

				if (!in_array($splittedNum[$i], $arrayOfNums)) {
					array_push($arrayOfNums, $splittedNum[$i]);
				}

				// echo "<pre>";
				// print_r($arrayOfNums);
				// echo "</pre>";

				$max = 9;

			}

				for ($y1=0; $y1 <= $max; $y1++) { 
					for ($y2=0; $y2 <= $max; $y2++) { 
						for ($y3=0; $y3 <= $max; $y3++) { 
							if ($y1 != $y2 && $y1 != $y3 && $y2 != $y3) {
								$value = (int)($y1 . $y2 . $y3);
								if ($value > 99 && $value <= $num) {
									array_push($finalOutput, $y1 . $y2 . $y3);
								}
							}
						}
					}
				}
			echo implode($finalOutput, ', ');
		}


	}
 ?>

<h1>Fill form first:</h1>
 <form method="post">
 	<input type="num" name="num" placeholder="Any number" required> <br>
 	<input type="submit" name="submit">
 </form>
</body>
</html>