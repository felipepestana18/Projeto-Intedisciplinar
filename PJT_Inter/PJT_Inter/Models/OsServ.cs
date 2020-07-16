using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Models
{
    public class OsServ
    {
        // os_serv_equip(#os_id, #sevico_id, valor, quantidade, status)

        [Display(Name = "Ordem de serviço")]
        [Required(ErrorMessage = "Campo ordem de serviço obrigatório")]
        public int Os_Id { get; set; }

        [Display(Name = "Serviço")]
        [Required(ErrorMessage = "Campo serviço obrigatório")]
        public int Servico_Id { get; set; }

        [Display(Name = "Em Andamento/Finalizado")]
        [Required(ErrorMessage = "Campo status obrigatório")]
        public int Status { get; set; }

        public string NomeServico { get; set; }

        public string statusNome { get; set; }

    }
}
