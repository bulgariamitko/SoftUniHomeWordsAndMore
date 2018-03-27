<?php

namespace AppBundle\Entity;

/**
 * Promotion
 */
class Promotion
{
    /**
     * @var int
     */
    private $id;

    /**
     * @var string
     */
    private $name;

    /**
     * @var int
     */
    private $discount;

    /**
     * @var int
     */
    private $productid;

    /**
     * @var int
     */
    private $categoryid;

    /**
     * @var int
     */
    private $userid;


    /**
     * Get id
     *
     * @return int
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * Set discount
     *
     * @param integer $discount
     *
     * @return Promotion
     */
    public function setDiscount($discount)
    {
        $this->discount = $discount;

        return $this;
    }

    /**
     * Get discount
     *
     * @return int
     */
    public function getDiscount()
    {
        return $this->discount;
    }

    /**
     * Set productid
     *
     * @param integer $productid
     *
     * @return Promotion
     */
    public function setProductid($productid)
    {
        $this->productid = $productid;

        return $this;
    }

    /**
     * Get productid
     *
     * @return int
     */
    public function getProductid()
    {
        return $this->productid;
    }

    /**
     * Set categoryid
     *
     * @param integer $categoryid
     *
     * @return Promotion
     */
    public function setCategoryid($categoryid)
    {
        $this->categoryid = $categoryid;

        return $this;
    }

    /**
     * Get categoryid
     *
     * @return int
     */
    public function getCategoryid()
    {
        return $this->categoryid;
    }

    /**
     * Set userid
     *
     * @param integer $userid
     *
     * @return Promotion
     */
    public function setUserid($userid)
    {
        $this->userid = $userid;

        return $this;
    }

    /**
     * Get userid
     *
     * @return int
     */
    public function getUserid()
    {
        return $this->userid;
    }

    /**
     * @return string
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * @param string $name
     */
    public function setName($name)
    {
        $this->name = $name;
    }
}
