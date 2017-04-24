<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Document</title>
</head>
<body>
	<form>
		Book ID*: <input type="text" name="isbn"><br>
		Author*: <input type="text" name="author"><br>
		Title*: <input type="text" name="isbn"><br>
		Language*: <input type="text" name="isbn"><br>
		Year of release*: <input type="text" name="isbn"><br>
		Genre*: 
		<select name="genre_id">
			<?php foreach ($data as $genre): ?>
				<option value="<?= $genre->getId(); ?>">
					<?= $genre->getName(); ?>
				</option>
			<?php endforeach ?>
		</select><br>
		Comment:
		<textarea name="comment"></textarea>
		Image: <input type="file" name="image">
	</form>
</body>
</html>