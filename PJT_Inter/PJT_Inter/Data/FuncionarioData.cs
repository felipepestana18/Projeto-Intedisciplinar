using Microsoft.Data.SqlClient;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Data
{
    public class FuncionarioData : Data
    {
        public void Create(Funcionario funcionario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"cadFuncionario @nome, @cpf_cnpj, @endereco, @telefone, @email, @senha, @salario, @status";
            cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
            cmd.Parameters.AddWithValue("@cpf_cnpj", funcionario.CPF_CNPJ);
            cmd.Parameters.AddWithValue("@endereco", funcionario.Endereco);
            cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
            cmd.Parameters.AddWithValue("@email", funcionario.Email);
            cmd.Parameters.AddWithValue("@senha", funcionario.Senha);
            cmd.Parameters.AddWithValue("@salario", funcionario.Salario);
            cmd.Parameters.AddWithValue("@status", funcionario.Status);
            cmd.ExecuteNonQuery();
        }
        public List<Funcionario> Read()
        {
            List<Funcionario> lista = new List<Funcionario>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM v_Funcionario order by Status, Funcionario";

            // o objeto reader receberá os dados da tabela cliente, quando executado
            // o comando SELECT (resultado do select)
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // percorrendo a tabela até EOF (end of file)
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Codigo = (int)reader["Codigo"];
                funcionario.Nome = (string)reader["Funcionario"];
                funcionario.CPF_CNPJ = (string)reader["CPF_CNPJ"];
                funcionario.Endereco = (string)reader["Endereco"];
                funcionario.Telefone = (string)reader["Telefone"];
                funcionario.Email = (string)reader["Email"];
                funcionario.Senha = (string)reader["Senha"];
                funcionario.Salario = (decimal)reader["Salario"];
                funcionario.Status = (int)reader["Status"];
                if (funcionario.Status == 1)
                {
                    funcionario.StatusNome = "Ativo";
                }
                else
                {
                    funcionario.StatusNome = "Inativo";
                }
                lista.Add(funcionario);
            }
            return lista;
        }
        public Funcionario Read(int codigo)
        {
            Funcionario funcionario = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select *
                                from v_Funcionario
                                where Codigo = @Codigo";
            cmd.Parameters.AddWithValue("@Codigo", codigo);

            // Executando o comando SQL no bando de dados
            SqlDataReader reader = cmd.ExecuteReader();

            // verificando se, após a consulta, retornou um registro
            if (reader.Read())
            {
                funcionario = new Funcionario();
                funcionario.Codigo = (int)reader["Codigo"];
                funcionario.Nome = (string)reader["Funcionario"];
                funcionario.CPF_CNPJ = (string)reader["CPF_CNPJ"];
                funcionario.Endereco = (string)reader["Endereco"];
                funcionario.Telefone = (string)reader["Telefone"];
                funcionario.Email = (string)reader["Email"];
                funcionario.Senha = (string)reader["Senha"];
                funcionario.Salario = (decimal)reader["Salario"];
                funcionario.Status = (int)reader["Status"];
                if (funcionario.Status == 1)
                {
                    funcionario.StatusNome = "Ativo";
                }
                else
                {
                    funcionario.StatusNome = "Inativo";
                }
            }
            // retornando o objeto cliente, que pode ser null ou com as informações recebidas na consulta
            return funcionario;
        }
        public string BuscaSenha(int codigo)
        {
            string senha = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select Senha
                                from v_Funcionario
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
            cmd.CommandText = @"SELECT *
                                FROM v_Funcionario
                                WHERE Email = @Email and Senha = @Senha";
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Senha", senha);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return true;
            }
            return false;
        }
        public void Update(Funcionario funcionario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"altFuncionario @codigo, @nome, @cpf_cnpj, @endereco, @telefone, @email, @senha, @salario, @status";
            cmd.Parameters.AddWithValue("@codigo", funcionario.Pessoa_Codigo);
            cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
            cmd.Parameters.AddWithValue("@cpf_cnpj", funcionario.CPF_CNPJ);
            cmd.Parameters.AddWithValue("@endereco", funcionario.Endereco);
            cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
            cmd.Parameters.AddWithValue("@email", funcionario.Email);
            cmd.Parameters.AddWithValue("@senha", funcionario.Senha);
            cmd.Parameters.AddWithValue("@salario", funcionario.Salario);
            cmd.Parameters.AddWithValue("@status", funcionario.Status);
            cmd.ExecuteNonQuery();
        }
        public List<Funcionario> BuscarFuncionarios(string nome)
        {
            List<Funcionario> lista = new List<Funcionario>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM v_Funcionario WHERE Status = 1";
            //cmd.Parameters.AddWithValue("@nome", nome);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Codigo = (int)reader["Codigo"];
                funcionario.Nome = (string)reader["Funcionario"];
                lista.Add(funcionario);
            }
            return lista;
        }
        public void Delete(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"UPDATE funcionarios
                                SET status = @Status
                                WHERE pessoa_codigo = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@status", 2);
            cmd.ExecuteNonQuery();
        }
    }
}
