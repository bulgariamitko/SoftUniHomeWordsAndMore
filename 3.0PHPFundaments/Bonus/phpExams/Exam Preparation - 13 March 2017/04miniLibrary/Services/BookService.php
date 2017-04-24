<?php

Class BookService implements Service\BookServiceInterface
{
	protected $db;

	public function __construct($db)
	{
		$this->db = $db;
	}

	public function addBook($isbn, $title, $genreId, $author, $releasedOn, $comment = null, $language, $img = null)
	{
		foreach (func_get_args() as $argName => $value) {
			if (empty($value)) {
				throw new Exception($argName . " cannot be empty");
			}
		}

		new DateTime($releasedOn);

		if (!$this->genreExists($genreId)) {
			throw new Exception("Genre does not exist");
		}

		$this->db->MInsert('Books', '(ISBN, Title, GenreID, Author, ReleasedOn, Comment, Language, Image) VALUES ("' . $isbn . '", "' . $title . '", "' . $genreId . '", "' . $author . '", "' . $releasedOn . '", "' . $comment . '", "' . $language . '", "' . $img . '")');
	}


	public function getAllGenres()
	{

	}

	public function editBook($isbn, $title, $genreId, $author, $releasedOn, $comment = null, $language, $img = null)
	{

	}

	public function deleteId($id)
	{

	}

	public function genreExists($id)
	{
		$genre = $this->db('Genres', 'ID', 'WHERE ID = ' . $id);
		return !!$genre;
	}
}