using System.Reflection.Metadata.Ecma335;

namespace WebApplicationJWT.Intruder
{
    public class MakeRequest
    {
        public string[] makeRequest()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7195/AuthenticationTest");

            string[] array = new string[] { };
            return array;
        }
    }
}
