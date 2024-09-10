using Imobiliaria.Models;
using Imobiliaria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Controllers
{
    [Route("[controller]")]
    public class PropertiesController : Controller
    {
        private readonly FakeDbContext _context;

        public PropertiesController(FakeDbContext context) 
        {
            _context = context;
        }

        // Create
        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(Property model) {
            if (ModelState.IsValid) {
                // Adds the new client to the context
                _context.AddProperty(model);

                // Redirects to customer list or home page after success
                return RedirectToAction("Index", "Home");
            }

            // If the model is not valid, it returns to the creation view with the current data
            return View(model);
        }

            // Update
        public IActionResult Edit() 
        {
            return View();
        }

        // Delete
        public IActionResult Delete() 
        {
            return RedirectToAction("Index");
        }

        // Read
        [Route("[action]/{id:int}")]
        public IActionResult Details(int id) 
        {
            var property = _context.Properties.FirstOrDefault(p => p.Id == id);
            if (property == null)
            {
                return NotFound();
            }

            var contracts = _context.Contracts.Where(p => p.Id == id).ToList();

            var viewModel = new PropertyDetailsViewModel {
                Property = property,
                Contracts = contracts
            };

            Console.WriteLine(viewModel.Property.ToString());

            return View(viewModel);
        }
    }
}
