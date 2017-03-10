<?php

Class Box
{
	protected $length;
	protected $width;
	protected $height;

	public function __construct(float $length, float $width, float $height)
	{
		$this->length = $length;
		$this->width = $width;
		$this->height = $height;
	}

    /**
     * Gets the value of length.
     *
     * @return mixed
     */
    public function getLength()
    {
        return $this->length;
    }

    /**
     * Sets the value of length.
     *
     * @param mixed $length the length
     *
     * @return self
     */
    protected function setLength($length)
    {
        $this->length = $length;

        return $this;
    }

    /**
     * Gets the value of width.
     *
     * @return mixed
     */
    public function getWidth()
    {
        return $this->width;
    }

    /**
     * Sets the value of width.
     *
     * @param mixed $width the width
     *
     * @return self
     */
    protected function setWidth($width)
    {
        $this->width = $width;

        return $this;
    }

    /**
     * Gets the value of height.
     *
     * @return mixed
     */
    public function getHeight()
    {
        return $this->height;
    }

    /**
     * Sets the value of height.
     *
     * @param mixed $height the height
     *
     * @return self
     */
    protected function setHeight($height)
    {
        $this->height = $height;

        return $this;
    }

    public function getSurfaceArea(): float
    {
        $output = 2 * $this->getLength() * $this->getWidth()
            + 2 * $this->getLength() * $this->getHeight()
            + 2 * $this->getWidth() * $this->getHeight();
        return $output;
    }

    public function getLateralSurfaceArea()
    {
    	$output = 2 * $this->getLength() * $this->getHeight() + 2 * $this->getWidth() * $this->getHeight();
    	return $output;
    }

    public function getVolume()
    {
    	$output = $this->getLength() * $this->getWidth() * $this->getHeight();
    	return $output;
    }

    public function __toString()
    {
    	$output = "Surface Area - " . number_format($this->getSurfaceArea(), 2, ".", "") . PHP_EOL;
    	$output .= "Lateral Surface Area - " . number_format($this->getLateralSurfaceArea(), 2, ".", "") . PHP_EOL;
		$output .= "Volume - " . number_format($this->getVolume(), 2, ".", "");
		return $output;
    }
}

$a = (float)trim(fgets(STDIN));
$b = (float)trim(fgets(STDIN));
$c = (float)trim(fgets(STDIN));

$box = new Box($a, $b, $c);
echo $box;