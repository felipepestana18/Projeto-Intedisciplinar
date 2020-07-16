using Microsoft.Data.SqlClient;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Data
{
    public class ServicoData : Data
    {
        public void Create(Servico servico)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"cadServico @nome, @descricao, @valor, @status";
            cmd.Parameters.AddWithValue("@nome", servico.Nome);
            cmd.Parameters.AddWithValue("@descricao", servico.Descricao);
            cmd.Parameters.AddWithValue("@valor", servico.Valor);
            cmd.Parameters.AddWithValue("@status", servico.Status);
            cmd.ExecuteNonQuery();
        }
        public List<Servico> Read()
        {
            List<Servico> lista = new List<Servico>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM v_Servico order by Status, Servico";

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
        public Servico Read(int id)
        {
            Servico servico = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select *
                                from v_Servico
                                where Numero = @Numero";
            cmd.Parameters.AddWithValue("@Numero", id);

            // Executando o comando SQL no bando de dados
            SqlDataReader reader = cmd.ExecuteReader();

            // verificando se, após a consulta, retornou um registro
            if (reader.Read())
            {
                // instanciando o objeto cliente declarado anteriormente
                // e colocando os dados do registro na tabela no objeto
                servico = new Servico();
                servico.Id = (int)reader["Numero"];
                servico.Nome = (string)reader["Servico"];
                
                servico.Descricao = (string)reader["Descricao"];
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
            }

            // retornando o objeto cliente, que pode ser null ou com as informações recebidas na consulta
            return servico;
        }

        public List<Servico> ReadLista(int id)
        {
    
            List<Servico> ListaServicos  = new List<Servico>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select *
                                from v_Servico
                                where Numero = @Numero";
            cmd.Parameters.AddWithValue("@Numero", id);

            // Executando o comando SQL no bando de dados
            SqlDataReader reader = cmd.ExecuteReader();

            // verificando se, após a consulta, retornou um registro
            if (reader.Read())
            {
                // instanciando o objeto cliente declarado anteriormente
                // e colocando os dados do registro na tabela no objeto
                Servico servico = new Servico();
                servico = new Servico();
                servico.Id = (int)reader["Numero"];
                servico.Nome = (string)reader["Servico"];
                servico.ID_Servico = (int)reader["ID_Servico"];
                servico.Descricao = (string)reader["Descricao"];
                servico.Valor = (decimal)reader["Valor"];
                servico.Status = (int)reader["Status"];

                ListaServicos.Add(servico);
                
                if (servico.Status == 1)
                {
                    servico.StatusNome = "Ativo";
                }
                else
                {
                    servico.StatusNome = "Inativo";
                }
            }

            // retornando o objeto cliente, que pode ser null ou com as informações recebidas na consulta
            return ListaServicos;
        }
        public void Update(Servico servico)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"altServico @id, @nome, @descricao, @valor, @status";
            cmd.Parameters.AddWithValue("@id", servico.Id);
            cmd.Parameters.AddWithValue("@nome", servico.Nome);
            cmd.Parameters.AddWithValue("@descricao", servico.Descricao);
            cmd.Parameters.AddWithValue("@valor", servico.Valor);
            cmd.Parameters.AddWithValue("@status", servico.Status);
            cmd.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"UPDATE servicos 
                                SET status = @Status 
                                WHERE id = @Id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@status", 2);

            cmd.ExecuteNonQuery();
        }
    }
}
