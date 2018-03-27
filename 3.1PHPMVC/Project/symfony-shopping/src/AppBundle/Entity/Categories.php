<?php

namespace AppBundle\Entity;
use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\Validator\Constraints as Validation;


/**
 * @ORM\Entity
 * @ORM\Table(name="categories")
 */
class Categories
{
    /**
     * @ORM\Column(type="integer")
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="AUTO")
     */
    private $id;
    /**
     * @ORM\Column(type="string",length=100)
     * @Validation\NotBlank()
     * @Validation\Length(max=15)
     * @Validation\Length(min=2)
     * @Validation\Type("string")
     */
    private $name;
    /**
     * @ORM\Column(type="string",length=100)
     */
    private $favicon;
    /**
     * @ORM\Column(type="string",length=500)
     * @Validation\Length(max=500)
     * @Validation\Length(min=20)
     */
    private $description;
    /**
     * @ORM\Column(type="integer",length=10)
     */
    private $promotionid = 0;


    /**
     * Get id
     *
     * @return integer
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * Set name
     *
     * @param string $name
     *
     * @return Categories
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
     * Set favicon
     *
     * @param string $favicon
     *
     * @return Categories
     */
    public function setFavicon($favicon)
    {
        $this->favicon = $favicon;

        return $this;
    }

    /**
     * Get favicon
     *
     * @return string
     */
    public function getFavicon()
    {
        return $this->favicon;
    }

    /**
     * Set description
     *
     * @param string $description
     *
     * @return Categories
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
     * @return mixed
     */
    public function getPromotionid()
    {
        return $this->promotionid;
    }

    /**
     * @param mixed $promotionid
     */
    public function setPromotionid($promotionid)
    {
        $this->promotionid = $promotionid;
    }
}
