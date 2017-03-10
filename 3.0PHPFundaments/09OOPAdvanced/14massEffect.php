<?php

interface StarSystemInterface
{
	public function addNeighbour($solarSystemName, $fuelNeeded) : StarSystemInterface;
	public function getName();
	public function getShip($name) : ShipInterface;
	public function addShip(ShipInterface $ship);
	public function travelTo($shipName, StarSystemInterface $starSystem);
}

interface GalaxyInterface
{
	public function getStarSystem($name) : StarSystemInterface;
	public function addStarSystem($name, StarSystemInterface $starSystem);
	public function shipExists($name): bool;
	public function addShip(ShipInterface $ship);
	public function getShip($name): ShipInterface;
}

interface GameInterface
{
	const STAR_SYATEM_ARTEMIS_TAU = "Artemis-Tau";
	const STAR_SYATEM_SERPENT_NEBULA = "Serpent-Nebula";
	const STAR_SYATEM_HADES_GAMMA = "Hades-Gamma";
	const STAR_SYATEM_KEPLER_VERGE = "Kepler-Verge";

	public function start();
}

interface EnhancementInterface
{
	public function giveBonus(ShipInterface $ship);
}

interface ProjectilesInterface
{
	public function attack(ShipInterface $ship);
	public function getAttack() : int;
}

interface ShipInterface
{
	public function getName() : string;
	public function getAttack() : int;
	public function getShields() : int;
	public function getHealth() : int;
	public function getFuel() : float;
	public function setName(string $name);
	public function setAttack(int $attack);
	public function setShields(int $shields);
	public function setHealth(int $health);
	public function setFuel(float $fuel);
	public function setStarSystem() : StarSystemInterface;
	public function jumpTo(StarSystemInterface $starSystem);
	public function attack(ShipInterface $ship);
	public function attackResponce(ProjectilesInterface $projectile);
	public function fireProjectile() : ProjectilesInterface;
	public function isAlive(): bool;
	public function __toString();
}

interface ProjectileInterface
{
	public function attack(ShipInterface $ship);
	public function getAttack() : int;
}

interface Executable
{
	public function execute(array $args = []) : string;
}

abstract class EnhancementAbstract implements EnhancementInterface
{
	public function __toString()
	{
		return basename(get_class($this));
	}
}

abstract class ShipAbstract implements ShipInterface
{
	protected $health;
	protected $shields;
	protected $attack;
	protected $fuel;
	protected $name;
	protected $starSystem;
	protected $enhancements;

	public function __construct(int $health, int $shields, int $attack, float $fuel, string $name, StarSystemInterface $starSystem, $enhancements = [])
	{
		$this->setHealth($health);
		$this->setShields($shields);
		$this->setAttack($attack);
		$this->setFuel($fuel);
		$this->setName($name);
		$this->jumpTo($starSystem);
		$this->addEnhancements($enhancements);
	}

    public function getHealth() : int
    {
        return $this->health;
    }

    public function setHealth(int $health)
    {
        $this->health = max(0, $health);

        return $this;
    }

    public function getShields() : int
    {
        return $this->shields;
    }

    public function setShields(int $shields)
    {
        $this->shields = max(0, $shields);

        return $this;
    }

    public function getAttack() : int
    {
        return $this->attack;
    }

    public function setAttack(int $attack)
    {
        $this->attack = max(0, $attack);

        return $this;
    }

    public function getFuel() : float
    {
        return $this->fuel;
    }

    public function setFuel(float $fuel)
    {
        $this->fuel = max(0, $fuel);

        return $this;
    }

    public function getName() : string
    {
        return $this->name;
    }

    public function setName(string $name)
    {
        $this->name = $name;

        return $this;
    }

    public function getStarSystem() : StarSystemInterface
    {
        return $this->starSystem;
    }

    public function jumpTo(StarSystemInterface $starSystem)
    {
        $this->starSystem = $starSystem;
    }

    public function isAlive() : bool
    {
    	return $this->getHealth() > 0;
    }

    public function addEnhancements(array $enhancements = [])
    {
    	foreach ($enhancements as $enhancement) {
			$enhancement->giveBonus($this);
			$this->enhancements[] = $enhancement;
		}
    }

    public function __toString()
    {
    	$output = "";
    	$output .= "--" . $this->getName() . ' - ' . basename(get_class($this)) . PHP_EOL;

    	if (!$this->isAlive()) {
    		$output .= "(Destroyed)";
    		return $output;
    	}

    	$output .= "-Location: " . $this->getStarSystem()->getName() . PHP_EOL;
    	$output .= "-Health: " . $this->getHealth() . PHP_EOL;
    	$output .= "-Shields: " . $this->getShields() . PHP_EOL;
    	$output .= "-Damage: " . $this->getAttack() . PHP_EOL;
    	$output .= "-Fuel: " . number_format($this->getFuel(), 1) . PHP_EOL;
    	$output .= "-Enhancements: ";
    	if (count($this->enhancements) == 0) {
    		$output .= "N/A" . PHP_EOL;
    	} else {
    		$output .= implode(" ", $this->enhancements) . PHP_EOL;
    	}

    	return $output;
    }
}

Class Frigate extends ShipAbstract
{
	const DEFAULT_HEALTH = 60;
	const DEFAULT_SHIELDS = 50;
	const DEFAULT_ATTACK = 30;
	const DEFAULT_FUEL = 220;

	protected $firedProjectiles;

	public function __construct($name, StarSystemInterface $starSystem, $enhancements = [])
	{
		parent::__construct(
			self::DEFAULT_HEALTH,
			self::DEFAULT_SHIELDS,
			self::DEFAULT_ATTACK,
			self::DEFAULT_FUEL,
			$name,
			$starSystems,
			$enhancements
		);
	}

	public function attack(ShipInterface $ship)
	{
		$this->fireProjectile()->attack($ship);
	}

	public function attackResponce(ProjectilesInterface $projectile)
	{
		$this->setHealth($this->getHealth() - $projectile->getAttack());
	}

	public function fireProjectile() : ProjectilesInterface
	{
		$this->firedProjectiles++;
		return new ShieldReaver($this->getAttack());
	}

	public function __toString()
	{
		$output = parent::__toString();
		if (!$this->isAlive()) {
			return $output;
		}

		$output .= "-Projectiles fired: " . $this->firedProjectiles . PHP_EOL;

		return $output;
	}
}

Class Cruiser extends ShipAbstract
{
	const DEFAULT_HEALTH = 100;
	const DEFAULT_SHIELDS = 100;
	const DEFAULT_ATTACK = 50;
	const DEFAULT_FUEL = 300;

	public function __construct($name, StarSystemInterface $starSystem, $enhancements = [])
	{
		parent::__construct(
			self::DEFAULT_HEALTH,
			self::DEFAULT_SHIELDS,
			self::DEFAULT_ATTACK,
			self::DEFAULT_FUEL,
			$name,
			$starSystems,
			$enhancements
		);
	}

	public function attack(ShipInterface $ship)
	{
		$this->fireProjectile()->attack($ship);
	}

	public function attackResponce(ProjectilesInterface $projectile)
	{
		$this->setHealth($this->getHealth() - $projectile->getAttack());
	}

	public function fireProjectile() : ProjectilesInterface
	{
		return new PenetrationShell($this->getAttack());
	}
}

Class Dreadnought extends ShipAbstract
{
	const DEFAULT_HEALTH = 200;
	const DEFAULT_SHIELDS = 300;
	const DEFAULT_ATTACK = 150;
	const DEFAULT_FUEL = 700;

	const RESPOND_ATTACK_SHIELD_BONUS = 50;

	public function __construct($name, StarSystemInterface $starSystem, $enhancements = [])
	{
		parent::__construct(
			self::DEFAULT_HEALTH,
			self::DEFAULT_SHIELDS,
			self::DEFAULT_ATTACK,
			self::DEFAULT_FUEL,
			$name,
			$starSystems,
			$enhancements
		);
	}

	public function attack(ShipInterface $ship)
	{
		$this->fireProjectile()->attack($ship);
	}

	public function attackResponce(ProjectilesInterface $projectile)
	{
		$this->setShields($this->getShields() + self::RESPOND_ATTACK_SHIELD_BONUS);
		$this->setHealth($this->getHealth() - $projectile->getAttack());
		$this->setShields($this->getShields() - $self::RESPOND_ATTACK_SHIELD_BONUS);
	}

	public function fireProjectile() : ProjectilesInterface
	{
		return new Laser((int)(($this->getShields() / 2) + $this->getAttack()));
	}
}

abstract class ProjectileAbstract implements ProjectilesInterface
{
	protected $damage;

	public function __construct($damage)
	{
		$this->damage = $damage;
	}
}

Class PenetrationShell implements ProjectileAbstract
{
	public function attack(ShipInterface $ship)
	{
		$ship->attackResponce($this);
	}

	public function getAttack() : int
	{
		return $this->damage;
	}
}

Class ShieldReaver implements ProjectileAbstract
{
	public function attack(ShipInterface $ship)
	{
		$ship->setShields($ship->getShields() - ($this->getAttack() * 2));
		$ship->attackResponce($this);
	}

	public function getAttack() : int
	{
		return $this->damage;
	}
}

Class Laser implements ProjectileAbstract
{
	public function attach(ShipInterface $ship)
	{
		$damage = $this->damage;
		$this->damage = max(0, $this->damage - $ship->getShields());
		$ship->attackResponce($this);
		$ship->setShields($ship->getShields() - $damage);
	}

	public function getAttack() : int
	{
		return $this->damage;
	}
}

Class Galaxy implements GalaxyInterface
{
	protected $starSystem = [];
	protected $ships = [];

	public function getStarSystem($name) : StarSystemInterface
	{
		return $this->starSystems[$name];
	}

	public function addStarSystem($name, StarSystemInterface $starSystem)
	{
		$this->starSystems[$name] = $starSystem;
	}

	public function shipExists($name): bool
	{
		return array_key_exists($name, $this->ships);
	}

	public function addShip(ShipInterface $ship)
	{
		$this->ships[$ship->getName()] = $ship;
	}

	public function getShip($name): ShipInterface
	{
		return $this->ships[$name];
	}
}

Class StarSystem implements StarSystemInterface
{
	protected $neighbours = [];
	protected $name;
	protected $ships = [];

	public function __construct($name)
	{
		$this->name = $name;
	}

	public function addNeighbour($solarSystemName, $fuelNeeded) : StarSystem
	{
		$this->neighbours[$solarSystemName] = $fuelNeeded;

		return $this;
	}

	public function getName()
	{
		return $this->name;
	}

	public function getShip($name) : ShipInterface
	{
		return $this->ships[$name];
	}

	public function addShip(ShipInterface $ship)
	{
		$name = $ship->getName();
		$this->ships[$name] = $ship;
	}

	public function travelTo($shipName, StarSystemInterface $starSystem)
	{
		$ship = $this->ships[$shipName];
		unset($this->ships[$shipName]);
		$fuelNeeded = $this->neighbours[$starSystem->getName()];
		$ship->setFuel($ship->getFuel() - $fuelNeeded);
		$ship->jumpTo($starSystem);
		$starSystem->addShip($ship);
	}
}

Class ThanixCannon implements EnhancementInterface
{
	const BONUS_ATTACK = 50;

	public function giveBonus(ShipInterface $ship)
	{
		$ship->setAttack($ship->getAttack() + self::BONUS_ATTACK);
	}
}

Class KinetiBarrier implements EnhancementInterface
{
	const BONUS_SHIELDS = 100;

	public function giveBonus(ShipInterface $ship)
	{
		$ship->setShields($ship->getShields() + self::BONUS_SHIELDS);
	}
}

Class ExtendedFuelCells implements EnhancementInterface
{
	const BONUS_FUEL = 200;

	public function giveBonus(ShipInterface $ship)
	{
		$ship->setFuel($ship->getFuel() + self::BONUS_FUEL);
	}
}

abstract class CommandAbstract implements Executable
{
	protected $galaxy;

	public function __construct(GalaxyInterface $galaxy)
	{
		$this->galaxy = $galaxy;
	}
}

Class CreateCommand extends CommandAbstract
{
	public function execute(array $args = []) : string
	{
		array_shift($args);
		$shipType = array_shift($args);
		$shipFullType = "Entites\\Ships\\" . $shipType;
		$shipName = array_shift($args);

		if ($this->galaxy->shipExists($shipName)) {
			throw new Exception("Ship with such name already exists");
		}

		$systemName = array_shift($args);
		$enhancements = [];
		foreach ($args as $enhancementName) {
			$fullName = "Entites\\Enhancements\\" . $enhancementName;
			$enhancement = new $fullName();
			$enhancements[] = $enhancement;
		}

		$starSystem = $this->galaxy->getStarSystem($systemName);
		$ship = new $shipFullType($shipName, $starSystem, $enhancements);

		$starSystem->addShip($ship);
		$this->galaxy->addShip($ship);

		return "Created {$shipType} {$shipName}";
	}
}

Class StatusReportCommand extends CommandAbstract
{
	public function execute(array $args = []) : string
	{
		array_shift($args);
		$shipName = array_shift($args);
		$ship = $this->galaxy->getShip($shipName);

		return $ship . "";
	}
}

Class AttackCommand extends CommandAbstract
{
	public function execute(array $args = []) : string
	{
		array_shift($args);
		$attackerName = array_shift($args);
		$defenderName = array_shift($args);

		$attacker = $this->galaxy->getShip($attackerName);
		$defender = $this->galaxy->getShip($defenderName);

		if (!$attacker->isAlive() || !$defender->isAlive()) {
			throw new Exception("No such ship in star system");
		}

		$attacker->attack($defender);

		$output = "{$attackerName} attacked {$defenderName}";

		if (!$defender->isAlive()) {
			$output .= PHP_EOL . "{$defenderName} has been destroyed";
		}

		return $output;
	}
}

Class PlotJumpCommand extends CommandAbstract
{
	public function execute(array $args = []) : string
	{
		array_shift($args);
		$shipName = array_shift($args);
		$starSystemName = array_shift($args);

		$starSystem = $this->galaxy->getStarSystem($starSystemName);
		$ship = $this->galaxy->getShip($shipName);

		if (!$ship->isAlive()) {
			throw new Exception("Ship is destroyed");
		}

		if ($ship->getStarSystem() == $starSystem) {
			throw new Exception("Ship is already in {$starSystemName}");
		}

		$oldSystem = $ship->getStarSystem();
		$oldSystem->travelTo($shipName, $starSystem);

		return "{$shipName} jumped from {$oldSystem->getName()} to {$starSystemName}";
	}
}

Class Game implements GalaxyInterface
{
	protected $galaxy;

	public function start()
	{
		$this->galaxy>addStarSystem(self::STAR_SYATEM_ARTEMIS_TAU, new StarSystem(self::STAR_SYATEM_ARTEMIS_TAU));
		$this->galaxy>addStarSystem(self::STAR_SYATEM_SERPENT_NEBULA, new StarSystem(self::STAR_SYATEM_SERPENT_NEBULA));
		$this->galaxy>addStarSystem(self::STAR_SYATEM_HADES_GAMMA, new StarSystem(self::STAR_SYATEM_HADES_GAMMA));
		$this->galaxy>addStarSystem(self::STAR_SYATEM_KEPLER_VERGE, new StarSystem(self::STAR_SYATEM_KEPLER_VERGE));

		$this->galaxy->getStarSystem(self::STAR_SYATEM_ARTEMIS_TAU)->addNeighbour(self::STAR_SYATEM_SERPENT_NEBULA, 50)->addNeighbour(self::STAR_SYATEM_KEPLER_VERGE, 120);

		$this->galaxy->getStarSystem(self::STAR_SYATEM_SERPENT_NEBULA)->addNeighbour(self::STAR_SYATEM_ARTEMIS_TAU, 50)->addNeighbour(self::STAR_SYATEM_HADES_GAMMA, 360);

		$this->galaxy->getStarSystem(self::STAR_SYATEM_HADES_GAMMA)->addNeighbour(self::STAR_SYATEM_SERPENT_NEBULA, 360)->addNeighbour(self::STAR_SYATEM_KEPLER_VERGE, 145);

		$this->galaxy->getStarSystem(self::STAR_SYATEM_KEPLER_VERGE)->addNeighbour(self::STAR_SYATEM_HADES_GAMMA, 145)->addNeighbour(self::STAR_SYATEM_ARTEMIS_TAU, 120);

		$commandString = trim(fgets(STDIN));

		while ($commandString != "over") {
			$tokens = explode(" ", $commandString);
			$cmd = $tokens[0];

			$cmd = preg_replace_callback("/-[a-z]/", function($m) use($cmd) {
				$match = $m[0];
				$char = $match[1];
				$upperChar = strtoupper($char);
				return $upperChar;
			}, $cmd);
			$cmd = ucfirst($cmd);
			$cmd = $cmd . "Command";
			$cmd = "Core\\Commands\\" . $cmd;
			$cmdInstance = new $cmd($this->galaxy);
			try {
				$result = $cmdInstance->execute($tokens);
				echo $result . PHP_EOL;
			} catch (Exception $e) {
				echo $e->getMessage() . PHP_EOL;
			}

			$commandString = trim(fgets(STDIN));
		}
	}
}

$game = new Game(new Galaxy());
$game->start();