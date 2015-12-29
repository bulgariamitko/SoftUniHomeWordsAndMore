using System;

namespace MVCPattern.Core.Attributes.HttpRequestMethods
{
    [AttributeUsage(AttributeTargets.All)]
    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool isValid(string requestMethod);
    }
}