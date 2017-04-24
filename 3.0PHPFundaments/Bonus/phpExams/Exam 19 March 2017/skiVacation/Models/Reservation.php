<?php

Class Reservation
{
	protected $id;
	protected $roomType;
	protected $children;
	protected $adults;
	protected $rooms;

	public function __construct($id, $roomType, $children, $adults, $rooms)
	{
		$this->id = $id;
		$this->roomType = $roomType;
		$this->children = $children;
		$this->adults = $adults;
		$this->rooms = $rooms;
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
     * Gets the value of roomType.
     *
     * @return mixed
     */
    public function getRoomType()
    {
        return $this->roomType;
    }

    /**
     * Sets the value of roomType.
     *
     * @param mixed $roomType the room type
     *
     * @return self
     */
    protected function setRoomType($roomType)
    {
        $this->roomType = $roomType;

        return $this;
    }

    /**
     * Gets the value of children.
     *
     * @return mixed
     */
    public function getChildren()
    {
        return $this->children;
    }

    /**
     * Sets the value of children.
     *
     * @param mixed $children the children
     *
     * @return self
     */
    protected function setChildren($children)
    {
        $this->children = $children;

        return $this;
    }

    /**
     * Gets the value of adults.
     *
     * @return mixed
     */
    public function getAdults()
    {
        return $this->adults;
    }

    /**
     * Sets the value of adults.
     *
     * @param mixed $adults the adults
     *
     * @return self
     */
    protected function setAdults($adults)
    {
        $this->adults = $adults;

        return $this;
    }

    /**
     * Gets the value of rooms.
     *
     * @return mixed
     */
    public function getRooms()
    {
        return $this->rooms;
    }

    /**
     * Sets the value of rooms.
     *
     * @param mixed $rooms the rooms
     *
     * @return self
     */
    protected function setRooms($rooms)
    {
        $this->rooms = $rooms;

        return $this;
    }
}