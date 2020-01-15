using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Landon.Models;

namespace Landon.Web.Controllers
{
    public class CountriesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000")
            })
            {
                var json = await httpClient.GetStringAsync("Countries");
                var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
                return View(countries);
            }
        }

        public async Task<IActionResult> Detail(string id)
        {
            using (var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000")
            })
            {
                var json = await httpClient.GetStringAsync("Countries/" + id);
                var countries = JsonConvert.DeserializeObject<Country>(json);
                return View(countries);
            }
        }
    }
}