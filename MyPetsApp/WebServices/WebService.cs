using System.Net.Http;

namespace MyPetsApp.WebServices
{
    public abstract class WebService
    {
        protected WebService(string baseUrl)
        {
            BaseUrl = "http://localhost:5000/api/" + baseUrl + "/";
            Api = new HttpClient();
        }

        protected readonly string BaseUrl;
        protected readonly HttpClient Api;
    }
}