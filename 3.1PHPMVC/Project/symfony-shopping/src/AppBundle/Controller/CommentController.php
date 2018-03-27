<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Comment;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\Config\Definition\Exception\Exception;
use Symfony\Component\Form\Extension\Core\Type\SubmitType;
use Symfony\Component\Form\Extension\Core\Type\TextareaType;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\Routing\Annotation\Route;

class CommentController extends Controller
{
    /**
     * @Route("/Product/{id_product}/Comments", name="show_comments")
     * @Security("is_authenticated()")
     * @param Request $request
     * @param $id_product
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function indexAction(Request $request, $id_product)
    {
        $form = $this->bootUpForm();
        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            $submitted_form = $request->request->all();
            try {
                $comment = new Comment();
                $comment->setText($submitted_form["form"]["text"]);
                $product = $this->getDoctrine()->getRepository("AppBundle:Products")->find($id_product);
                $comment->setProducts($product);
                $user = $this->get('security.token_storage')->getToken()->getUser();
                $comment->setUser($user);
                $em = $this->getDoctrine()->getManager();
                $em->persist($comment);
                $em->flush();
                $this->addFlash('notice','A new comment was added to the database!');
                return $this->redirectToRoute('show_comments', array('id_product' => $id_product));
            } catch (Exception $e) {
                $this->addFlash('notice','Failed to add a new category. Check errors log!');
                throw new Exception($e->getMessage() . "<br>" . $e->getTraceAsString());
            }
        }

        $comments = $this->getDoctrine()->getRepository("AppBundle:Comment")->findBy(
            array('products' => $id_product)
        );
        dump($comments);
        return $this->render('comment/index.html.twig', array(
            'comments' => $comments,
            'form' => $form->createView()
            )
        );
    }

    /**
     * @param string $text
     * @return mixed
     */
    public function bootUpForm($text="")
    {
        $comment = new Comment();
        $comment->setText($text);
//        $comment->setProducts($productId);
//        $comment->setUser($userId);

        $form = $this->createFormBuilder($comment)
            ->add('text', TextareaType::class)
            ->add('save', SubmitType::class, array('label' => 'Post Comment'))
            ->getForm();
        return $form;
    }
}
