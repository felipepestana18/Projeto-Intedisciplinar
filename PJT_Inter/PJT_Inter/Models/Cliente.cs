using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Models
{
    public class Cliente : Pessoa
    {
        // Clientes(#Pessoa_codigo, status)
        public int Pessoa_Codigo { get; set; }

        [Display(Name = "Ativo ou inativo")]
        [Required(ErrorMessage = "Campo status obrigatório")]
        public int Status { get; set; }

        public string StatusNome { get; set; }
    }
}
