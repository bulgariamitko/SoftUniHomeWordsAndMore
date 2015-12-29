using System;
using EnvironmentSystem.Interfaces;
using EnvironmentSystem.Models.Objects;

namespace EnvironmentSystem.Core
{
    public class AdvancedEngine : Engine
    {
        private IController controller;
        private bool isPaused;

        public AdvancedEngine(IController controller, int worldWidth, int worldHeight, IObjectGenerator<EnvironmentObject> objectGenerator, ICollisionHandler collisionHandler, IRenderer renderer) : base(worldWidth, worldHeight, objectGenerator, collisionHandler, renderer)
        {
            this.controller = controller;
            this.AttachControllerEvents();
        }

        private void AttachControllerEvents()
        {
            controller.Pause += controller_Pause;
        }

        private void controller_Pause(object sender, EventArgs e)
        {
            isPaused = !isPaused;
        }

        protected override void ExecuteEnvironmentLoop()
        {
            controller.ProcessInput();
            if (!isPaused)
            {
                base.ExecuteEnvironmentLoop();
            }
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Object cannot be null");
            }
            base.Insert(obj);
        }
    }
}