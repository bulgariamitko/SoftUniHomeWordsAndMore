using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MVCPattern.BindingModels;
using MVCPattern.Controllers;
using MVCPattern.Core.Attributes.HttpRequestMethods;
using MVCPattern.Core.Controllers;
using MVCPattern.Core.Interfaces;

namespace MVCPattern.Core
{
    class StartUp
    {
        static void Main()
        {
            RegisterAssemblyName();
            RegisterControllers();
            RegesterViews();
            RegisterModels();

            while (true)
            {
                string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");

                string[] controllerActionParams = Environment.GetEnvironmentVariable("REQUEST_METHOD").Split('&');
                string[] controllerAction = controllerActionParams[0].Split('/');
                string controllerName = controllerAction[0];
                controllerName = (controllerName[0] + "").ToUpper() +
                                 controllerName.Substring(1, controllerName.Length - 1);
//                string[] actionAndParams = controllerActionParams[1].Split('=');
                string methodName = controllerAction[1];
                methodName = (methodName[0] + "").ToUpper() +
                                 methodName.Substring(1, methodName.Length - 1);

                Dictionary<string, object> getParams = new Dictionary<string, object>();
                Dictionary<string, object> postParams = new Dictionary<string, object>();

                if (controllerActionParams.Length >= 1)
                {
                    foreach (var pair in controllerActionParams)
                    {
                        string[] keyValue = pair.Split('=');
                        getParams.Add(keyValue[0], keyValue[1]);
                    }
                }

                string[] pairs = Console.ReadLine().Split('&');

                foreach (var pair in pairs)
                {
                    string[] keyValue = pair.Split('=');
                    postParams.Add(keyValue[0], keyValue[1]);
                }

                Controller controller =
                    (Controller)Activator.CreateInstance(
                        Type.GetType(MvcContext.Current.AssemblyName + "." + MvcContext.Current.ControllersFolder + "." +
                                     controllerName + MvcContext.Current.ControllersSuffix));
                IEnumerable<MethodInfo> methods = controller.GetType().GetMethods().Where(m => m.Name == methodName);

                MethodInfo method = null;
                foreach (MethodInfo methodInfo in methods)
                {
                    IEnumerable<Attribute> attributes =
                        methodInfo.GetCustomAttributes().Where(a => a is HttpMethodAttribute);

                    if (!attributes.Any())
                    {
                        method = methodInfo;
                        break;
                    }

                    foreach (HttpMethodAttribute attribute in attributes)
                    {
                        if (attribute.isValid(requestMethod))
                        {
                            method = methodInfo;
                            break;
                        }
                    }
                }

                if (method == null)
                {
                    throw new NotSupportedException("No such method!");
                }

                IEnumerable<ParameterInfo> parameters = method.GetParameters();

                object[] arguments = new object[parameters.Count()];
                int index = 0;
                foreach (ParameterInfo parameterInfo in parameters)
                {
                    if (parameterInfo.ParameterType.IsPrimitive)
                    {
                        object value = getParams[parameterInfo.Name];
                        arguments[index] = Convert.ChangeType(value, parameterInfo.ParameterType, null);
                        index++;
                    }
                    else
                    {
                        Type bindingModelType = parameterInfo.ParameterType;
                        object bindingModel = Activator.CreateInstance(parameterInfo.ParameterType);

                        IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

                        foreach (PropertyInfo property in properties)
                        {
                            property.SetValue(bindingModel, Convert.ChangeType(postParams[property.Name], property.PropertyType));
                        }
                        arguments[index] = Convert.ChangeType(bindingModel, bindingModelType);
                        index++;
                    }
                }

                IInvocable result = (IInvocable) method.Invoke(controller, arguments);
                result.Invoke();
            }
        }

        static void RegisterAssemblyName()
        {
            MvcContext.Current.AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        }

        static void RegisterControllers(string controllerSuffix = "Controller", string controllersFolder = "Controllers")
        {
            MvcContext.Current.ControllersFolder = controllersFolder;
            MvcContext.Current.ControllersSuffix = controllerSuffix;
        }

        static void RegesterViews(string viewsFolder = "Views")
        {
            MvcContext.Current.ViewFolder = viewsFolder;
        }

        static void RegisterModels(string modelsFolder = "Models")
        {
            MvcContext.Current.ModelsFolder = modelsFolder;
        }
    }
}
