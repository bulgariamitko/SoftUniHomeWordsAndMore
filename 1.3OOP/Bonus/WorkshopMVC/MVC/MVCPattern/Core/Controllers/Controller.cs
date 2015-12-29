using System;
using System.Runtime.CompilerServices;
using MVCPattern.Core.Interfaces;
using MVCPattern.Core.Interfaces.Generic;
using MVCPattern.Core.ViewEngine;
using MVCPattern.Core.ViewEngine.Generic;

namespace MVCPattern.Core.Controllers
{
    public class Controller
    {
        protected IViewResult View([CallerMemberName] string callee = "")
        {
            string contollerName = this.GetType().Name.Replace("Controller", "");
            string fullQualifedName = MvcContext.Current.AssemblyName + "." + MvcContext.Current.ViewFolder + "." +
                                      contollerName + "." + callee;
            return new ViewResult(fullQualifedName);
        }

        protected IViewResult View(string controller, string action)
        {
            string fullQualifedName = MvcContext.Current.AssemblyName + "." + MvcContext.Current.ViewFolder + "." +
                                     controller + "." + action;
            return new ViewResult(fullQualifedName);
        }

        protected IViewResult<T> View<T>(T model, [CallerMemberName] string callee = "")
        {
            string contollerName = this.GetType().Name.Replace("Controller", "");
            string fullQualifedName = MvcContext.Current.AssemblyName + "." + MvcContext.Current.ViewFolder + "." +
                                      contollerName + "." + callee;
            return new ViewResult<T>(fullQualifedName, model);
        }

        protected IViewResult<T> View<T>(T model, string controller, string action)
        {
            string fullQualifedName = MvcContext.Current.AssemblyName + "." + MvcContext.Current.ViewFolder + "." +
                                      controller + "." + action;
            return new ViewResult<T>(fullQualifedName, model);
        } 
    }
}