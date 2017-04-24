<?php

namespace AppBundle\Entity;

/**
 * Cart
 */
class Cart
{
    /**
     * @var int
     */
    private $id;

    /**
     * @var int
     */
    private $productid;

    /**
     * @var int
     */
    private $userid;

    /**
     * @var \DateTime
     */
    private $date;

    /**
     * @var int
     */
    private $qtty;

    /**
     * @var int
     */
    private $promotionid;


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
     * Set productid
     *
     * @param integer $productid
     *
     * @return Cart
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
     * Set userid
     *
     * @param integer $userid
     *
     * @return Cart
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
     * Set date
     *
     * @param \DateTime $date
     *
     * @return Cart
     */
    public function setDate($date)
    {
        $this->date = $date;

        return $this;
    }

    /**
     * Get date
     *
     * @return \DateTime
     */
    public function getDate()
    {
        return $this->date;
    }

    /**
     * Set qtty
     *
     * @param integer $qtty
     *
     * @return Cart
     */
    public function setQtty($qtty)
    {
        $this->qtty = $qtty;

        return $this;
    }

    /**
     * Get qtty
     *
     * @return int
     */
    public function getQtty()
    {
        return $this->qtty;
    }

    /**
     * Set promotionid
     *
     * @param integer $promotionid
     *
     * @return Cart
     */
    public function setPromotionid($promotionid)
    {
        $this->promotionid = $promotionid;

        return $this;
    }

    /**
     * Get promotionid
     *
     * @return int
     */
    public function getPromotionid()
    {
        return $this->promotionid;
    }
}

