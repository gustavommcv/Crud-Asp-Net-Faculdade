﻿using Imobiliaria.Models;
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

        // Create
        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // Read
        [Route("[action]/{id:int}")]
        public IActionResult Details(int id)
        {

            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // Update
        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(int id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // (using POST for simplicity in this case)
        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(Client model)
        {
            if (ModelState.IsValid)
            {
                var client = _context.Clients.FirstOrDefault(c => c.Id == model.Id);
                if (client != null)
                {
                    client.FirstName = model.FirstName;
                    client.LastName = model.LastName;
                    client.Email = model.Email;

                    return RedirectToAction("Details", new { id = client.Id });
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
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }


        // Delete (POST)
        [HttpPost]
        [Route("[action]/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            return RedirectToAction("Index", "Home");
        }

    }
}
