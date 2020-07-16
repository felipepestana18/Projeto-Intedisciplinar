using Microsoft.Data.SqlClient;
using PJT_Inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJT_Inter.Data
{
    public class HomeData : Data
    {
        public List<Home> Read()
        {
            List<Home> lista = new List<Home>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = "select * from v_Dashboard";

            // o objeto reader receberá os dados da tabela cliente, quando executado
            // o comando SELECT (resultado do select)
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // percorrendo a tabela até EOF (end of file)
            {
                Home h = new Home();

                h.tabela =  (string)reader["Tabela"];

                h.linha = Convert.ToInt32(reader["Linhas"]);

                lista.Add(h);
            }
            return lista;
        }

    }
}
