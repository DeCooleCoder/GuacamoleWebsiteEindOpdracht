using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebsiteEindOpdracht.Models;
using MySql.Data;
using WebsiteEindOpdracht.Database;
using WebsiteEindOpdracht.DataBase;

namespace WebsiteEindOpdracht.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // alle producten ophalen
            var rows = DatabaseConnector.GetRows("select * from acteurs");
            var films = GetAllfilms();

            // lijst maken om alle namen in te stoppen
            List<string> names = new List<string>();

            foreach (var row in rows)
            {
                // elke naam toevoegen aan de lijst met namen
                names.Add(row["Acteur"].ToString());
            }

            // de lijst met namen in de html stoppen
            return View(films);
        }

        [Route("Films")]
        public IActionResult Films()
        {
            return View();
        }

        [Route("kidsfilms")]
        public IActionResult Kidsfilms()
        {
            return View();
        }

        [Route("Bioscopen")]
        public IActionResult Bioscopen()
        {
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Person person)
        {
            if (ModelState.IsValid)
                return Redirect("/succes");

            return View(person);
        }

        [Route("succes")]
        public IActionResult Succes()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<films> GetAllfilms()
        {
            // alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows("select * from films");

            // lijst maken om alle producten in te stoppen
            List<films> products = new List<films>();

            foreach (var row in rows)
            {
                // Voor elke rij maken we nu een product
                films p = new films();
                p.Naam = row["naam"].ToString();
                p.ReleaseDate = row["ReleaseDate"].ToString();
                p.Tijdsduur = row["Tijdsduur"].ToString();
                p.Genre = row["Genre"].ToString();

                // en dat product voegen we toe aan de lijst met producten
                products.Add(p);
            }

            return products;
        }
    }
}