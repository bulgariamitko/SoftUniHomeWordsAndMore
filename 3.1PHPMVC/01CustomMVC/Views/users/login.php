<?php // @var $model Models\LoginViewModel ?>
<h2>Потребители: <?= $model->getAllUsers(); ?> от тях активни: <?= $model->getActiveUsers(); ?></h2>
<form method="post">
	Username: <input type="text" name="name"> <br>
	Password: <input type="password" name="password"> <br>
	<input type="submit" name="submit" value="Submit">
</form>