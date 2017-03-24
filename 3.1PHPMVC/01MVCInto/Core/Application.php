<?php

namespace Core;

use ReflectionMethod;
use Core\Exceptions\FormValidationException;
use Core\Http\Components\Request\RequestInterface;
use Core\Http\Components\Session\SessionInterface;

Class Application
{
	protected $mvcContext;
	protected $dependencies;
	protected $resolveDependencies;
	protected $request;
	protected $session;

	public function __construct(MVCContextInterface $mvcContext, RequestInterface $request, SessionInterface $session)
	{
		$this->mvcContext = $mvcContext;
		$this->dependencies = [];
		$this->resolveDependencies = [];
		$this->request = $request;
		$this->session = $session;
	}

	public function start()
	{
		$controllerFullName = $this->mvcContext->getControllerFullName();
		$methodName = $this->mvcContext->getAction();
		$uriParts = $this->mvcContext->getArgs();

		$controller = new $controllerFullName();
		$refM = new \ReflectionMethod($controller, $methodName);

		foreach ($refM->getParameters() as $parameter) {
			if ($parameter->getClass() == null) {
				continue;
			}
			$className = $parameter->getClass()->getName();
			if (array_key_exists($className, $this->dependencies)) {
				$obj = $this->tryInstantiateDependency($className);
			} else {
				$obj = new $className();
				$this->mapFormData($_POST, $obj);
			}
			$position = $parameter->getPosition();
			$inserted = [$obj];
			array_splice($uriParts, $position, 0, $inserted);
		}

		call_user_func_array([$controller, $methodName], $uriParts);
	}

	public function addDependency($abstraction, $implementation)
	{
		$this->dependencies[$abstraction] = $implementation;
	}

	public function addResolveDependency($abstraction, $object)
	{
		$this->resolveDependencies[$abstraction] = $object;
		$implementationClassName = get_class($object);
		$this->addDependency($abstraction, $implementationClassName);
	}

	public function resolve($className)
	{
		$classInfo = new \ReflectionClass($className);
		$constructor = $classInfo->getConstructor();
		if ($constructor == null) {
			return new $className();
		}

		$parameters = $constructor->getParameters();
		$instantiatedParameters = [];
		foreach ($parameters as $parameter) {
			$parameterInterfaceName = $parameter->getClass()->getName();
			$parameterInstance = $this->tryInstantiateDependency($parameterInterfaceName);
			$this->addResolveDependency($parameterInterfaceName, $parameterInstance);
			$instantiatedParameters[] = $parameterInstance;
		}
		$this->addResolveDependency($parameterInterfaceName, $parameterInstance);
		$instance = $classInfo->newInstanceArgs($instantiatedParameters);

		return $instance;
	}

	public function mapFormData($formData, $bindingModel)
	{
		$classInfo = new \ReflectionClass($bindingModel);
		foreach ($formData as $paramName => $value) {
			try {
				$property = $classInfo->getProperty($paramName);
			} catch (\ReflectionException $e){
				continue;
			}

			$propertyName = $property->getName();
			if (substr($propertyName, 0, 2) == 'is' && ctype_upper($propertyName[2])) {
				$propertyName = substr($propertyName, 2);
			}
			$setterMethod = 'set' . ucfirst($propertyName);
			if (method_exists($bindingModel, $setterMethod)) {
				try {
					$bindingModel->$setterMethod($value);
				} catch (FormValidationException $e) {
					$this->session->addMessage('error', $e->getMessage());
					header("Location: " . $this->request->getReferer());
					exit;
				}
			} else {
				$property->setAccessible(true);
				$property->setValue($bindingModel, $value);
			}
		}
	}

	protected function tryInstantiateDependency($className)
	{
		if (array_key_exists($className, $this->resolveDependencies)) {
			return $this->resolveDependencies[$className];
		}
		$implementation = $this->dependencies[$className];
		return $this->resolve($implementation);
	}
}