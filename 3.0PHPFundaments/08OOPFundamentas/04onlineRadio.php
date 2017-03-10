<?php

Class Artist
{
	protected $name;

	public function __construct(string $name)
	{
		$this->setName($name);
	}

    /**
     * Gets the value of name.
     *
     * @return mixed
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * Sets the value of name.
     *
     * @param mixed $name the name
     *
     * @return self
     */
    protected function setName($name)
    {
    	if (!Validator::numberIsInRange(strlen($name), 3, 20)) {
            throw new InvalidArtistNameException("Artist name should be between 3 and 20 symbols.");
        }
        $this->name = $name;

        return $this;
    }
}

Class Song
{
	protected $name;
	protected $duration;

	public function __construct(string $name, int $mins, int $secs)
	{
		$this->setName($name);
		$this->setDuration($mins, $secs);
	}

    /**
     * Gets the value of name.
     *
     * @return mixed
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * Sets the value of name.
     *
     * @param mixed $name the name
     *
     * @return self
     */
    protected function setName($name)
    {
    	if (!Validator::numberIsInRange(strlen($name), 3, 30)) {
            throw new InvalidSongNameException("Song name should be between 3 and 30 symbols.");
        }
        $this->name = $name;

        return $this;
    }

    /**
     * Gets the value of duration.
     *
     * @return mixed
     */
    public function getDuration()
    {
        return $this->duration;
    }

    protected function setDuration($mins, $secs)
    {
    	if (!Validator::numberIsInRange($mins, 0, 14)) {
    		throw new InvalidSongMinutesException("Song minutes should be between 0 and 14.");
    	}
    	if (!Validator::numberIsInRange($secs, 0, 59)) {
    		throw new InvalidSongMinutesException("Song seconds should be between 0 and 59.");
    	}
        $this->duration = $secs + ($mins * 60);

        return $this;
    }
}

Class Playlist
{
	protected $songs = [];
	protected $totalMediaLength = 0;

	public function AddMedia(Song $song)
	{
		$this->songs[] = $song;
		$this->totalMediaLength += $song->getDuration();
	}

	public function getMediaCount()
	{
		return count($this->songs);
	}

	public function getMediaDuration()
	{
		return [
			"hours" => floor(floor($this->totalMediaLength / 60) / 60),
            "minutes" => str_pad(floor($this->totalMediaLength / 60) % 60, 2, "0", STR_PAD_LEFT),
            "seconds" => str_pad($this->totalMediaLength % 60, 2, "0", STR_PAD_LEFT)
		];
	}

	public function __toString()
	{
		$duration = $this->getMediaDuration();
		$output = "Songs added: " . $this->getMediaCount() . PHP_EOL;
		$output .= "Playlist length: " . $duration['hours'] . "h " . $duration['minutes'] . "m " . $duration['seconds'] . "s";
		return $output;
	}
}

class Validator
{
    public static function numberIsInRange(int $value, int $min, int $max, bool $inclusive = true)
    {
        if ($inclusive) {
            return $value >= $min && $value <= $max;
        }
        return $value > $min && $value < $max;
    }
}

class InvalidSongException extends Exception
{
}

class InvalidArtistNameException extends InvalidSongException
{
}

class InvalidSongNameException extends InvalidSongException
{
}

class InvalidSongLengthException extends InvalidSongException
{
}

class InvalidSongMinutesException extends InvalidSongLengthException
{
}

class InvalidSongSecondsException extends InvalidSongLengthException
{
}

$playlist = new Playlist();
$loop = trim(fgets(STDIN));

for ($i=0; $i < $loop; $i++) {
	$songData = explode(";", trim(fgets(STDIN)));

	try {
		$artist = new Artist($songData[0]);
		$lengthData = explode(":", $songData[2]);
		$song = new Song($songData[1], $lengthData[0], $lengthData[1]);
		$playlist->AddMedia($song);
		echo "Song added." . PHP_EOL;
	} catch (Exception $e) {
		echo $e->getMessage() . PHP_EOL;
	}
}

echo $playlist;