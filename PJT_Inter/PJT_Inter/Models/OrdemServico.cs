using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Models
{
    public class OrdemServico
    {
        // Os(id, data_abertura, data_termino, data_entrega, equipamento, status, total, #cliente_codigo, #funcionario_codigo, #tecnico_codigo)
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo cliente obrigatório")]
        public int Cliente_Codigo { get; set; }

        [Required(ErrorMessage = "Campo funcionario obrigatório")]
        public int Funcionario_Codigo { get; set; }

        public int Tecnico_Codigo { get; set; }

        [Display(Name = "Data da abertura")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo data abertura obrigatório")]
        public string Data_Abertura { get; set; }

        [Display(Name = "Data do termino")]
        [DataType(DataType.Date)]
        public string Data_Termino { get; set; }

        [Display(Name = "Data da entrega")]
        [DataType(DataType.Date)]
        public string Data_Entrega { get; set; }

        [Display(Name = "Descrição do equipamento")]
        [Required(ErrorMessage = "Campo equipamento obrigatório")]
        public string Equipamento { get; set; }

        [Display(Name = "Aberto/Aprovado/Finalizado/Cancelado")]
        [Required(ErrorMessage = "Campo status obrigatório")]
        public int Status { get; set; }

        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public decimal? Total { get; set; }

        public string nomeCliente { get; set; }

        public string nomeTecnico { get; set; }

        public string nomeFuncionario { get; set; }

        public string StatusNome { get; set; }

        public bool existeServ { get; set; }
    }
}
