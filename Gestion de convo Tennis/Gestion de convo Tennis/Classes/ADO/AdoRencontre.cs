using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_convo_Tennis.Classes;

namespace Gestion_de_convo_Tennis.Classes
{
    class AdoRencontre
    {
        public static List<Rencontre> all()
        {
            List<Rencontre> classements = new List<Rencontre>();
            SqlCommand requete = new SqlCommand("SELECT * FROM rencontre");
            requete.Connection = Ado.OpenSqlConnection();
            SqlDataReader  reader = requete.ExecuteReader(); // Exécution de la requête SQL
            while (reader.Read())
            {
                 classements.Add(new Rencontre(reader.GetInt32(0),reader.GetInt32(2))); // à modifier
            }
            reader.Close();
            return classements;
            
     
            
        }
    }
}
