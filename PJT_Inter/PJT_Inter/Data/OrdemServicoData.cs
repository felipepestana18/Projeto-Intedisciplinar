using Microsoft.Data.SqlClient;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Data
{
    public class OrdemServicoData : Data
    {
        string data;
        public void Create(OrdemServico os)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"cadOs @equipamento, @data_abertura, @data_termino, @data_entrega, @status, @total, @cliente_codigo, @funcionario_codigo, @tecnico_codigo";
            cmd.Parameters.AddWithValue("@equipamento", os.Equipamento);
            cmd.Parameters.AddWithValue("@data_abertura", os.Data_Abertura);
            cmd.Parameters.AddWithValue("@data_termino", os.Data_Termino).Value = DBNull.Value;
            cmd.Parameters.AddWithValue("@data_entrega", os.Data_Entrega).Value = DBNull.Value;
            cmd.Parameters.AddWithValue("@status", os.Status);
            cmd.Parameters.AddWithValue("@total", os.Total = 0);
            cmd.Parameters.AddWithValue("@cliente_codigo", os.Cliente_Codigo);
            cmd.Parameters.AddWithValue("@funcionario_codigo", os.Funcionario_Codigo);
            cmd.Parameters.AddWithValue("@tecnico_codigo", os.Tecnico_Codigo);
            cmd.ExecuteNonQuery();
        }
        public List<OrdemServico> Read()
        {
            List<OrdemServico> lista = new List<OrdemServico>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM v_Os order by Status asc, Abertura desc";

            // o objeto reader receberá os dados da tabela cliente, quando executado
            // o comando SELECT (resultado do select)
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // percorrendo a tabela até EOF (end of file)
            {
                OrdemServico os = new OrdemServico();
                os.Id = (int)reader["Numero"];
                os.Data_Abertura = reader["Abertura"].ToString().Substring(0, 10);
                os.Data_Termino = reader["Termino"] != DBNull.Value ? os.Data_Termino = reader["Termino"].ToString().Substring(0, 10) : "";
                os.Data_Entrega = reader["Entrega"] != DBNull.Value ? os.Data_Entrega = reader["Entrega"].ToString().Substring(0, 10) : "";
                os.Equipamento = (string)reader["Equipamento"];
                os.Status = (int)reader["Status"];
                os.Total = reader["Total"] != DBNull.Value ? (decimal)reader["Total"] : 0;
                os.nomeCliente = (string)reader["Cliente"];
                os.nomeFuncionario = (string)reader["Funcionario"];                         
                os.Cliente_Codigo = (int)reader["CliCodigo"];
                os.Funcionario_Codigo = (int)reader["FunCodigo"];
                if(reader["TecCodigo"] != DBNull.Value)
                {
                    os.Tecnico_Codigo = (int)reader["TecCodigo"];
                    os.nomeTecnico = NomeTecnico(os.Tecnico_Codigo);
                }
                else
                {
                    os.Tecnico_Codigo = 0;
                }
                lista.Add(os);

                switch (os.Status)
                {
                    case 1:
                        os.StatusNome = "Aberto";
                        break;
                    case 2:
                        os.StatusNome = "Aprovado";
                        break;
                    case 3:
                        os.StatusNome = "Finalizado";
                        break;
                    case 4:
                        os.StatusNome = "Cancelado";
                        break;
                }
            }
            return lista;
        }
        public OrdemServico Read(int id)
        {
            OrdemServico os = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select *	                                   
                                from v_Os
                                where Numero = @id";
            cmd.Parameters.AddWithValue("@id", id);

            // Executando o comando SQL no bando de dados
            SqlDataReader reader = cmd.ExecuteReader();

            // verificando se, após a consulta, retornou um registro
            if (reader.Read())
            {
                // instanciando o objeto cliente declarado anteriormente
                // e colocando os dados do registro na tabela no objeto
                os = new OrdemServico();
                os.Id = (int)reader["Numero"];
                os.Data_Abertura = reader["Abertura"].ToString().Substring(0, 10);
                data = os.Data_Abertura;
                os.Data_Termino = reader["Termino"] != DBNull.Value ? os.Data_Termino = reader["Termino"].ToString().Substring(0, 10) : "";
                os.Data_Entrega = reader["Entrega"] != DBNull.Value ? os.Data_Entrega = reader["Entrega"].ToString().Substring(0, 10) : "";
                os.Equipamento = (string)reader["Equipamento"];
                os.Status = (int)reader["Status"];
                os.Total = reader["Total"] != DBNull.Value ? (decimal)reader["Total"] : 0;
                os.nomeCliente = (string)reader["Cliente"];
                os.nomeFuncionario = (string)reader["Funcionario"];                
                os.Cliente_Codigo = (int)reader["CliCodigo"];
                os.Funcionario_Codigo = (int)reader["FunCodigo"];
                if (reader["TecCodigo"] != DBNull.Value)
                {
                    os.Tecnico_Codigo = (int)reader["TecCodigo"];
                    os.nomeTecnico = NomeTecnico(os.Tecnico_Codigo);
                }
                else
                {
                    os.Tecnico_Codigo = 0;
                }

                switch (os.Status)
                {
                    case 1:
                        os.StatusNome = "Aberto";
                        break;
                    case 2:
                        os.StatusNome = "Aprovado";
                        break;
                    case 3:
                        os.StatusNome = "Finalizado";
                        break;
                    case 4:
                        os.StatusNome = "Cancelado";
                        break;
                }
            }
            // retornando o objeto cliente, que pode ser null ou com as informações
            // recebidas na consulta
            return os;
        }

        public string NomeTecnico(int id)
        {
            string nome = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select Tecnico	                                   
                                from v_Os_ComTecnico
                                where Numero = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                nome = (string)reader["Tecnico"];
                return nome;
            }
            return nome;
        }

        public List<OsServ> ExisteOk(int id)
        {
            List<OsServ> lista = new List<OsServ>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM  v_ExisteServico where os_id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // percorrendo a tabela até EOF (end of file)
            {

                // os_serv_equip(#os_id, #sevico_id, #equipamento_id, total, quantidade, status)
                OrdemServico ordemServico = new OrdemServico();
                OsServ OsSevEq = new OsServ();
                OsSevEq.Os_Id = (int)reader["os_id"];
                OsSevEq.Servico_Id = (int)reader["servico_id"];
                ordemServico.existeServ = true;
                lista.Add(OsSevEq);
            }
            return lista;
        }
        public string BuscarDatas(int id)
        {
            OrdemServico os = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select data_abertura from os o where  id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) // percorrendo a tabela até EOF (end of file)
            {
                os = new OrdemServico();
                return os.Data_Abertura = reader["data_abertura"].ToString();
            }
            return "";
        }
        public void Update(OrdemServico os)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"altOs @id, @equipamento, @data_abertura, @data_termino, @data_entrega, @status, @total, @cliente_codigo, @funcionario_codigo, @tecnico_codigo";
            cmd.Parameters.AddWithValue("@id", os.Id);
            cmd.Parameters.AddWithValue("@equipamento", os.Equipamento);
            cmd.Parameters.AddWithValue("@data_abertura", os.Data_Abertura);
            cmd.Parameters.AddWithValue("@data_termino", os.Data_Termino).Value = os.Data_Termino == null ? (object)DBNull.Value : os.Data_Termino;
            cmd.Parameters.AddWithValue("@data_entrega", os.Data_Entrega).Value = os.Data_Entrega == null ? (object)DBNull.Value : os.Data_Entrega;
            cmd.Parameters.AddWithValue("@status", os.Status);
            cmd.Parameters.AddWithValue("@total", os.Total);
            cmd.Parameters.AddWithValue("@cliente_codigo", os.Cliente_Codigo);
            cmd.Parameters.AddWithValue("@funcionario_codigo", os.Funcionario_Codigo);
            cmd.Parameters.AddWithValue("@tecnico_codigo", os.Tecnico_Codigo).Value = os.Tecnico_Codigo == 0 ? (object)DBNull.Value : os.Tecnico_Codigo;
            cmd.ExecuteNonQuery();
        }
    }
}
