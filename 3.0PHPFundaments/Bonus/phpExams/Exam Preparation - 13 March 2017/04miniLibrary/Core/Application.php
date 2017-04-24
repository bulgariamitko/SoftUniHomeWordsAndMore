<?php

namespace Core;

class Application
{
    const FRONTEND_FOLDER = 'views';

    public function loadTemplate($templateName, $data = null)
    {
        include self::FRONTEND_FOLDER
            . '/'
            . $templateName
            . '.php';
    }

    public function checkLogin()
    {
        if (!isset($_SESSION['user_id'])) {
            header("Location: login.php");
            exit;
        }
    }
}