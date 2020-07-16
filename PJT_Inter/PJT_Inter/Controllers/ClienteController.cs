using Microsoft.AspNetCore.Mvc;
using PJT_Inter.Data;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            using (var data = new ClienteData())
                return View(data.Read());

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            using (var data = new ClienteData()) {
                data.Create(cliente);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            using (var data = new ClienteData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Cliente cliente)
        {
            cliente.Pessoa_Codigo = id;
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            using (var data = new ClienteData())
                data.Update(cliente);

            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            using (var data = new ClienteData())
                data.Delete(id);

            return RedirectToAction("Index");
        }
        public IActionResult Teste()
        {
            return View();
        }
    }
}
