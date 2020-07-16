using Microsoft.AspNetCore.Mvc;
using PJT_Inter.Data;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Controllers
{
    public class OrdemServicoController : Controller
    {
        public IActionResult Index()
        {
            using (var data = new OrdemServicoData())
                return View(data.Read());
        }

        public IActionResult Enviar(int id)
        {
            ViewBag.id_Os = id;
            return Redirect("/OsServ/Index/" + id);
        }


        public IActionResult Verificar(int id)
        {
            List<OsServ> oserv = new List<OsServ>();

            using (var data = new OrdemServicoData())
            {
                oserv = data.ExisteOk(id);
                if (oserv.Count() != 0)
                {
                    return Redirect("/OsServ/Update/" + id);
                }
                else
                {
                    return Redirect("/OsServ/Create/" + id);
                }
            }
        }
        public IActionResult Create(int id)
        {
            List<Cliente> clientes = new List<Cliente>();
            List<Tecnico> tecnicos = new List<Tecnico>();
            List<Funcionario> funcionarios = new List<Funcionario>();

            OrdemServico os = new OrdemServico();
            os.Cliente_Codigo = id;
            using (var data = new ClienteData())
            {
                clientes = data.BuscarClientes("");
                ViewBag.Clientes = clientes;

                var dataTec = new TecnicoData();
                tecnicos = dataTec.BuscarTecnicos("");
                ViewBag.Tecnicos = tecnicos;

                var dataFun = new FuncionarioData();
                funcionarios = dataFun.BuscarFuncionarios("");
                ViewBag.Funcionarios = funcionarios;

           
            }
            return View(os);
        }

        [HttpPost]
        public IActionResult Create(OrdemServico os)
        {
            using (var data = new OrdemServicoData())
                data.Create(os);

            return Redirect("/OrdemServico/Index");
        }

        public IActionResult Update(int id)
        {
            List<Tecnico> tecnicos = new List<Tecnico>();
            var dataTec = new TecnicoData();
            tecnicos = dataTec.BuscarTecnicos("");
            ViewBag.Tecnicos = tecnicos;

            using (var data = new OrdemServicoData())
                return View(data.Read(id));
        }
        [HttpPost]
        public IActionResult Update(int id, OrdemServico servico)
        {
            OrdemServico os = new OrdemServico();


            using (var data = new OrdemServicoData())
            {
                servico.Data_Abertura = data.BuscarDatas(id);
                data.Update(servico);
            }

            return RedirectToAction("Index");
        }
    }
}
