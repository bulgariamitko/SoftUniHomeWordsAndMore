<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Promotion;
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
                $this->updateCategory($submitted_form);
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
            if (isset($submitted_form["update_category"]) && $submitted_form["update_category"] == "1") {
                $issue_update_status = 1;
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
     * @param string $name
     * @param integer $discount
     * @param integer $productid
     * @param integer $categoryid
     * @param integer $userid
     * @return mixed
     */
    public function bootUpForm($name ='', $discount = 0, $productid = 0, $categoryid = 0, $userid = 0)
    {
        $product_names = $this->fetchNames('Products', 'products');
        $products_choices = $this->refactorChoices($product_names);
        $category_names = $this->fetchNames('Categories', 'categories');
        $category_choices = $this->refactorChoices($category_names);
        $user_names = $this->fetchNames('User', 'user');
        $user_choices = $this->refactorChoices($user_names);

        $promotion = new Promotion();
        $promotion->setName($name);
        $promotion->setDiscount($discount);
        $promotion->setProductid($productid);
        $promotion->setCategoryid($categoryid);
        $promotion->setUserid($userid);

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
}
