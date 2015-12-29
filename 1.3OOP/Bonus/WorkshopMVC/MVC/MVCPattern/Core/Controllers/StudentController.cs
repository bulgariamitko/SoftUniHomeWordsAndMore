using MVCPattern.BindingModels;
using MVCPattern.Core.Attributes.HttpRequestMethods;
using MVCPattern.Core.Interfaces.Generic;
using MVCPattern.ViewModels;

namespace MVCPattern.Core.Controllers
{
    public class StudentController : Controller
    {
        [HttpPost]
        public IViewResult<StudentViewModel> Edit(int id, StudentBindingmodel bindingModel)
        {
            StudentViewModel viewModel = new StudentViewModel();
            viewModel.FullName = bindingModel.FirstName + " " + bindingModel.LastName;
            return View(viewModel);
        }
    }
}