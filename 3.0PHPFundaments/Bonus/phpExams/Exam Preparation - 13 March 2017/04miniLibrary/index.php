<?php

require_once "app.php";

$genres = $bookService->getAllGenres();

$app->loadTemplate("index_frontend", $genres);