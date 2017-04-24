<?php

namespace Service;

interface BookServiceInterface
{
	public function addBook($isbn, $title, $genreId, $author, $releasedOn, $comment = null, $language, $img = null);


	public function getAllGenres();

	public function editBook($isbn, $title, $genreId, $author, $releasedOn, $comment = null, $language, $img = null);

	public function deleteId($id);
}