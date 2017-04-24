<?php

namespace AppBundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Annotation\Route;
use AppBundle\Entity\Client;

class ClientsController extends Controller
{
    private $titles = ['mr', 'ms', 'mrs', 'dr', 'mx'];

    /**
     * @Route("/guests", name="index_clients")
     */
    public function indexAction()
    {
        $logger = $this->get('logger');
        $logger->info('User have opened the guest page');

        $data = [];
        $clients = $this->getDoctrine()->getRepository('AppBundle:Client')->findAll();
        $data['clients'] = $clients;
        return $this->render('clients/index.html.twig', $data);
    }

    /**
     * @Route("/guests/modify/{id_client}", name="modify_client")
     */
    public function showDetails(Request $request, $id_client)
    {
        $data = [];
        $client_repo = $this->getDoctrine()->getRepository('AppBundle:Client');
        $data['mode'] = 'modify';
        $data['form'] = [];
        $data['titles'] = $this->titles;

        $form = $this->createFormBuilder()
            ->add('name')
            ->add('last_name')
            ->add('title')
            ->add('address')
            ->add('zip_code')
            ->add('city')
            ->add('state')
            ->add('email')
            ->getForm();

        $form->handleRequest($request);
        if ($form->isSubmitted()) {
            $form_data = $form->getData();
            $data['form'] = [];
            $data['form'] = $form_data;
            $client = $client_repo->find($id_client);

            $client->setTitle($form_data['title']);
            $client->setName($form_data['name']);
            $client->setLastName($form_data['last_name']);
            $client->setAddress($form_data['address']);
            $client->setZipCode($form_data['zip_code']);
            $client->setCity($form_data['city']);
            $client->setState($form_data['state']);
            $client->setEmail($form_data['email']);

            $em = $this->getDoctrine()->getManager();
            $em->flush();

            return $this->redirectToRoute('index_clients');
        } else {
            $client = $client_repo->find($id_client);
            $client_data['id'] = $client->getId();
            $client_data['title'] = $client->getTitle();
            $client_data['name'] = $client->getName();
            $client_data['last_name'] = $client->getLastName();
            $client_data['address'] = $client->getAddress();
            $client_data['zip_code'] = $client->getZipCode();
            $client_data['city'] = $client->getCity();
            $client_data['state'] = $client->getState();
            $client_data['email'] = $client->getEmail();

            $client_data['titles'] = $this->titles;

            $data['form'] = $client_data;
        }
        return $this->render('clients/form.html.twig', $data);
    }

    /**
     * @Route("/guests/new", name="new_client")
     */
    public function showNew(Request $request)
    {
        $data = [];
        $data['mode'] = 'new_client';
        $data['titles'] = $this->titles;
        $data['form'] = [];
        $data['form']['title'] = '';

        $form = $this->createFormBuilder()
            ->add('name')
            ->add('last_name')
            ->add('title')
            ->add('address')
            ->add('zip_code')
            ->add('city')
            ->add('state')
            ->add('email')
            ->getForm();

        $form->handleRequest($request);
        if ($form->isSubmitted()) {
            $form_data = $form->getData();
            $data['form'] = [];
            $data['form'] = $form_data;

            $em = $this->getDoctrine()->getManager();
            $client = new Client();
            $client->setTitle($form_data['title']);
            $client->setName($form_data['name']);
            $client->setLastName($form_data['last_name']);
            $client->setAddress($form_data['address']);
            $client->setZipCode($form_data['zip_code']);
            $client->setCity($form_data['city']);
            $client->setState($form_data['state']);
            $client->setEmail($form_data['email']);

            $em->persist($client);

            $em->flush();

            return $this->redirectToRoute('index_clients');
        }

        return $this->render('clients/form.html.twig', $data);
    }

    /**
     * @Route("/github")
     */
    public function github()
    {
        $client = new \GuzzleHttp\Client();
        $res = $client->request('GET', 'https://api.github.com/users/bulgariamitko');

        return new Response('<pre>' . $res->getBody() . '</pre>');
    }

    /**
     * @Route("/about")
     * @return Response
     */
    public function about()
    {
        return new Response('<h4>About</h4>');
    }
}
