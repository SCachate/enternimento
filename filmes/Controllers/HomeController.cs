using filmes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace filmes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<SugestoesModel> model = new List<SugestoesModel>();
            using (var client = new HttpClient())
            {                
                client.BaseAddress = new Uri("https://api.themoviedb.org/");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIzZjM5ZTk5Y2U1ZWFlYmRjMWY4NzM4ZTE0OWFkNDY4YyIsIm5iZiI6MTczNjM0Mzk2Mi44OTEsInN1YiI6IjY3N2U4MTlhMjE4ZmQ1N2FjZjRlNjZmNSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.RrTn4u_NUnuFsJU6foiUWkB9bHoldSbaJBmwimokRsg");

                var response = client.GetAsync("3/discover/movie?include_adult=false&include_video=false&language=pt-BR&page=1&primary_release_year=2025&sort_by=popularity.desc").Result;
                if (response.IsSuccessStatusCode)
                {

                    var sugestoes = response.Content.ReadAsStringAsync().Result;
                    dynamic intermediario = JsonConvert.DeserializeObject(sugestoes)!;

                    if (intermediario != null)
                    {
                        foreach (var result in intermediario.results)
                        {
                            var item = new SugestoesModel()
                            {
                                backdrop_path = result.backdrop_path,
                                original_language = result.original_language,
                                original_title = result.original_title,
                                overview = result.overview,
                                popularity = result.popularity,
                                poster_path = result.poster_path,
                                release_date = result.release_date,
                                title = result.title,
                                vote_average = result.vote_average,
                                vote_count = result.vote_count
                            };
                            model.Add(item);
                        }
                    }
                }                
            }
            return View(model.Take(10));
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
