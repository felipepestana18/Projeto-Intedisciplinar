using Microsoft.AspNetCore.Mvc;
using PJT_Inter.Data;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Controllers
{
    public class ServicoController : Controller
    {
        public IActionResult Index()
        {
            using (var data = new ServicoData())
                return View(data.Read());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Servico servico)
        {
            if (!ModelState.IsValid)
            {
                return View(servico);
            }
            using (var data = new ServicoData())
                data.Create(servico);

            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new ServicoData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Servico servico)
        {
            if (!ModelState.IsValid)
            {
                return View(servico);
            }

            using (var data = new ServicoData())
                data.Update(servico);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using (var data = new ServicoData())
                data.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
