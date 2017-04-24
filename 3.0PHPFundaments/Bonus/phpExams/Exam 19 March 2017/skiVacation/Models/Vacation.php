<?php

Class Vacation
{
	protected $id;
	protected $checkIn;
	protected $checkOut;
	protected $liftPass;
	protected $skIntructor;

	public function __construct($id, $checkIn, $checkOut, $liftPass, $skIntructor)
	{
		$this->id = $id;
		$this->checkIn = $checkIn;
		$this->checkOut = $checkOut;
		$this->liftPass = $liftPass;
		$this->skIntructor = $skIntructor;
	}

    /**
     * Gets the value of id.
     *
     * @return mixed
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * Sets the value of id.
     *
     * @param mixed $id the id
     *
     * @return self
     */
    protected function setId($id)
    {
        $this->id = $id;

        return $this;
    }

    /**
     * Gets the value of checkIn.
     *
     * @return mixed
     */
    public function getCheckIn()
    {
        return $this->checkIn;
    }

    /**
     * Sets the value of checkIn.
     *
     * @param mixed $checkIn the check in
     *
     * @return self
     */
    protected function setCheckIn($checkIn)
    {
        $this->checkIn = $checkIn;

        return $this;
    }

    /**
     * Gets the value of checkOut.
     *
     * @return mixed
     */
    public function getCheckOut()
    {
        return $this->checkOut;
    }

    /**
     * Sets the value of checkOut.
     *
     * @param mixed $checkOut the check out
     *
     * @return self
     */
    protected function setCheckOut($checkOut)
    {
        $this->checkOut = $checkOut;

        return $this;
    }

    /**
     * Gets the value of liftPass.
     *
     * @return mixed
     */
    public function getLiftPass()
    {
        return $this->liftPass;
    }

    /**
     * Sets the value of liftPass.
     *
     * @param mixed $liftPass the lift pass
     *
     * @return self
     */
    protected function setLiftPass($liftPass)
    {
        $this->liftPass = $liftPass;

        return $this;
    }

    /**
     * Gets the value of skIntructor.
     *
     * @return mixed
     */
    public function getSkIntructor()
    {
        return $this->skIntructor;
    }

    /**
     * Sets the value of skIntructor.
     *
     * @param mixed $skIntructor the sk intructor
     *
     * @return self
     */
    protected function setSkIntructor($skIntructor)
    {
        $this->skIntructor = $skIntructor;

        return $this;
    }
}