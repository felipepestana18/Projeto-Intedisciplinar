using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PJT_Inter.Data;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult index()
        {
            using (var data = new FuncionarioData())
                return View(data.Read());
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return View(funcionario);
            }
            using (var data = new FuncionarioData())
                data.Create(funcionario);

            return RedirectToAction("Index");
        }
        public IActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new FuncionarioData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Funcionario funcionario)
        {
            funcionario.Pessoa_Codigo = id;
            if (funcionario.Senha == null)
            {
                FuncionarioData f = new FuncionarioData();
                funcionario.Senha = f.BuscaSenha(id);
                if (funcionario.Senha != "")
                {
                    using (var data = new FuncionarioData())
                        data.Update(funcionario);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(funcionario);
                }
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(funcionario);
                }

                using (var data = new FuncionarioData())
                    data.Update(funcionario);

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
        public IActionResult CreateLogin(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return View(funcionario);
            }
            using (var data = new FuncionarioData())
                data.Create(funcionario);

            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult Login(Funcionario funcionario)
        {
            if (funcionario.Email == null || funcionario.Senha == null)
            {
                return View("Login");
            }
            using (var data = new FuncionarioData())
                if (data.Login(funcionario.Email, funcionario.Senha))
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
            using (var data = new FuncionarioData())
                data.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
