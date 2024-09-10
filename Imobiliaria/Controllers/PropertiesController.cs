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

            var viewModel = new PropertyDetailsViewModel
            {
                Property = property,
                Contracts = contracts
            };

            return View(viewModel);
        }

        // Update
        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(int id) 
        {
            Console.WriteLine(id);
            return View();
        }

        // (using POST for simplicity in this case)
        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(Property model)
        {
            return View(model);
        }

        // Delete
        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Delete(int id) 
        {
            var property = _context.Properties.FirstOrDefault(_ => _.Id == id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult Delete(Property model) {
            _context.RemoveProperty(model.Id);

            return RedirectToAction("Index", "Home");
        }
    }
}
