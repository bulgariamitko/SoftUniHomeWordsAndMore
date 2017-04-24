<?php

namespace Models;

Class UserRegisterBidingModel
{
	protected $username;
	protected $password;
	protected $confirmPass;

    /**
     * Gets the value of username.
     *
     * @return mixed
     */
    public function getUsername()
    {
        return $this->username;
    }

    /**
     * Sets the value of username.
     *
     * @param mixed $username the username
     *
     * @return self
     */
    public function setUsername($username)
    {
        if (strlen($username) < 3) {
            throw new \Core\Exceptions\FormValidationException("Username too short!");
        }
        $this->username = $username;

        return $this;
    }

    /**
     * Gets the value of password.
     *
     * @return mixed
     */
    public function getPassword()
    {
        return $this->password;
    }

    /**
     * Sets the value of password.
     *
     * @param mixed $password the password
     *
     * @return self
     */
    protected function setPassword($password)
    {
        $this->password = $password;

        return $this;
    }

    /**
     * Gets the value of confirmPass.
     *
     * @return mixed
     */
    public function getConfirmPassword()
    {
        return $this->confirmPass;
    }

    /**
     * Sets the value of confirmPass.
     *
     * @param mixed $confirmPass the confirm password
     *
     * @return self
     */
    protected function setConfirmPassword($confirmPass)
    {
        $this->confirmPass = $confirmPass;

        return $this;
    }
}