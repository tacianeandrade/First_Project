using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Metodos;

namespace Metodos
{
    public class BDHendler

    {
        // Atributos
        private const string _connectionString = @"Data Source=DESKTOP-SRU6BAD\SQLEXPRESS;Initial Catalog=northwind;Integrated Security=True";
        // propriedades
        public string connectionString
        {
            get => _connectionString;
        }

        // metodos
        public SqlConnection LigarBD()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);

            try
            {
                Console.WriteLine("A ligar...");

                conn.Open();

                return conn;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public void DesligarBd(SqlConnection conn)
        {
            try
            {
                Console.WriteLine("A desligar...");

                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
