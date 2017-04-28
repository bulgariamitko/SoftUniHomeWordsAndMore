<?php

namespace AppBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Method;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;

class DefaultController extends Controller
{
    /**
     * @Route("/", name="homepage")
     * @Method("GET")
     */
    public function indexAction()
    {
        $text_container = [
        "jumbotron" => [
            "title" => "SoftUni demo Symfony Shop.",
            "sub_title" => "Welcome to this Symfony shop created by bulgaria_mitko."
        ],
        "mumbotron" => [
            "title" => "Our Products",
            "sub_title" => "Browse through the top trending products on our site."
        ]
        ];
        // visit doctrine docs to find out more..
        $categories = $this->getDoctrine()->getRepository("AppBundle:Categories")->findAll();
        
        // replace this example code with whatever you need
        return $this->render('index.html.twig', [
            'base_dir' => realpath($this->getParameter('kernel.root_dir').'/..').DIRECTORY_SEPARATOR,
            "data" => $text_container["jumbotron"],
            "categories" => $categories,
            "mumbotron" => $text_container["mumbotron"]
        ]);
    }

}
