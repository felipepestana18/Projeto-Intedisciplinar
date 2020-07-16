using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Models
{
    public class Servico
    {
        // Servicos(id, nome, descricao, valor, status)
        public int Id { get; set; }

        [Display(Name = "Nome do serviço")]
        [Required(ErrorMessage = "Campo nome obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Descricao do serviço")]
        [Required(ErrorMessage = "Campo Descricao obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Valor do serviço")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Display(Name = "Ativo ou Inativo")]
        [Required(ErrorMessage = "Campo status obrigatório")]
        public int Status { get; set; }

        public string StatusNome { get; set; }

        public int ID_Servico { get; set; }

    }
}
