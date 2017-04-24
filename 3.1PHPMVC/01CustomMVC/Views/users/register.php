<h1>Title: <?= $model->getTitle(); ?></h1>
<form method="post" action="<?= $this->url('users', 'registerProcess', 'gosho', 34); ?>">
	Username: <input type="text" name="username"> <br>
	Password: <input type="password" name="password"> <br>
	Confirm: <input type="password" name="confirmPass"> <br>
	<input type="submit" value="Register!">
</form>