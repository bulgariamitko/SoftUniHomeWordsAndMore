using System;
using MVCPattern.Core.Interfaces;

namespace MVCPattern.Core.ViewEngine
{
    public class ViewResult : IViewResult
    {
        public ViewResult(string viewFullQualifedName)
        {
            this.Action = (IRenderable) Activator.CreateInstance(Type.GetType(viewFullQualifedName));
        }

        public void Invoke()
        {
            this.Action.Render();
        }

        public IRenderable Action { get; set; }
    }
}