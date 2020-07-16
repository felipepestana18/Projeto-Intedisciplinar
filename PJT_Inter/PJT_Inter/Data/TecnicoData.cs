using Microsoft.Data.SqlClient;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Data
{
    public class TecnicoData : Data
    {
        public void Create(Tecnico tecnico)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"cadTecnico @nome, @cpf_cnpj, @endereco, @telefone, @email, @salario, @comissao, @senha, @status";
            cmd.Parameters.AddWithValue("@nome", tecnico.Nome);
            cmd.Parameters.AddWithValue("@cpf_cnpj", tecnico.CPF_CNPJ);
            cmd.Parameters.AddWithValue("@endereco", tecnico.Endereco);
            cmd.Parameters.AddWithValue("@telefone", tecnico.Telefone);
            cmd.Parameters.AddWithValue("@email", tecnico.Email);
            cmd.Parameters.AddWithValue("@salario", tecnico.Salario);
            cmd.Parameters.AddWithValue("@comissao", tecnico.Comissao);
            cmd.Parameters.AddWithValue("@senha", tecnico.Senha);
            cmd.Parameters.AddWithValue("@status", tecnico.Status);
            cmd.ExecuteNonQuery();
        }
        public List<Tecnico> Read()
        {
            List<Tecnico> lista = new List<Tecnico>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM v_Tecnico order by Status, Tecnico";

            // o objeto reader receberá os dados da tabela cliente, quando executado
            // o comando SELECT (resultado do select)
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // percorrendo a tabela até EOF (end of file)
            {
                Tecnico tecnico = new Tecnico();
                tecnico.Codigo = (int)reader["Codigo"];
                tecnico.Nome = (string)reader["Tecnico"];
                tecnico.CPF_CNPJ = (string)reader["CPF_CNPJ"];
                tecnico.Endereco = (string)reader["Endereco"];
                tecnico.Telefone = (string)reader["Telefone"];
                tecnico.Email = (string)reader["Email"];
                tecnico.Salario = (decimal)reader["Salario"];
                tecnico.Comissao = (decimal)reader["Comissao"];
                tecnico.Senha = (string)reader["Senha"];
                tecnico.Status = (int)reader["Status"];
                if (tecnico.Status == 1)
                {
                    tecnico.StatusNome = "Ativo";
                }
                else
                {
                    tecnico.StatusNome = "Inativo";
                }
                lista.Add(tecnico);
            }
            return lista;
        }
        public Tecnico Read(int codigo)
        {
            Tecnico tecnico = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select *
                                from v_Tecnico
                                where codigo = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            // Executando o comando SQL no bando de dados
            SqlDataReader reader = cmd.ExecuteReader();

            // verificando se, após a consulta, retornou um registro
            if (reader.Read())
            {
                tecnico = new Tecnico();
                tecnico.Codigo = (int)reader["Codigo"];
                tecnico.Nome = (string)reader["Tecnico"];
                tecnico.CPF_CNPJ = (string)reader["CPF_CNPJ"];
                tecnico.Endereco = (string)reader["Endereco"];
                tecnico.Telefone = (string)reader["Telefone"];
                tecnico.Email = (string)reader["Email"];
                tecnico.Salario = (decimal)reader["Salario"];
                tecnico.Comissao = (decimal)reader["Comissao"];
                tecnico.Senha = (string)reader["Senha"];
                tecnico.Status = (int)reader["Status"];
                if (tecnico.Status == 1)
                {
                    tecnico.StatusNome = "Ativo";
                }
                else
                {
                    tecnico.StatusNome = "Inativo";
                }
            }

            // retornando o objeto cliente, que pode ser null ou com as informações recebidas na consulta
            return tecnico;
        }
        public List<Tecnico> BuscarTecnicos(string nome)
        {
            List<Tecnico> lista = new List<Tecnico>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM v_Tecnico WHERE Status = 1";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tecnico cliente = new Tecnico();
                cliente.Codigo = (int)reader["Codigo"];
                cliente.Nome = (string)reader["Tecnico"];
                lista.Add(cliente);
            }
            return lista;
        }
        public string BuscaSenha(int codigo)
        {
            string senha = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select Senha
                                from v_Tecnico
                                where codigo = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                senha = (string)reader["Senha"].ToString();
                return senha;
            }
            return senha;
        }
        public bool Login(string email, string senha)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select *
                                from v_Tecnico
                                where Email = @Email and Senha = @Senha";
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Senha", senha);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            return false;
        }
        public void Update(Tecnico tecnico)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"altTecnico @codigo, @nome, @cpf, @endereco, @telefone, @email, @salario, @comissao, @senha, @status";
            cmd.Parameters.AddWithValue("@codigo", tecnico.Pessoa_Codigo);
            cmd.Parameters.AddWithValue("@nome", tecnico.Nome);
            cmd.Parameters.AddWithValue("@cpf", tecnico.CPF_CNPJ);
            cmd.Parameters.AddWithValue("@endereco", tecnico.Endereco);
            cmd.Parameters.AddWithValue("@telefone", tecnico.Telefone);
            cmd.Parameters.AddWithValue("@email", tecnico.Email);
            cmd.Parameters.AddWithValue("@salario", tecnico.Salario);
            cmd.Parameters.AddWithValue("@comissao", tecnico.Comissao);
            cmd.Parameters.AddWithValue("@senha", tecnico.Senha);
            cmd.Parameters.AddWithValue("@status", tecnico.Status);
            cmd.ExecuteNonQuery();
        }
        public void Delete(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"UPDATE tecnicos 
                                SET status = @Status 
                                WHERE pessoa_codigo = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@status", 2);
            cmd.ExecuteNonQuery();
        }
    }
}
