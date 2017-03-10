<?php

Class Trainer
{
	protected $name;
	protected $pokemons = [];
	protected $badges = 0;
	const REDUCE_HEALTH = 10;

	public function __construct(string $name, Pokemon $pokemon)
	{
		$this->name = $name;
		$this->pokemons[] = $pokemon;
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
        $this->name = $name;

        return $this;
    }

    /**
     * Gets the value of pokemons.
     *
     * @return mixed
     */
    public function getPokemons()
    {
        return $this->pokemons;
    }

    public function addPokemon(Pokemon $pokemon)
    {
        $this->pokemons[] = $pokemon;

        return $this;
    }

    /**
     * Gets the value of badges.
     *
     * @return mixed
     */
    public function getBadges()
    {
        return $this->badges;
    }

    public function addBadge()
    {
    	return $this->badges++;
    }

    public function pokemonHasElement($element)
    {
    	foreach ($this->pokemons as $pokemon) {
    		if ($pokemon->getElement() == $element) {
    			return true;
    		}
    	}
    }

    public function reducePokemonHealth($element)
    {
    	foreach ($this->pokemons as $pokemon) {
    		if ($pokemon->getElement() != $element) {
				$pokemon->reduceHealth(self::REDUCE_HEALTH);

	    		// echo $pokemon->getElement() . var_dump(!$this->pokemonHasElement($element)) . " Element: " . $element . PHP_EOL;
    		}
    	}
    }

    public function removeDeadPokemons()
    {
    	$this->pokemons = array_filter($this->pokemons, function(Pokemon $pokemon) {
    		return $pokemon->isAlive();
    	});
    }
}

Class Pokemon
{
	protected $name;
	protected $element;
	protected $health;

	public function __construct(string $name, string $element, int $health)
	{
		$this->name = $name;
		$this->element = $element;
		$this->health = $health;
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
        $this->name = $name;

        return $this;
    }

    /**
     * Gets the value of element.
     *
     * @return mixed
     */
    public function getElement()
    {
        return $this->element;
    }

    /**
     * Sets the value of element.
     *
     * @param mixed $element the element
     *
     * @return self
     */
    protected function setElement($element)
    {
        $this->element = $element;

        return $this;
    }

    /**
     * Gets the value of health.
     *
     * @return mixed
     */
    public function getHealth()
    {
        return $this->health;
    }

    /**
     * Sets the value of health.
     *
     * @param mixed $health the health
     *
     * @return self
     */
    protected function setHealth($health)
    {
        $this->health = $health;

        return $this;
    }

    public function reduceHealth($health)
    {
    	return $this->health -= $health;
    }

    public function isAlive()
    {
    	if ($this->health > 0) {
    		return true;
    	}
    }
}

$line = trim(fgets(STDIN));
$players = [];

while ($line != "Tournament") {
	$line = explode(" ", $line);
	$playerName = $line[0];
	$pokemonName = $line[1];
	$pokemonElement = $line[2];
	$pokemonHealth = $line[3];

	$pokemon = new Pokemon($pokemonName, $pokemonElement, $pokemonHealth);
	$player = new Trainer($playerName, $pokemon);
	if (empty($players[$player->getName()]) == $playerName) {
		$players[$player->getName()] = $player;
	} else {
		$players[$player->getName()]->addPokemon($pokemon);
	}

	$line = trim(fgets(STDIN));
}

while ($line != "End") {
	if ($line == "Tournament") {
		$line = trim(fgets(STDIN));
		continue;
	}
	foreach ($players as $player) {
		if ($player->pokemonHasElement($line)) {
			$player->addBadge();
		} else {
			$player->reducePokemonHealth($line);
			$player->removeDeadPokemons();
		}
	}

	$line = trim(fgets(STDIN));
}

function sortDesc($a, $b)
{
	if ($a->getBadges() == $b->getBadges()) {
        return 0;
    }
    return ($a->getBadges() > $b->getBadges()) ? -1 : 1;
}

uasort($players, "sortDesc");

foreach ($players as $player) {
	echo $player->getName() . " " . $player->getBadges() . " " . count($player->getPokemons()) . PHP_EOL;
}