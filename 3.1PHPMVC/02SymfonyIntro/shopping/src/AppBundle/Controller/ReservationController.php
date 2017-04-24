<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Reservation;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\Routing\Annotation\Route;

class ReservationController extends Controller
{
    /**
     * @Route("/reservations", name="reservations")
     */
    public function indexAction()
    {
        return $this->render("reservations/index.html.twig");
    }

    /**
     * @Route("/reservation/{id_client}", name="booking")
     * @param Request $request
     * @param $id_client
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function book(Request $request, $id_client)
    {
        $data = [];
        $data['id_client'] = $id_client;

        $data['rooms'] = null;
        $data['dates']['from'] = '';
        $data['dates']['to'] = '';
        $form = $this   ->createFormBuilder()
            ->add('dateFrom')
            ->add('dateTo')
            ->getForm();

        $form->handleRequest($request);

        if ($form->isSubmitted()) {
            $form_data = $form->getData();

            $data['dates']['from'] = $form_data['dateFrom'];
            $data['dates']['to'] = $form_data['dateTo'];

            $em = $this->getDoctrine()->getManager();
            $rooms = $em->getRepository('AppBundle:Room')
                ->getAvailableRooms($form_data['dateFrom'], $form_data['dateTo']);

            $data['rooms'] = $rooms;

        }

        $client = $this
            ->getDoctrine()
            ->getRepository('AppBundle:Client')
            ->find($id_client);

        $data['client'] = $client;

        return $this->render("reservations/book.html.twig", $data);
    }

    /**
     * @Route("/book_room/{id_client}/{id_room}/{date_in}/{date_out}", name="book_room")
     * @param $id_client
     * @param $id_room
     * @param $date_in
     * @param $date_out
     * @return \Symfony\Component\HttpFoundation\RedirectResponse
     */
    public function bookRoom($id_client, $id_room, $date_in, $date_out)
    {

        $reservation = new Reservation();
        $date_start = new \DateTime( $date_in );
        $date_end = new \DateTime($date_out);
        $reservation->setDateIn( $date_start );
        $reservation->setDateOut( $date_end );

        $client = $this
            ->getDoctrine()
            ->getRepository('AppBundle:Client')
            ->find($id_client);
        $room = $this
            ->getDoctrine()
            ->getRepository('AppBundle:Room')
            ->find($id_room);

        $em = $this->getDoctrine()
            ->getManager();

        $reservation->setClient( $client );
        $reservation->setRoom($room);

        $em->persist($reservation);
        $em->flush();

//        $data['debug']['client'] = $client;
//        return $this->render('debug.html.twig', $data);
        return $this->redirectToRoute('index_clients');
    }
}
