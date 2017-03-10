<?php
function sum($num1, $num2) {
	return $num1 + $num2;
}

function multiply($num1, $num2) {
	return $num1 * $num2;
}

function divide($num1, $num2) {
	if ($num1 == 0 || $num2 == 0) {
		throw new Exception("Division by zero.");
		
	}
	return $num1 / $num2;
}

function subtract($num1, $num2) {
	return $num1 - $num2;
}

function factorial($num1) {
	$result = 1;
    for ($i = 1; $i <= $num1; $i++) {
        $result *= $i;
    }
    return $result;
}

function root($num1) {
	if ($num1 < 0) {
		throw new Exception("Can't take the root of a negative number");
	}
	return sqrt($num1);
}

function power($num1, $num2) {
	return pow($num1, $num2);
}

function absolute($num1) {
	return abs($num1);
}

function pythagorean($num1, $num2) {
	return sqrt($num1 * $num1 + $num2 * $num2);
}

function triangleArea($num1, $num2, $num3) {
	$result = ($num1 + $num2 + $num3) / 2;
    $res = sqrt($result * ($result - $num1) * ($result - $num2) * ($result - $num3));
    if (is_nan($res)) {
        throw new Exception("Can't take the root of a negative number");
    }
    return $res;
}

function quadratic($num1, $num2, $num3) {
	if ($num1 == 0) {
        throw new Exception("Division by zero");
    }
    $discriminant = ($num2 * $num2) - (4 * $num1 * $num3);
    if ($discriminant < 0) {
        return 0;
    }
    $x1 = (-$num2 + sqrt($discriminant)) / (2 * $num1);
    $x2 = (-$num2 - sqrt($discriminant)) / (2 * $num1);
    if ($discriminant == 0) {
        return $x1;
    }
    return $x1 + $x2;
}

$results = [];
while (true) {
    $command = trim(fgets(STDIN));
    if ($command === "finally") {
        break;
    }
    $args = [];
    $reflection = new ReflectionFunction($command);
    $argCount = $reflection->getNumberOfParameters();
    for ($i = 0; $i < $argCount; $i++) {
        $args[] = intval(trim(fgets(STDIN)));
    }
    try {
        $results[] = $command(...$args);
    } catch (Exception $ex) {
        echo "Caught exception: {$ex->getMessage()}\n";
    }
}
while (true) {
    $command = trim(fgets(STDIN));
    $reflection = new ReflectionFunction($command);
    $argCount = $reflection->getNumberOfParameters();
    $args = [];
    try {
        if ($argCount == 1) {
            for ($i = 0; $i < count($results); $i++) {
                $results[$i] = $command($results[$i]);
            }
            break;
        }
        while (count($results) >= $argCount) {
            $args = array_splice($results, 0, $argCount);
            $results[] = $command(...$args);
        }
    } catch (Exception $ex) {
        echo "Caught exception: {$ex->getMessage()}\n";
        array_splice($results, 0, 0, $args);
        continue;
    }
    break;
}

echo implode(", ", $results);