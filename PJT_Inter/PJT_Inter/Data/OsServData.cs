using Microsoft.Data.SqlClient;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Data
{
    public class OsServData : Data
    {
        public void Create(List<int> osServs, int os_id)
        {
			try
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = connectionDB;
				int Status = 1;
				cmd.CommandText = @"cadOs_Serv @os_id, @servico_id, @status";
			   
				foreach (var osServ in osServs)
				{
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@os_id", os_id);
					cmd.Parameters.AddWithValue("@servico_id", osServ);         
					cmd.Parameters.AddWithValue("@status", Status);
					cmd.ExecuteNonQuery();
				}
			}
			catch
			{
			}
        }
        public List<OsServ> Read()
        {
            List<OsServ> lista = new List<OsServ>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM v_Os_Serv";

            // o objeto reader receberá os dados da tabela cliente, quando executado
            // o comando SELECT (resultado do select)
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // percorrendo a tabela até EOF (end of file)
            {

                // os_serv_equip(#os_id, #sevico_id, #equipamento_id, total, quantidade, status)
                OsServ OsSevEq = new OsServ();
                OsSevEq.Os_Id = (int)reader["OS"];
                OsSevEq.Servico_Id = (int)reader["Serv"];
                OsSevEq.Status = (int)reader["Status"];
                lista.Add(OsSevEq);
            }
            return lista;
        }
        public List<Servico> ServicosNaoExistente(int id)
        {
            List<Servico> lista = new List<Servico>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "select * from v_Servico s where Id_Servico not in (select p.Servico_id from v_Os_Serv p where p.OS =  @id and p.Status = 1)";
            cmd.Parameters.AddWithValue("@id", id);
            // o objeto reader receberá os dados da tabela cliente, quando executado
            // o comando SELECT (resultado do select)
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // percorrendo a tabela até EOF (end of file)
            {
                Servico servico = new Servico();
                servico.Id = (int)reader["Numero"];
                servico.Nome = (string)reader["Servico"];
                servico.Descricao = (string)reader["Descricao"];
                servico.ID_Servico = (int)reader["ID_Servico"];
                servico.Valor = (decimal)reader["Valor"];
                servico.Status = (int)reader["Status"];
                if (servico.Status == 1)
                {
                    servico.StatusNome = "Ativo";
                }
                else
                {
                    servico.StatusNome = "Inativo";
                }
                lista.Add(servico);
            }
            return lista;
        }
        public List<OsServ> Read(int id)
        {
            List<OsServ> lista = new List<OsServ>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM v_EditarOsServ where os_id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // percorrendo a tabela até EOF (end of file)
            {
                OrdemServico ordemServico = new OrdemServico();
                OsServ OsSevEq = new OsServ();
                OsSevEq.Os_Id = (int)reader["os_id"];
                OsSevEq.Servico_Id = (int)reader["idServico"];
                OsSevEq.NomeServico = (string)reader["Servico"];
                ordemServico.existeServ = true;

            }
            return lista;
        }
        public List<OsServ> CarregaServicos(int id)
        {
            List<OsServ> lista = new List<OsServ>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "select * from v_Os_Serv where os = @id order by Status";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // percorrendo a tabela até EOF (end of file)
            {
                OrdemServico ordemServico = new OrdemServico();
                OsServ oss = new OsServ();
                oss.Os_Id = (int)reader["Os"];
                oss.Servico_Id = (int)reader["Servico_id"];
                oss.NomeServico = (string)reader["Servico"];
                oss.Status = (int)reader["Status"];
                switch (oss.Status)
                {
                    case 1:
                        oss.statusNome = "Aguardando Confirmação";
                        break;
                    case 2:
                        oss.statusNome = "Em Andamento";
                        break;
                    case 3:
                        oss.statusNome = "Finalizado";
                        break;
                    case 4:
                        oss.statusNome = "Cancelado";
                        break;
                }
                lista.Add(oss);
            }
            return lista;
        }

        public void Update(int os, int servico_id, int status)
        {
            int idOs = os;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
           


            cmd.CommandText = @"altOs_Serv @os_id, @servico_id, @status";
            cmd.Parameters.AddWithValue("@os_id", os);
            cmd.Parameters.AddWithValue("@servico_id", servico_id);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();

            if (status == 2)
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = connectionDB;
                cmd1.CommandText = "select s.valor from servicos s where s.id = @id";
                cmd1.Parameters.AddWithValue("@id", servico_id);
                
                SqlDataReader reader = cmd1.ExecuteReader();
                decimal a = 0;
                decimal b = 0;
                if (reader.Read())
                {
                    a = reader["Valor"] != DBNull.Value ? (decimal)reader["Valor"] : 0;
                }
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = connectionDB;
                cmd2.CommandText = "select o.total from os o where o.id = @id";
                cmd2.Parameters.AddWithValue("@id", idOs);

                SqlDataReader reader1 = cmd2.ExecuteReader();

                if (reader1.Read())
                {
                    b = reader1["Total"] != DBNull.Value ? (decimal)reader1["Total"] : 0;
                }
                decimal c = (a + b);
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = connectionDB;
                cmd3.CommandText = "update os set total = @total where id = @id";
                cmd3.Parameters.AddWithValue("@total", c);
                cmd3.Parameters.AddWithValue("@id", idOs);
                cmd3.ExecuteNonQuery();
            }

        }
    }
}
