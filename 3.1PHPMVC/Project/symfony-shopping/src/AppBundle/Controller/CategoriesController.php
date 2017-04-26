<?php

namespace AppBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Method;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Component\Config\Definition\Exception\Exception;
use Symfony\Component\Debug\Debug;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use AppBundle\Entity\Categories;
// import some form types
use Symfony\Component\Form\Extension\Core\Type\TextType;
use Symfony\Component\Form\Extension\Core\Type\TextareaType;
use Symfony\Component\Form\Extension\Core\Type\SubmitType;

class CategoriesController extends Controller
{
    /**
     * @Route("/Categories/index", name="categories_index")
     * @Security("has_role('ROLE_ADMIN')")
     * @param Request $request
     * @return Response
     */
    public function indexAction(Request $request)
    {
        Debug::enable();
        $form = $this->bootUpForm();
//        \Doctrine\Common\Util\Debug::dump($form);
//        exit;
        $form->handleRequest($request);
        $issue_update_status = 0;

        if ($form->isSubmitted() && $form->isValid()) {
            $submitted_form = $request->request->all();
            if (isset($submitted_form["update_category"]) && $submitted_form["update_category"] == "1") {
                 $this->updateCategory($submitted_form);
                return $this->redirectToRoute("categories_index");
            } else {
                try {
                    $category = $form->getData();
                    $em = $this->getDoctrine()->getManager();
                    $em->persist($category);
                    $em->flush();
                    $this->addFlash('notice','A new category is added to the database!');
                    return $this->redirectToRoute("categories_index");
                } catch (Exception $e) {
                    $this->addFlash('notice','Failed to add a new category. Check errors log!');
                    throw new Exception($e->getMessage() . "<br>" . $e->getTraceAsString());
                }
            }

        } elseif ($form->isSubmitted() && !$form->isValid()) {
            $submitted_form = $request->request->all();
            if (isset($submitted_form["update_category"]) && $submitted_form["update_category"] == "1") {
                $issue_update_status = 1;
                $notice = "Please click the corresponding category edit again in order to process a successful query. And type in a valid form. This feature will be fixed soon.";
            }
        }
        if ($issue_update_status) {
            $this->addFlash("notice",$notice);
        }

        $categories_names = $this->fetchCategoriesNames();
        return $this->render('pages/categories.html.twig', array(
            'form' => $form->createView(),
            'categories_names' => json_encode($categories_names)
        ));
    }

    /**
     * @Route("/Categories/singleCategory", name="single_category")
     * @Method("POST")
     * @Security("has_role('ROLE_ADMIN')")
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\JsonResponse|Response
     */
    public function getSingleCategory(Request $request)
    {
        $req = $request->request->all();
        if (!empty($req) && isset($req["id"])) {
            $id = $req["id"];
            $em = $this->getDoctrine()->getManager()->find("AppBundle:Categories",$id);
            $em = $this->serializeResponse($em);
            $em = [ "status" => 1,"result" => $em];
            return $this->json($em);
        }
        return new Response("Required Params Missing!");
    }

    /**
     * @Route("/Categories/deleteCategory", name="delete_category")
     * @Method("POST")
     * @Security("has_role('ROLE_ADMIN')")
     * @param Request $request
     * @return Response
     */
    public function deleteCategory(Request $request)
    {
        $req = $request->request->all();
        if (!empty($req) && isset($req["id"])) {
            $id = $req["id"];
            $em = $this->getDoctrine()->getManager();
            $category = $em->getRepository('AppBundle:Categories')->find($id);
            $cat_result = json_decode($this->serializeResponse($category));
            $em->remove($category); // returns null
            $em->flush(); // returns null
            $this->addFlash('notice',$cat_result->name . " Deleted..");
            return new Response($cat_result->name . " Deleted..");
        }
        return new Response("Required params missing.");
    }

    /**
     * @param string $name
     * @param string $description
     * @param string $favicon
     * @return mixed
     */
    public function bootUpForm($name="",$description="",$favicon="fa fa-microchip")
    {
        $category = new Categories();
        $category->setName($name);
        $category->setFavicon($favicon);
        $category->setDescription($description);

        $form = $this->createFormBuilder($category)
            ->add('name', TextType::class)
            ->add('favicon', TextType::class)
            ->add('description', TextareaType::class)
            ->add('save', SubmitType::class, array('label' => 'Create Category'))
            ->getForm();
        return $form;
    }

    public function serializeResponse($object)
    {
        return $this->get('serializer')->serialize($object, 'json');
    }

    public function fetchCategoriesNames()
    {
        $em = $this->getDoctrine()->getManager();
        $query = $em->createQuery(
            'SELECT categories.name, categories.id 
            FROM AppBundle:Categories categories'
        );
        // ->setMaxResults(2); Put limit on the results..
        return $query->getResult();
    }

    public function updateCategory($form)
    {
        if (isset($form["update_category_id"])) {
            $id = $form["update_category_id"];
            $em = $this->getDoctrine()->getManager();
            $category = $em->getRepository('AppBundle:Categories')->find($id);

           if (!$category) {
               throw $this->createNotFoundException(
                   'No category found for id '.$id
               );
           }
           $form = $form["form"];
           $category->setName($form["name"]);
           $category->setFavicon($form["favicon"]);
           $category->setDescription($form["description"]);
           if ($em->flush()) {
                return 1;
           }

        }
       return 0;
    }

}