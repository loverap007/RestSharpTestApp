using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RestSharpTestApp.Data;
using RestSharpTestApp.Models;


namespace RestSharpTestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ImageContext _db;

        public HomeController(ImageContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetFaceParams(string url)
        {
            var client = new RestClient("https://api-us.faceplusplus.com");
            var request = new RestRequest("facepp/v3/detect", Method.POST);
            request.AddObject(new
            {
                api_key = "5kALua9FccHMwgH2vihMjZOnBD-erlPf",
                api_secret = "-ETSjm3nYQyq0sS3GOjXwvYFaa056wZO",
                image_url = url,
                return_landmark = 1,
                return_attributes = "gender,age"
            });
            IRestResponse response = client.Execute(request);




            _db.Images.Add(new Image
            {
                Url = url
            });
            return Content(response.Content);
        }
    }
}
