using Microsoft.AspNetCore.Mvc;
using PJT_Inter.Data;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Controllers
{
    public class OsServController : Controller
    {
        public IActionResult Index(int id)
        {
            List<OsServ> a = new List<OsServ>();

            using (var data = new OsServData())
            {
                a = data.CarregaServicos(id);
                @ViewBag.id_Os = id;


                return View(a);
            }
        }
        public IActionResult Create(int id)
        {

            List<Servico> servicos = new List<Servico>();

            using (var data = new OsServData())
            {
                servicos = data.ServicosNaoExistente(id);
                ViewBag.Servicos = servicos;
                ViewBag.id_Os = id;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(int os, List<int> ser)
        {
            using (var data = new OsServData())
                data.Create(ser, os);

            return Redirect("/OsServ/Index/" + os);
        }
        public IActionResult Enviar(int id)
        {
            ViewBag.id_Os = id;
            return Redirect("/OsServ/Create/" + id);
        }


        public IActionResult Update(string P1, string P2)
        {
            
            ViewBag.servico_id = P2;
            ViewBag.os_id = P1;

             return View();
        }
        [HttpPost]
        public IActionResult Update(int servico_id, int os_id, int status)
        {
            OrdemServico os = new OrdemServico();


            using (var data = new OsServData())
            {
                data.Update(os_id, servico_id, status);    
            }

            return Redirect("/OsServ/Index/" + os_id);
        }
    }
}
