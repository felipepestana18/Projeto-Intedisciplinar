using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Models
{
    public class Funcionario : Pessoa
    {
        // Funcionarios (#Pessoa_codigo, senha, salario, status)
        public int Pessoa_Codigo { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo senha obrigatório")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Senha { get; set; }

        [Display(Name = "Salario")]
        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }

        [Display(Name = "Ativo ou Inativo")]
        [Required(ErrorMessage = "Campo status obrigatório")]
        public int Status { get; set; }

        public string StatusNome { get; set; }
    }
}
