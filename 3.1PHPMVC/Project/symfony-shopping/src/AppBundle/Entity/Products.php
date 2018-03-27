<?php

namespace AppBundle\Entity;

use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\Validator\Constraints as Validation;

/**
 * Products
 *
 * @ORM\Table(name="products")
 * @ORM\Entity(repositoryClass="AppBundle\Repository\ProductsRepository")
 */
class Products
{
    /**
     * @var int
     *
     * @ORM\Column(name="id", type="integer")
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="AUTO")
     */
    private $id;

    /**
     * @var int
     *
     * @ORM\Column(name="category_id", type="integer")
     */
    private $categoryId;

    /**
     * @var string
     *
     * @ORM\Column(name="name", type="string", length=255)
     * @Validation\NotBlank()
     * @Validation\Length(max=15)
     * @Validation\Length(min=2)
     * @Validation\Type("string")
     */
    private $name;

    /**
     * @var string
     *
     * @ORM\Column(name="image", type="string", length=255)
     */
    private $image;

    /**
     * @var string
     *
     * @ORM\Column(name="description", type="string", length=500)
     * @Validation\NotBlank()
     * @Validation\Length(min=20)
     * @Validation\Type("string")
     */
    private $description;

    /**
     * @var string
     *
     * @ORM\Column(name="price", type="decimal", precision=10, scale=2)
     */
    private $price;

    /**
     * @var string
     *
     * @ORM\Column(name="promotionid", type="integer", length=10)
     */
    private $promotionid;

    /**
     * @var string
     *
     * @ORM\Column(name="qtty", type="integer", length=5)
     */
    private $qtty;

    /**
     * @var string
     *
     * @ORM\Column(name="visibility", type="boolean")
     */
    private $visibility;

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
     * Set categoryId
     *
     * @param integer $categoryId
     *
     * @return Products
     */
    public function setCategoryId($categoryId)
    {
        $this->categoryId = $categoryId;

        return $this;
    }

    /**
     * Get categoryId
     *
     * @return int
     */
    public function getCategoryId()
    {
        return $this->categoryId;
    }

    /**
     * Set name
     *
     * @param string $name
     *
     * @return Products
     */
    public function setName($name)
    {
        $this->name = $name;

        return $this;
    }

    /**
     * Get name
     *
     * @return string
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * Set image
     *
     * @param string $image
     *
     * @return Products
     */
    public function setImage($image)
    {
        $this->image = $image;

        return $this;
    }

    /**
     * Get image
     *
     * @return string
     */
    public function getImage()
    {
        return $this->image;
    }

    /**
     * Set description
     *
     * @param string $description
     *
     * @return Products
     */
    public function setDescription($description)
    {
        $this->description = $description;

        return $this;
    }

    /**
     * Get description
     *
     * @return string
     */
    public function getDescription()
    {
        return $this->description;
    }

    /**
     * @return string
     */
    public function getPrice()
    {
        return $this->price;
    }

    /**
     * @param string $price
     */
    public function setPrice($price)
    {
        $this->price = $price;
    }

    /**
     * @return string
     */
    public function getPromotionid()
    {
        return $this->promotionid;
    }

    /**
     * @param string $promotionid
     */
    public function setPromotionid($promotionid)
    {
        $this->promotionid = $promotionid;
    }

    /**
     * @return string
     */
    public function getQtty(): string
    {
        return $this->qtty;
    }

    /**
     * @param string $qtty
     */
    public function setQtty(string $qtty)
    {
        $this->qtty = $qtty;
    }

    /**
     * @return bool
     */
    public function getVisibility(): bool
    {

        return $this->visibility;
    }

    /**
     * @param bool $visibility
     */
    public function setVisibility(bool $visibility)
    {
        $this->visibility = $visibility;
    }

    /**
     * @var \Doctrine\Common\Collections\Collection
     */
    private $comment;

    /**
     * Constructor
     */
    public function __construct()
    {
        $this->comment = new \Doctrine\Common\Collections\ArrayCollection();
    }

    /**
     * Add comment
     *
     * @param \AppBundle\Entity\Comment $comment
     *
     * @return Products
     */
    public function addComment(\AppBundle\Entity\Comment $comment)
    {
        $this->comment[] = $comment;

        return $this;
    }

    /**
     * Remove comment
     *
     * @param \AppBundle\Entity\Comment $comment
     */
    public function removeComment(\AppBundle\Entity\Comment $comment)
    {
        $this->comment->removeElement($comment);
    }

    /**
     * Get comment
     *
     * @return \Doctrine\Common\Collections\Collection
     */
    public function getComment()
    {
        return $this->comment;
    }
}
