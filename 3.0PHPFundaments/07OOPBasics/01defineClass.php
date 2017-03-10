<?php 

class Person
{
    public $name;
    public $age;

}

$pesho = new Person();
$gosho = new Person();
$stamat = new Person();

$pesho->name = 'Pesho';
$pesho->age = 20;
$gosho->name = 'Gosho';
$gosho->age = 18;
$stamat->name = 'Stamat';
$stamat->age = 43;

echo(count(get_object_vars($pesho)));