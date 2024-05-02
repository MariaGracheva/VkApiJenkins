using Framework.Extensions;
using RestSharp;

namespace Framework.Factories
{
    public static class RequestFactory
    {
        public static RestRequest CreateRequest(string method, Dictionary<string, string> parameters)
        {
            var request = new RestRequest(method);
            request.AddParameters(parameters);
            return request;
        }

        public static RestRequest CreateRequest()
        {
            return new RestRequest();
        }
    }
}