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
            return View();
        }

        public IActionResult Auth() 
        {
            var options = new RestClientOptions("https://accounts.spotify.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/authorize?client_id=bb457095cedf43b4ad05b1b1956f50b8&response_type=code&redirect_uri=http://localhost:5100/spotify&state=state&scope=user-read-email user-read-private&show_dialog=true", Method.Get);
            request.AddHeader("Cookie", "__Host-device_id=AQA5svwtKloABOVYGVQjm2lbOyZfFEv8CG8UzB9cx9NnT1Njq6CJsBGEmgGzTEoP3exaZkLOr0BkD-juRQJ1yxH4_Q2P6_s8hPQ; __Host-sp_csrf_sid=b7c837b883e8b53a9ad9904d56f7781f918dc2b04e6a5d794bac2ebe3dc7b9c9; __Secure-TPASESSION=AQC4uqa4aDE4TwBWX8YlLof9GBjhzuUpxGQz6xzTiJ8n8qo05lY4m7xz++KepNN0j2lIjA/nSyWgAhl49mW5XIjrSGwHbDuHfvw=; inapptestgroup=; sp_sso_csrf_token=013acda719296f10b80f43740c05cffba22ef4dcb331373032393033333337303437; sp_tr=false");
            RestResponse response = client.ExecuteAsync(request).Result;
            Console.WriteLine(response.Content);

            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
