using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SpotifyAPIProjekt.Models;

namespace SpotifyAPIProjekt.Controllers
{
    public class SpotifyController : Controller
    {
        private readonly protected string _ClientId = "bb457095cedf43b4ad05b1b1956f50b8";
        private readonly protected string _ClientSecret = "ab285ecc47ba4e008a2a72e797a3c567";

        private readonly ILogger<SpotifyController> _Logger;
        private readonly IHttpContextAccessor _Contx;

        public SpotifyController(ILogger<SpotifyController> logger, IHttpContextAccessor contx)
        {
            _Logger = logger;
            _Contx = contx;
        }

        public IActionResult Index()
        {
            var options = new RestClientOptions("https://accounts.spotify.com")
            {
                MaxTimeout = -1, 
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/token?grant_type=client_credentials&client_id="+_ClientId+"&client_secret="+_ClientSecret, Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "__Host-device_id=AQA5svwtKloABOVYGVQjm2lbOyZfFEv8CG8UzB9cx9NnT1Njq6CJsBGEmgGzTEoP3exaZkLOr0BkD-juRQJ1yxH4_Q2P6_s8hPQ");
            RestResponse response = client.ExecuteAsync(request).Result;
            //Console.WriteLine(response.Content);

            AuthModel authModel = JsonConvert.DeserializeObject<AuthModel>(response.Content);

            //Save to Session

            string sessionString = JsonConvert.SerializeObject(authModel);
            _Contx.HttpContext.Session.SetString("SpotifySession", sessionString); // Save Objekt as String

            return View("Auth", authModel);
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
