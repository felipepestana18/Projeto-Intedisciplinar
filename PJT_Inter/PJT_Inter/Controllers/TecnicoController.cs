using Microsoft.AspNetCore.Mvc;
using PJT_Inter.Data;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Controllers
{
    public class TecnicoController : Controller
    {
        public IActionResult Index()
        {
            using (var data = new TecnicoData())
                return View(data.Read());
        }  
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tecnico tecnico)
        {
            if (!ModelState.IsValid)
            {
                return View(tecnico);
            }
            using (var data = new TecnicoData())
                data.Create(tecnico);

            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new TecnicoData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Tecnico tecnico)
        {
            tecnico.Pessoa_Codigo = id;
            if(tecnico.Senha == null)
            {
                TecnicoData t = new TecnicoData();
                tecnico.Senha = t.BuscaSenha(id);
                if (tecnico.Senha != "")
                {
                    using (var data = new TecnicoData())
                        data.Update(tecnico);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(tecnico);
                }
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(tecnico);
                }

                using (var data = new TecnicoData())
                    data.Update(tecnico);

                return RedirectToAction("Index");
            }          
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CreateLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Tecnico tecnico)
        {
            if (tecnico.Email == null || tecnico.Senha == null)
            {
                return View("Login");
            }
            using (var data = new TecnicoData())
                if (data.Login(tecnico.Email, tecnico.Senha))
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.Mensagem = "Email ou senha inválida";
                    return View("Login");
                }
        }

        public IActionResult Delete(int id)
        {
            using (var data = new TecnicoData())
                data.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
