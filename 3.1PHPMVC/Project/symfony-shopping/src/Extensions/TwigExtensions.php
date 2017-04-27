<?php
/**
 * Created by PhpStorm.
 * User: dimitar
 * Date: 26.04.17
 * Time: 10:00
 */

namespace Extensions;

use AppBundle\Entity\Cart;
use AppBundle\Entity\Promotion;
use Symfony\Bridge\Doctrine\RegistryInterface;

class TwigExtensions extends \Twig_Extension
{
    public function getFunctions()
    {
        return array(
            new \Twig_SimpleFunction('findPromotion', array($this, 'findPromotion')),
            new \Twig_SimpleFunction('findBiggerPromotion', array($this, 'findBiggerPromotion')),
            new \Twig_SimpleFunction('showCart', array($this, 'showCart')),
        );
    }

    protected $doctrine;
    // Retrieve doctrine from the constructor
    public function __construct(RegistryInterface $doctrine)
    {
        $this->doctrine = $doctrine;
    }

    public function findPromotion($id){
        $em = $this->doctrine->getManager();
        $myRepo = $em->getRepository('AppBundle:Promotion');
        return $myRepo->find($id);
    }

    /**
     * @param $productProId
     * @param $categoryProId
     * @param $userProId
     * @return array
     */
    public function findBiggerPromotion($productProId, $categoryProId, $userProId){
        $em = $this->doctrine->getManager();
        // product promotion
        $promotion = $em->getRepository('AppBundle:Promotion');
        // no promotion
        $noPromotion = $promotion->find(0);
        $productPromotion = $promotion->find($productProId);
        // category promotion
        $categoryEm = $em->getRepository('AppBundle:Categories');
        $category = $categoryEm->find($categoryProId);
        $categoryPromotion = $promotion->findBy(
            array('categoryid' => $category->getId())
        );
        // user promotion
        $userEm = $em->getRepository('AppBundle:User');
        $user = $userEm->find($userProId);
        $userPromotion = $promotion->findBy(
            array('userid' => $user->getId())
        );
        $promotions = [$productPromotion ?? $noPromotion, $categoryPromotion[0] ?? $noPromotion, $userPromotion[0] ?? $noPromotion];
        usort($promotions, array($this,'cmp'));

        return $promotions;
    }

    public function getName()
    {
        return 'Twig myCustomName Extensions';
    }

    private static function cmp(Promotion $a, Promotion $b)
    {
        return strcmp($b->getDiscount(), $a->getDiscount());
    }

    public function showCart(Cart $cart)
    {
        $em = $this->doctrine->getManager();
        // product
        $productEm = $em->getRepository('AppBundle:Products');
        $product = $productEm->find($cart->getProductid());
        // promotion
        $promotionEm = $em->getRepository('AppBundle:Promotion');
        $promotion = $promotionEm->find($cart->getPromotionid());

        return [$product, $promotion];
    }
}