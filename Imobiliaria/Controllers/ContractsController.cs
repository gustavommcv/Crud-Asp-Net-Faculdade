using Imobiliaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Controllers
{
    [Route("[controller]")]
    public class ContractsController : Controller
    {
        private readonly FakeDbContext _context;

        public ContractsController(FakeDbContext context)
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
        public IActionResult Create(Contract model)
        {
            if (ModelState.IsValid)
            {
                // Adds the new client to the context
                _context.AddContract(model);

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
            var contract = _context.Contracts.FirstOrDefault(x => x.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // Update
        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(int id)
        {
            var contract = _context.Contracts.FirstOrDefault(x => x.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(Contract model)
        {
            if (ModelState.IsValid)
            {
                var contract = _context.Contracts.FirstOrDefault(c => c.Id == model.Id);
                if (contract != null)
                {

                    contract.ContractState = model.ContractState;

                    return RedirectToAction("Details", new { id = contract.Id });
                }
                return NotFound();
            }
            return View(model);
        }

        // Delete
        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Delete(int id)
        {
            var contract = _context.Contracts.FirstOrDefault(_ => _.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult Delete(Contract model)
        {
            _context.RemoveContract(model.Id);

            return RedirectToAction("Index", "Home");
        }

    }
}
