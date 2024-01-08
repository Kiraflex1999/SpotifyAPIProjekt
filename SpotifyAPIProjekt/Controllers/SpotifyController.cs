using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SpotifyAPIProjekt.Models;
using System.Diagnostics;
using System.Text;
using System.Web;

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
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("expiresAt")) || DateTime.Compare(Convert.ToDateTime(HttpContext.Session.GetString("expiresAt")), DateTime.Now) > 0)
            {
                var options = new RestClientOptions("https://accounts.spotify.com")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/authorize", Method.Get)
                    .AddParameter("client_id", "bb457095cedf43b4ad05b1b1956f50b8")
                    .AddParameter("response_type", "code")
                    .AddParameter("redirect_uri", "http://localhost:5100/spotify/auth")
                    .AddParameter("scope", "user-read-email user-read-private")
                    .AddParameter("show_dialog", "true")
                    .AddParameter("state", "state");
                return new RedirectResult(client.BuildUri(request).ToString());
            }
            else
            {
                return View("Auth");
            }
        }

        public IActionResult Auth(string code) 
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(_ClientId + ":" + _ClientSecret);
            string base64String = Convert.ToBase64String(plainBytes);

#if DEBUG
            Console.WriteLine(base64String);
            Console.WriteLine();
#endif

            var options = new RestClientOptions("https://accounts.spotify.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/token", Method.Post)
                .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                .AddHeader("Authorization", "Basic " + base64String)
                .AddParameter("grant_type", "authorization_code")
                .AddParameter("code", code)
                .AddParameter("redirect_uri", "http://localhost:5100/spotify/auth");
            RestResponse response = client.ExecuteAsync(request).Result;

#if DEBUG
            Console.WriteLine(response.Content);
            Console.WriteLine();
#endif

            AuthModel authModel = JsonConvert.DeserializeObject<AuthModel>(response.Content);

            HttpContext.Session.SetString("accessToken", authModel.AccessToken);
            HttpContext.Session.SetString("expiresAt", DateTime.Now.AddSeconds(authModel.ExpiresIn).ToString());

            return View(authModel);
        }

        public IActionResult Profile()
        {
            var options = new RestClientOptions("https://api.spotify.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/v1/me", Method.Get)
                .AddHeader("Authorization", "Bearer " + HttpContext.Session.GetString("accessToken"));
            RestResponse response = client.ExecuteAsync(request).Result;

#if DEBUG
            Console.WriteLine(HttpContext.Session.GetString("accessToken"));
            Console.WriteLine();
            Console.WriteLine(response.Content);
            Console.WriteLine();
#endif

            ProfileModel profileModel = JsonConvert.DeserializeObject<ProfileModel>(response.Content);

            return View(profileModel);
        }
    }
}