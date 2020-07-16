using Microsoft.Data.SqlClient;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Data
{
    public class ClienteData : Data
    {
        public int Create(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"cadCliente @nome, @cpf_cnpj, @endereco, @telefone, @email, @Status";
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf_cnpj", cliente.CPF_CNPJ);
            cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@email", cliente.Email);
            cmd.Parameters.AddWithValue("@Status", cliente.Status);
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = connectionDB;
            cmd1.CommandText = @"select c.Codigo as id 
                                from v_Cliente c
                                where CPF_CNPJ = @CPF_CNPJ";
            cmd1.Parameters.AddWithValue("@CPF_CNPJ", cliente.CPF_CNPJ);
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                return (int)reader["id"];
            }
            return 0;
        }

        public List<Cliente> Read()
        {
            List<Cliente> lista = new List<Cliente>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM v_Cliente order by Status, Cliente";

            // o objeto reader receberá os dados da tabela cliente, quando executado
            // o comando SELECT (resultado do select)
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // percorrendo a tabela até EOF (end of file)
            {
                Cliente cliente = new Cliente();
                cliente.Pessoa_Codigo = (int)reader["Codigo"];
                cliente.Nome = (string)reader["Cliente"];
                cliente.CPF_CNPJ = (string)reader["CPF_CNPJ"];
                cliente.Endereco = (string)reader["Endereco"];
                cliente.Telefone = (string)reader["Telefone"];
                cliente.Email = (string)reader["Email"];
                cliente.Status = (int)reader["Status"];

                if (cliente.Status == 1)
                {
                    cliente.StatusNome = "Ativo";
                }
                else
                {
                    cliente.StatusNome = "Inativo";
                }
                lista.Add(cliente);
            }
            return lista;
        }

        public Cliente Read(int codigo)
        {
            Cliente cliente = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select *
                                from v_Cliente
                                where codigo = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            // Executando o comando SQL no bando de dados
            SqlDataReader reader = cmd.ExecuteReader();

            // verificando se, após a consulta, retornou um registro
            if (reader.Read())
            {
                cliente = new Cliente();
                cliente.Pessoa_Codigo = (int)reader["Codigo"];
                cliente.Nome = (string)reader["Cliente"];
                cliente.CPF_CNPJ = (string)reader["Cpf_Cnpj"];
                cliente.Endereco = (string)reader["Endereco"];
                cliente.Telefone = (string)reader["Telefone"];
                cliente.Email = (string)reader["Email"];
                cliente.Status = (int)reader["Status"];
                if (cliente.Status == 1)
                {
                    cliente.StatusNome = "Ativo";
                }
                else
                {
                    cliente.StatusNome = "Inativo";
                }
            }
            // retornando o objeto cliente, que pode ser null ou com as informações recebidas na consulta
            return cliente;
        }

        public List<Cliente> BuscarClientes(string nome)
        {
            List<Cliente> lista = new List<Cliente>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM v_Cliente WHERE Status = 1";
            //cmd.Parameters.AddWithValue("@nome", nome);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Codigo = (int)reader["Codigo"];
                cliente.Nome = (string)reader["Cliente"];
                lista.Add(cliente);
            }
            return lista;
        }

        public Cliente BuscarClientes(int id)
        {
            Cliente cliente = new Cliente();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "SELECT * FROM v_Cliente WHERE Status = 1 and Codigo = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cliente.Codigo = (int)reader["Codigo"];
                cliente.Nome = (string)reader["Cliente"];
                return cliente;
            }
            return cliente;
        }
        public void Update(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"altCliente @codigo, @nome, @cpf_cnpj, @endereco, @telefone, @email, @Status";
            cmd.Parameters.AddWithValue("@codigo", cliente.Pessoa_Codigo);
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CPF_CNPJ", cliente.CPF_CNPJ);
            cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@email", cliente.Email);
            cmd.Parameters.AddWithValue("@status", cliente.Status);
            cmd.ExecuteNonQuery();
        }
        public void Delete(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"UPDATE clientes
                                SET status = @Status
                                WHERE pessoa_codigo = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@status", 2);
            cmd.ExecuteNonQuery();
        }
    }
}
