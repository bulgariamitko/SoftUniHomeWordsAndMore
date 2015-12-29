namespace MVCPattern.Core.Attributes.HttpRequestMethods
{
    public class HttpPostAttribute : HttpGetAttribute
    {
        public override bool isValid(string requestMethod)
        {
            return requestMethod.ToLower() == "post";
        }
    }
}