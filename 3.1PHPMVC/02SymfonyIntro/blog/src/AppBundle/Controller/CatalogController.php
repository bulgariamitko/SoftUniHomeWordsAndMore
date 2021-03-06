<?php

namespace AppBundle\Controller;

use AppBundle\Form\ProductFormType;
use AppBundle\Entity\CartItemEntity;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Template;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\Form\FormInterface;

class CatalogController extends Controller {
	/**
	 * @Route("/", name="catalog")
	 * @Template()
	 * @return array
	 */
	public function indexAction() {
		$form_factory = $this->get('app.factory.form_factory');
		$order_service = $this->get('app.service.order_service');

		$female_form = $form_factory->createAndHandle('female', ProductFormType::class, new CartItemEntity('female', 'Dámské tričko', 499));
		$male_form = $form_factory->createAndHandle('male', ProductFormType::class, new CartItemEntity('male', 'Pánské tričko', 499));

		/** @var FormInterface $form */
		foreach ([$female_form, $male_form] as $form) {
			if (!$form->isSubmitted()) {
				continue;
			}

			if (!$form->isValid()) {
				$this->addFlash('danger', 'Something went wrong.');
				break;
			}

			$order_service->addIntoCartFromTheForm($form);
			$this->addFlash('success', 'The Product have been added to the cart.');

			return $this->redirectToRoute('catalog');
		}

		return [
			'female_form' => $female_form->createView(),
			'male_form'   => $male_form->createView()
		];
	}
}
