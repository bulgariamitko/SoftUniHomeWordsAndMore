using System;
using Empires.Enums;
using Empires.Interfaces;
using Empires.Models;

namespace Empires.Core.Factories
{
    public class ResourceFactory : IResourceFactory
    {
        public IResource CreateResource(ResourceType resourceType, int quantity)
        {
            var resource = new Resource(resourceType, quantity);
            return resource;
        }
    }
}