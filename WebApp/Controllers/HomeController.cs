using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApp.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _Configure;
        private readonly HttpClient _httpClient;
        private readonly string? apiBaseUrl;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, HttpClient httpClient)
        {
            _logger = logger;
            _Configure = configuration;
            _httpClient = httpClient;
            apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
        }


        // TO READ JSON DATA AND DISPLAY THE PRODUCT OBJECTS IN THE INDEX PAGE
        // WebAPIBaseUrl in the apiBaseUrl is created in appsettings.json file. It contains the product URL in JSON format.
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiBaseUrl);
            Stream contentStream = await response.Content.ReadAsStreamAsync();

            // To use JSON Deserialize, the optimal environment is created
            // unfortunately, the data cannot be displayed on Index page. 
            using (var streamReader = new StreamReader(contentStream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Product> product = serializer.Deserialize<List<Product>>(jsonReader);

                // Pass the List<Person> object to the view
                return View(product);
            }

        }

    }
}

