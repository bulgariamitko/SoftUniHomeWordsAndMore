<?php
/**
 * Created by PhpStorm.
 * User: dimitar
 * Date: 10.04.17
 * Time: 10:29
 */

namespace AppBundle\Entity;


interface IEntity
{
    public function getSku();
    public function getTitle();
    public function getPrice();
}