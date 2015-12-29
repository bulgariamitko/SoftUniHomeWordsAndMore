using MVCPattern.BindingModels;
using MVCPattern.Core.Attributes.HttpRequestMethods;
using MVCPattern.Core.Controllers;
using MVCPattern.Core.Interfaces;

namespace MVCPattern.Controllers
{

    public class HomeController : Controller
    {

        [HttpPost]
        public IViewResult Index(int id, IndexBindingModel model)
        {
            return View();
        }

//        [HttpPost]
//        public IViewResult Index(int id)
//        {
//            return View();
//        }
    }
}