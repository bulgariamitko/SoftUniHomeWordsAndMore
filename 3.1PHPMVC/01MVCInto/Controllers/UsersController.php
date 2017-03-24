<?php

namespace Controllers;

use Core\View;
use Core\ViewInterface;
use Models\LoginViewModel;
use Models\RegisterViewModel;
use Models\UserRegisterBidingModel;
use Core\Http\Components\Session\SessionInterface;

Class UsersController
{
	public function register(ViewInterface $view, SessionInterface $session)
	{
		echo "<pre>";
		print_r($session);
		echo "</pre>";
		$viewModel = new RegisterViewModel("Register page");
		$view->render("users/register", $viewModel);
	}

	public function registerProcess($name, UserRegisterBidingModel $bidingModel, ViewInterface $view, $id)
	{
		if ($bidingModel->getConfirmPassword() != $bidingModel->getPassword()) {
			throw new Exception("Password mismatch");
		}

		echo "ok " . $name . " - " . $id . " - " . $bidingModel->getPassword() . " - " . get_class($view);
	}

	public function login($id)
	{
		$view = new View();
		$view->render('users/login', new LoginViewModel(380, 44));
	}

	public function test(ViewInterface $view)
	{
		$view->render();
	}
}