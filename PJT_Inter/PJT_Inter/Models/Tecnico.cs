using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Models
{
    public class Tecnico : Pessoa
    {
        // Tecnicos (#Pessoa_codigo, salario, comissao, senha, status)
        public int Pessoa_Codigo { get; set; }

        [Display(Name = "Salario")]
        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }

        [Display(Name = "Comissao")]
        [DataType(DataType.Currency)]
        public decimal Comissao { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo senha obrigatório")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Senha { get; set; }

        [Display(Name = "Ativo ou inativo")]
        [Required(ErrorMessage = "Campo status obrigatório")]
        public int Status { get; set; }

        public string StatusNome { get; set; }
    }
}
