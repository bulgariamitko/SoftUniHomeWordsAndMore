<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Promotion;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Method;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Component\Config\Definition\Exception\Exception;
use Symfony\Component\Form\Extension\Core\Type\ChoiceType;
use Symfony\Component\Form\Extension\Core\Type\IntegerType;
use Symfony\Component\Form\Extension\Core\Type\SubmitType;
use Symfony\Component\Form\Extension\Core\Type\TextType;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Annotation\Route;

class PromotionsController extends CategoriesController
{
    /**
     * @Route("/Promotions/create", name="promotions_index")
     * @Security("has_role('ROLE_ADMIN')")
     * @param Request $request
     * @return Response
     */
    public function indexAction(Request $request)
    {
        $issue_update_status = 0;
        $form = $this->bootUpForm();
        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            $submitted_form = $request->request->all();
            if (isset($submitted_form["update_category"]) && $submitted_form["update_category"] == "1") {
                $this->updatePromotion($submitted_form);
                return $this->redirectToRoute("promotions_index");
            } else {
                try {
                    $category = $form->getData();
                    $em = $this->getDoctrine()->getManager();
                    $em->persist($category);
                    $em->flush();
                    $this->addFlash('notice','A new promotion is added to the database!');
                    return $this->redirectToRoute("promotions_index");
                } catch (Exception $e) {
                    $this->addFlash('notice','Failed to add a new Promotion. Check errors log!');
                    throw new Exception($e->getMessage() . "<br>" . $e->getTraceAsString());
                }
            }

        } elseif ($form->isSubmitted() && !$form->isValid()) {
            $submitted_form = $request->request->all();
            if (isset($submitted_form["update_promotions"]) && $submitted_form["update_promotions"] == "2") {
                $issue_update_status = 2;
                $notice = "Please click the corresponding category edit again in order to process a successful query. And type in a valid form. This feature will be fixed soon.";
            }
        }
        if ($issue_update_status) {
            $this->addFlash("notice",$notice);
        }

        $promotion_names = $this->fetchNames('Promotion', 'promotion');
        return $this->render('pages/promotions.html.twig', array(
            'form' => $form->createView(),
            'promotion_names' => json_encode($promotion_names)
        ));
    }

    /**
     * @Route("/Promotions/singlePromotion", name="single_promotion")
     * @Method("POST")
     * @Security("has_role('ROLE_ADMIN')")
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\JsonResponse|Response
     */
    public function getSinglePromotion(Request $request)
    {
        $req = $request->request->all();
        if (!empty($req) && isset($req["id"])) {
            $id = $req["id"];
            $em = $this->getDoctrine()->getManager()->find("AppBundle:Promotion",$id);
            $em = $this->serializeResponse($em);
            $em = [ "status" => 2,"result" => $em];
            return $this->json($em);
        }
        return new Response("Required Params Missing!");
    }

    /**
     * @Route("/Promotions/deletePromotion", name="delete_promotion")
     * @Method("POST")
     * @Security("has_role('ROLE_ADMIN')")
     * @param Request $request
     * @return Response
     */
    public function deletePromotion(Request $request)
    {
        $req = $request->request->all();
        if (!empty($req) && isset($req["id"])) {
            $id = $req["id"];
            $em = $this->getDoctrine()->getManager();
            $category = $em->getRepository('AppBundle:Promotion')->find($id);
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
     * @param integer $discount
     * @param integer $productid
     * @param integer $categoryid
     * @param integer $userid
     * @return mixed
     */
    public function bootUpForm($name ='', $discount = 0, $productid = 0, $categoryid = 0, $userid = 0)
    {
        $promotion = new Promotion();
        $promotion->setName($name);
        $promotion->setDiscount($discount);
        $promotion->setProductid($productid);
        $promotion->setCategoryid($categoryid);
        $promotion->setUserid($userid);

        $product_names = $this->fetchNames('Products', 'products');
        $products_choices = $this->refactorChoices($product_names);
        $category_names = $this->fetchNames('Categories', 'categories');
        $category_choices = $this->refactorChoices($category_names);
        $user_names = $this->fetchNames('User', 'user');
        $user_choices = $this->refactorChoices($user_names);

        $form = $this->createFormBuilder($promotion)
            ->add('name', TextType::class)
            ->add('discount', IntegerType::class, array('attr' => array('min' => 0, 'max' => 100)))
            ->add('productId', ChoiceType::class, ["choices" => $products_choices , "label" => "Choose a Product"])
            ->add('categoryId', ChoiceType::class, ["choices" => $category_choices , "label" => "Choose a Category"])
            ->add('userId', ChoiceType::class, ["choices" => $user_choices , "label" => "Choose User"])
            ->add('save', SubmitType::class, array('label' => 'Create Promotion'))
            ->getForm();
        return $form;
    }

    public function refactorChoices($choices='')
    {
        $prep_choices = [];
        if (is_array($choices) && !empty($choices)) {
            $prep_choices[0] = "Choose";
            foreach ($choices as $key => $value) {
                $prep_choices[$value["id"]] = $value['name'];
            }
        }
        return array_flip($prep_choices);
    }

    /**
     * @param $class
     * @param $find
     * @return mixed
     */
    private function fetchNames($class, $find)
    {
        $em = $this->getDoctrine()->getManager();
        $query = $em->createQuery(
            'SELECT ' . $find . '.name, ' . $find . '.id 
            FROM AppBundle:' . $class . ' ' . $find
        );
        return $query->getResult();
    }

    public function updatePromotion($form)
    {
        if (isset($form["update_category_id"])) {
            $id = $form["update_category_id"];
            $em = $this->getDoctrine()->getManager();
            $promotion = $em->getRepository('AppBundle:Promotion')->find($id);
            if (!$promotion) {
                throw $this->createNotFoundException(
                    'No category found for id '.$id
                );
            }
            $form = $form["form"];
            $promotion->setName($form["name"]);
            $promotion->setDiscount($form["discount"]);
            $promotion->setProductid($form["productId"]);
            $promotion->setCategoryid($form["categoryId"]);
            $promotion->setUserid($form["userId"]);
            if ($em->flush()) {
                return 1;
            }
        }
        return 0;
    }
}
