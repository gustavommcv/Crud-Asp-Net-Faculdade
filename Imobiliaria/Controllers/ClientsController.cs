using Imobiliaria.Models;
using Imobiliaria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Controllers
{
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        private readonly FakeDbContext _context;

        public ClientsController(FakeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("[action]/{id:int}")]
        public IActionResult Details(int id)
        {

            var client = _context.Clients.FirstOrDefault(c => c.Id == id);

            foreach (var item in client.Properties)
            {
                Console.WriteLine(item);
            }

            return View(client);
        }
    }
}
