<?php

namespace AppBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Method;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\Routing\Annotation\Route;

class CartController extends Controller
{
    /**
     * @Route("/cart/add/{id_product}", name="cart_add")
     * @Method("POST")
     * @param Request $request
     * @param $id_product
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function indexAction(Request $request, $id_product)
    {
        $client_repo = $this->getDoctrine()->getRepository('AppBundle:Products');
        $product = $client_repo->find($id_product);
        $qtty = $request->request->get('qtty');
        dump($product);
        dump($qtty);
        exit;
//        return $this->render('cart/index.html.twig', array('id_product' => $id_product));
    }
}
