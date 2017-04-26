<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Cart;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Method;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\Routing\Annotation\Route;

class CartController extends Controller
{
    /**
     * @Route("/cart/show/{id_user}", name="cart_show")
     * @Security("has_role('ROLE_USER')")
     * @Method("GET")
     * @param Request $request
     * @param $id_user
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function indexAction(Request $request, $id_user)
    {
        // find cart
        $em = $this->getDoctrine()->getManager();
        $cartEm = $em->getRepository('AppBundle:Cart');
        $cart = $cartEm->findBy(
            array('userid' => $id_user)
        );
//        dump($cart);
//        exit;
//
//        // find user
//        $client_repo = $this->getDoctrine()->getRepository('AppBundle:User');
//        $user = $client_repo->find($id_user);
//        // get qtty
//        $qtty = $request->request->get('qtty');
//        // find product
//        $productId = $request->query->get('id_product');
//        $product_repo = $this->getDoctrine()->getRepository('AppBundle:Products');
//        $product = $product_repo->find($productId);
//        // category
//        $category_repo = $this->getDoctrine()->getRepository('AppBundle:Categories');
//        $category = $category_repo->find($product->getCategoryId());
//        // promotion
//        $promotionId = $request->query->get('id_promotion');
//        $promotion_repo = $this->getDoctrine()->getRepository('AppBundle:Promotion');
//        $promotion = $promotion_repo->find($promotionId);
//
//        dump($user);
//        dump($product);
//        dump($category);
//        dump($promotion);
//        dump($qtty);
        return $this->render('cart/index.html.twig', array(
            'cart' => $cart,
//            'product' => $product,
//            'category' => $category,
//            'promotion' => $promotion,
//            'qtty' => $qtty
        ));
    }

    /**
     * @Route("/cart/add/{id_user}", name="cart_add")
     * @Security("has_role('ROLE_USER')")
     * @Method("POST")
     * @param Request $request
     * @param $id_user
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function addToCart(Request $request, $id_user)
    {
        $qtty = $request->request->get('qtty');
        $productId = $request->query->get('id_product');
        $promotionId = $request->query->get('id_promotion');
        // try to add to DB
        try {
            // set Cart
            $cart = new Cart();
            $cart->setProductid($productId);
            $cart->setUserid($id_user);
            $cart->setDate(new \DateTime());
            $cart->setQtty($qtty);
            $cart->setPromotionid($promotionId);

            // add to DB
            $em = $this->getDoctrine()->getManager();
            $em->persist($cart);
            $em->flush();

            $this->addFlash('notice','A new Product have been added to the database!');
        } catch (Exception $e) {
            $this->addFlash('notice','Failed to add a new product to cart. Check errors log!');
            throw new Exception($e->getMessage() . "<br>" . $e->getTraceAsString());
        }
        return $this->redirectToRoute("cart_show", array('id_user' => $id_user));
    }
}
