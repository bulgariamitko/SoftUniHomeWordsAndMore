<?php

namespace AppBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Method;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
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
        $products = $this->getDoctrine()->getRepository("AppBundle:Products")->findBy(array('categoryId' => $id));
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
        $products = $this->getDoctrine()->getRepository("AppBundle:Products")->findAll();
        return $this->render("pages/product-list.html.twig",[
            "products" => $products,
        ]);
    }

    /**
     * @Route("/Products/create",name="products_create")
     * @Security("has_role('ROLE_ADMIN')")
     * @param Request $request
     * @return Response
     */
    public function createAction(Request $request)
    {
        $form = $this->bootUpForm();
        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            $product = $form->getData();
//            dump($product);
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
//            dump($product);
//            exit;
            // ... perform some action, such as saving the product to the database
            // for example, if product is a Doctrine entity, save it!
            $em = $this->getDoctrine()->getManager();
            $em->persist($product);
            $em->flush();
            $this->addFlash('notice','A new product is added!');


//             return $this->redirectToRoute('task_success');
        }

        $product_names = $this->fetchProductsNames();
        return $this->render('pages/product-create.html.twig', array(
            'form' => $form->createView(),
            'product_names' => json_encode($product_names)
        ));
    }

    /**
     * @Route("/Products/deleteProduct", name="delete_product")
     * @Method("POST")
     * @Security("has_role('ROLE_ADMIN')")
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
     * @param integer $price
     * @return mixed
     */
    public function bootUpForm($categoryId = "", $name = "", $image = "", $description = "", $price = 0, $promotionId = 0)
    {
        $product = new Products();
        $product->setCategoryId($categoryId);
        $product->setName($name);
        $product->setImage($image);
        $product->setDescription($description);
        $product->setPrice($price);
        $product->setPrice($promotionId);

        $categoryNames = $this->fetchNames('Categories', 'categories');
        $chooseCategory = $this->refactorChoices($categoryNames);
        $promotionNames = $this->fetchNames('Promotion', 'promotion');
        $choosePromotion = $this->refactorChoices($promotionNames);
        $form = $this->createFormBuilder($product)
            ->add('categoryId', ChoiceType::class, ["choices" => $chooseCategory, "label" => "Choose a Category"])
            ->add('name', TextType::class)
            ->add('image', FileType::class)
            ->add('description', TextareaType::class)
            ->add('price', MoneyType::class, ['currency' => 'BGN'])
            ->add('promotionId', ChoiceType::class, ["choices" => $choosePromotion, "label" => "Choose a Promotion"])
            ->add('save', SubmitType::class, array('label' => 'Create Product'))
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
}