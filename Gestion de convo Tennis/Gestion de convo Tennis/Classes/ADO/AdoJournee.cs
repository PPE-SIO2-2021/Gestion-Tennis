using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_convo_Tennis.Classes;

namespace Gestion_de_convo_Tennis.Classes
{
    class AdoJournee
    {
        public static List<Journee> all()
        {
            List<Journee> classements = new List<Journee>();
            SqlCommand requete = new SqlCommand("SELECT * FROM journee");
            requete.Connection = Ado.OpenSqlConnection();
            SqlDataReader  reader = requete.ExecuteReader(); // Exécution de la requête SQL
            while (reader.Read())
            {
                 classements.Add(new Journee(reader.GetInt32(0),reader.GetInt32(2))); // à modifier
            }
            reader.Close();
            return classements;
            
     
            
        }
    }
}
