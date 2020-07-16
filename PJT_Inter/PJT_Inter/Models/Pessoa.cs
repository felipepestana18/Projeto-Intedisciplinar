using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Models
{
    public class Pessoa
    {
        // Pessoas (codigo, nome, cpf_cnpj, endereço, telefone, email)
        public int Codigo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo nome obrigatório")]
        [MinLength(3)]
        public string Nome { get; set; }

        [Display(Name = "CPF ou CNPJ")]
        [Required(ErrorMessage = "Campo cpf ou cnpj obrigatório")]
        [MinLength(9)]
        public string CPF_CNPJ { get; set; }

        [Display(Name = "Endereco")]
        [Required(ErrorMessage = "Campo endereco obrigatório")]
        public string Endereco { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Campo telefone obrigatório")]
        public string Telefone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo e-mail obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
