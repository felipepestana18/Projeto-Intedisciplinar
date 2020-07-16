using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Data
{
    public class Data : IDisposable
    {
        // Atributo: vai nos permitir conectar com Banco de Dados
        protected SqlConnection connectionDB;

        public Data()
        {
            try
            {
                // autenticacao com a conta do SQL                
                string strConexao = @"Data Source = localhost;
                                      initial Catalog = OSinformatica;
                                      integrated Security = true;
                                      MultipleActiveResultSets=True;";

                connectionDB = new SqlConnection(strConexao);

                connectionDB.Open();
            }
            catch (SqlException er)
            {
                Console.WriteLine("Erro do Banco " + er);
            }
        }
        public void Dispose()
        {
            connectionDB.Close();
        }
    }
}
