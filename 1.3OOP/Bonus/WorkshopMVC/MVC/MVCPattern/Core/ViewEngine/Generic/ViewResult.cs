using System;
using MVCPattern.Core.Interfaces.Generic;

namespace MVCPattern.Core.ViewEngine.Generic
{
    public class ViewResult<T> : IViewResult<T>
    {
        public ViewResult(string viewFullQualifedName, T model)
        {
            this.Action = (IRenderable<T>)Activator.CreateInstance(Type.GetType(viewFullQualifedName));
            this.Action.Model = model;
        }

        public void Invoke()
        {
            this.Action.Render();
        }

        public IRenderable<T> Action { get; set; }
    }
}