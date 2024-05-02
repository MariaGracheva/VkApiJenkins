using RestSharp;

namespace Framework.Extensions
{
    public static class RequestExtensions
    {
        public static RestRequest AddParameters(this RestRequest request, Dictionary<string, string> parameters)
        {
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }

            return request;
        }
    }
}