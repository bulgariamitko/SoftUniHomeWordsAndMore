using System;

namespace MVCPattern.Core.Attributes.HttpRequestMethods
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool isValid(string requestMethod)
        {
            return requestMethod.ToLower() == "get";
        }
    }
}