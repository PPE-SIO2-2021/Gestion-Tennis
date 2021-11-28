using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_convo_Tennis.Classes;

namespace Gestion_de_convo_Tennis.Classes
{
   public class Ado
    {
        static SqlConnection connection;
        public static SqlConnection OpenSqlConnection()
        {
            string connectionString = GetConnectionString();
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            Console.WriteLine("State: {0}", connection.State);
            Console.WriteLine("ConnectionString: {0}", connection.ConnectionString);
            return connection;
        }
        public static void CloseSqlConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        static private string GetConnectionString()
        {
            return "Data Source=LAPTOP-IH3M9RRL;Initial Catalog=bd_tsatgd;Integrated Security=True";
        }
        public static void CleanUp() 
        {
            AdoRencontre.delete();
            AdoJournee.delete();
            AdoEquipe.delete();
            AdoJoueur.delete();
        }
    }
}
