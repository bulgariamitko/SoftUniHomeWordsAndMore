<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Awesome Calendar</title>
	<link href='http://fonts.googleapis.com/css?family=PT+Sans:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
	<link href='http://fonts.googleapis.com/css?family=PT+Sans+Narrow:400,700' rel='stylesheet' type='text/css'>
<style>
    body {
      line-height: 1;
      margin: 50px;
    }
    div {
      background: rgba(0, 0, 0, .1);
      border-radius: 5px;
      box-sizing: border-box;
      padding: 15px;
      width: 220px;
    }
    header {
      overflow: clear;
      position: relative;
    }
    h2 {
      font-family: 'PT Sans Narrow', sans-serif;
      font-size: 18px;
      font-weight: 700;
      margin: 0 0 10px;
      text-align: center;
    }
    button {
      position: absolute;
      top: -4px;
    }
    button:first-child {
      left: 0;
    }
    button:last-child {
      right: 0;
    }
    table {
      background: #fff;
      border-collapse: collapse;
      color: #222;
      font-family: 'PT Sans', sans-serif;
      font-size: 13px;
      width: 100%;
    }
    td {
      border: 1px solid #ccc;
      color: #444;
      line-height: 22px;
      text-align: center;
    }
    tr:first-child td {
      color: #222;
      font-weight: 700;
    }
    .selected {
      background: #f0951d;
      border: 0;
      box-shadow: 0 2px 6px rgba(0, 0, 0, .5) inset;
    }
  </style>
</head>
<body>
<?php
 function getDates($year) {
    $dates = array();

    for($i = 1; $i <= 365; $i++){
        $month = date('m', mktime(0,0,0,1,$i,$year));
        $wk = date('W', mktime(0,0,0,1,$i,$year));
        $wkDay = date('D', mktime(0,0,0,1,$i,$year));
        $day = date('d', mktime(0,0,0,1,$i,$year));

        $dates[$month][$wk][$day] = $wkDay;
    } 

    return $dates;   
}


$months = ['', 'Януари', 'Февруари', 'Март', 'Април', 'Май', 'Юни', 'Юли', 'Август', 'Септември', 'Октомври', 'Ноември', 'Декември'];
$weeks = ['Mon' => 'По', 'Tue' => 'Вт', 'Wed' => 'Ср', 'Thu' => 'Чт', 'Fri' => 'Пе', 'Sat' => 'Сб', 'Sun' => 'Не'];
$year = date('Y');

if (!empty($_POST)) {
	$time = strtotime($_POST['year']);
	$year = date('Y',$time);
}

?>
<h2 style="text-align: left;">Choose year:</h2>
<form method="post">
	<input type="month" name="year">
	<input type="submit" name="submit" value="Submit year">
</form>

<?php
echo "<h1>" . $year . "</h1>";

echo "<div>";
foreach (getDates($year) as $month => $date) {
echo "<table>";
	echo "<header>";
		echo "<h2>" . $months[(int)$month] . "</h2>";
	echo "</header>";
	echo "<tr>";
	    echo "<td>По</td>";
	    echo "<td>Вт</td>";
	    echo "<td>Ср</td>";
	    echo "<td>Чт</td>";
	    echo "<td>Пе</td>";
	    echo "<td>Сб</td>";
	    echo "<td>Не</td>";
	echo "</tr>";
	foreach ($date as $week => $date2) {
		// echo "<pre>";
		// print_r($week);
		// echo "</pre>";
		echo "<tr>";
		foreach ($date2 as $day => $date3) {
		    // echo "<td>" . $weeks[$date3] . "</td>";
		    if ($day == '01' && $weeks[$date3] != 'По') {
		    	echo "<td></td>";
			    if ($day == '01' && $weeks[$date3] != 'Вт') {
			    	echo "<td></td>";
				    if ($day == '01' && $weeks[$date3] != 'Ср') {
				    	echo "<td></td>";
					    if ($day == '01' && $weeks[$date3] != 'Чт') {
					    	echo "<td></td>";
						    if ($day == '01' && $weeks[$date3] != 'Пе') {
						    	echo "<td></td>";
						    	if ($day == '01' && $weeks[$date3] != 'Сб') {
							    	echo "<td></td>";
							    }
						    }
					    } 
				    } 
			    } 
		    } 
		    echo "<td>" . $day . "</td>";
		}
		echo "</tr>";
	}
echo "</table>";
}
echo "</div>";
?>


</body>
</html>