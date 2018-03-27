<?php

namespace AppBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Method;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\Config\Definition\Exception\Exception;
use Symfony\Component\Form\Extension\Core\Type\CheckboxType;
use Symfony\Component\Form\Extension\Core\Type\IntegerType;
use Symfony\Component\Form\Extension\Core\Type\MoneyType;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\HttpFoundation\Request;
use AppBundle\Entity\Products;
// import some form types
use Symfony\Component\Form\Extension\Core\Type\TextType;
use Symfony\Component\Form\Extension\Core\Type\TextareaType;
use Symfony\Component\Form\Extension\Core\Type\FileType;
use Symfony\Component\Form\Extension\Core\Type\ChoiceType;
use Symfony\Component\Form\Extension\Core\Type\SubmitType;

class ProductsController extends Controller
{
    /**
     * @Route("/Products/Category/{id}", name="list_products_by_category")
     * @Method("GET")
     * @param $id
     * @return Response
     */
    public function listByCategoryIdAction($id)
    {
        $products = $this->getDoctrine()->getRepository("AppBundle:Products")->findBy(
            array('categoryId' => $id, 'visibility' => 1)
        );
        $category = $this->getDoctrine()->getRepository("AppBundle:Categories")->find($id);
        return $this->render("pages/product-list.html.twig",[
            "products" => $products,
            "category" => $category
        ]);
    }

    /**
     * @Route("/Products/list", name="products_index")
     * @Method("GET")
     */
    public function indexAction()
    {
        $products = $this->getDoctrine()->getRepository("AppBundle:Products")->findBy(
            array('visibility' => 1)
        );
        return $this->render("pages/product-list.html.twig",[
            "products" => $products,
        ]);
    }

    /**
     * @Route("/Products/create", name="products_create")
     * @Security("has_role('ROLE_ADMIN') or has_role('ROLE_EDITOR')")
     * @param Request $request
     * @return Response
     */
    public function createAction(Request $request)
    {
        $form = $this->bootUpForm();
        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            $submitted_form = $request->request->all();
            if (isset($submitted_form["update_category"]) && $submitted_form["update_category"] == "1") {
                $this->updateProduct($submitted_form);
                return $this->redirectToRoute("products_create");
            } else {
                try {
                    $product = $form->getData();
                    /** @var Products $product */
                    $image = $product->getImage();
                    $imageName = md5(uniqid()).'.'.$image->guessExtension();
                    $image->move(
                        $this->getParameter('images_directory'),
                        $imageName
                    );
                    $product->setCategoryId($product->getCategoryId());
                    $product->setName($product->getName());
                    $product->setImage($imageName);
                    $product->setDescription($product->getDescription());
                    $product->setPrice($product->getPrice());

                    // save product to db
                    $em = $this->getDoctrine()->getManager();
                    $em->persist($product);
                    $em->flush();
                    $this->addFlash('notice','A new product is added!');
                } catch (Exception $e) {
                    $this->addFlash('notice','Failed to add a new product. Check errors log!');
                    throw new Exception($e->getMessage() . "<br>" . $e->getTraceAsString());
                }
            }
        }

        $product_names = $this->fetchProductsNames();
        return $this->render('pages/product-create.html.twig', array(
            'form' => $form->createView(),
            'product_names' => json_encode($product_names)
        ));
    }

    /**
     * @Route("/Products/singleProduct", name="single_product")
     * @Method("POST")
     * @Security("has_role('ROLE_ADMIN') or has_role('ROLE_EDITOR')")
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\JsonResponse|Response
     */
    public function getSingleCategory(Request $request)
    {
        $req = $request->request->all();
        if (!empty($req) && isset($req["id"])) {
            $id = $req["id"];
            $em = $this->getDoctrine()->getManager()->find("AppBundle:Products",$id);
            $em = $this->serializeResponse($em);
            $em = [ "status" => 1,"result" => $em];
            return $this->json($em);
        }
        return new Response("Required Params Missing!");
    }

    /**
     * @Route("/Products/deleteProduct", name="delete_product")
     * @Method("POST")
     * @Security("has_role('ROLE_ADMIN') or has_role('ROLE_EDITOR')")
     * @param Request $request
     * @return Response
     */
    public function deleteProduct(Request $request)
    {
        $req = $request->request->all();
        if (!empty($req) && isset($req["id"])) {
            $id = $req["id"];
            $em = $this->getDoctrine()->getManager();
            $category = $em->getRepository('AppBundle:Products')->find($id);
            $cat_result = json_decode($this->serializeResponse($category));
            $em->remove($category); // returns null
            $em->flush(); // returns null
            $this->addFlash('notice',$cat_result->name . " Deleted..");
            return new Response($cat_result->name . " Deleted..");
        }
        return new Response("Required params missing.");
    }

    /**
     * @param string $categoryId
     * @param string $name
     * @param string $image
     * @param string $description
     * @param int $price
     * @param int $promotionId
     * @param int $qtty
     * @param boolean $visibility
     * @return mixed
     */
    public function bootUpForm($categoryId = "", $name = "", $image = "", $description = "", $price = 0, $promotionId = 0,
                               $qtty = 0, $visibility = true)
    {
        $product = new Products();
        $product->setCategoryId($categoryId);
        $product->setName($name);
        $product->setImage($image);
        $product->setDescription($description);
        $product->setPrice($price);
        $product->setPromotionid($promotionId);
        $product->setQtty($qtty);
        $product->setVisibility($visibility);

        $categoryNames = $this->fetchNames('Categories', 'categories');
        $chooseCategory = $this->refactorChoices($categoryNames);
        $promotionNames = $this->fetchNames('Promotion', 'promotion');
        $choosePromotion = $this->refactorChoices($promotionNames);
        $form = $this->createFormBuilder($product)
            ->add('categoryId', ChoiceType::class, ["choices" => $chooseCategory, "label" => "Choose a Category"])
            ->add('name', TextType::class)
            ->add('image', FileType::class, ['required' => false])
            ->add('description', TextareaType::class)
            ->add('price', MoneyType::class, ['currency' => 'BGN'])
            ->add('promotionId', ChoiceType::class, ["choices" => $choosePromotion, "label" => "Choose a Promotion"])
            ->add('qtty', IntegerType::class)
            ->add('visibility', CheckboxType::class, ['label' => 'Show this product publicly?', 'required' => false])
            ->add('save', SubmitType::class, ['label' => 'Create Product'])
            ->getForm();
        return $form;
    }

    public function refactorChoices($choices='')
    {
        $prep_choices = [];
        if (is_array($choices) && !empty($choices)) {
            $prep_choices[0] = "Choose";
            foreach ($choices as $key => $value) {
                $prep_choices[$value["id"]] = $value["name"];
            }
        }
        return array_flip($prep_choices);
    }

    public function serializeResponse($object)
    {
        return $this->get('serializer')->serialize($object, 'json');
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

    public function fetchProductsNames()
    {
        $em = $this->getDoctrine()->getManager();
        $query = $em->createQuery(
            'SELECT products.name, products.id 
            FROM AppBundle:Products products'
        );
        // ->setMaxResults(2); Put limit on the results..
        return $query->getResult();
    }

    public function updateProduct($form)
    {
        if (isset($form["update_category_id"])) {
            $id = $form["update_category_id"];
            $em = $this->getDoctrine()->getManager();
            $product = $em->getRepository('AppBundle:Products')->find($id);

            if (!$product) {
                throw $this->createNotFoundException(
                    'No product found for id '.$id
                );
            }
            $form = $form["form"];
            $product->setCategoryId($form["categoryId"]);
            $product->setName($form["name"]);
//            $image = $form["image"];
//            $imageName = md5(uniqid()).'.'.$image->guessExtension();
//            $image->move(
//                $this->getParameter('images_directory'),
//                $imageName
//            );
//            $product->setImage($imageName);
            $product->setDescription($form["description"]);
            $product->setPrice($form["price"]);
            $product->setPromotionid($form["promotionId"]);
            $product->setQtty($form["qtty"]);
            $product->setVisibility($form["visibility"] ?? 0);
            if ($em->flush()) {
                return 1;
            }

        }
        return 0;
    }
}