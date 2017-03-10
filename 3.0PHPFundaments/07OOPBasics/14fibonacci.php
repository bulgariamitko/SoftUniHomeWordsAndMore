<?php

Class Fibonacci
{
	protected $fibonacciSequence = [0, 1];

	public function __construct(int $endNum)
	{
		$this->generateFibonacciSequence($endNum);
	}

	public function getFibonacciRange(int $startNum, int $endNum)
	{
		return array_slice($this->fibonacciSequence, $startNum, $endNum);
	}

	public function generateFibonacciSequence(int $endNum)
	{
		for ($i=2; $i < $endNum; $i++) { 
			$a = $this->fibonacciSequence[$i - 2];
			$b = $this->fibonacciSequence[$i - 1];
			$this->fibonacciSequence[] = $a + $b;
		}
	}
}

$startNum = trim(fgets(STDIN));
$endNum = trim(fgets(STDIN));

$fibonacci = new Fibonacci($endNum);

echo implode(", ", $fibonacci->getFibonacciRange($startNum, $endNum));