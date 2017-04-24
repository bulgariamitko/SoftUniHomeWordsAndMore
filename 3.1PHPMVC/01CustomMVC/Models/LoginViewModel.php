<?php

namespace Models;

Class LoginViewModel
{
	protected $allUsers;
	protected $activeUsers;

	public function __construct($allUsers, $activeUsers)
	{
		$this->allUsers = $allUsers;
		$this->activeUsers = $activeUsers;
	}

    /**
     * Gets the value of allUsers.
     *
     * @return mixed
     */
    public function getAllUsers()
    {
        return $this->allUsers;
    }

    /**
     * Sets the value of allUsers.
     *
     * @param mixed $allUsers the all users
     *
     * @return self
     */
    protected function setAllUsers($allUsers)
    {
        $this->allUsers = $allUsers;

        return $this;
    }

    /**
     * Gets the value of activeUsers.
     *
     * @return mixed
     */
    public function getActiveUsers()
    {
        return $this->activeUsers;
    }

    /**
     * Sets the value of activeUsers.
     *
     * @param mixed $activeUsers the active users
     *
     * @return self
     */
    protected function setActiveUsers($activeUsers)
    {
        $this->activeUsers = $activeUsers;

        return $this;
    }
}