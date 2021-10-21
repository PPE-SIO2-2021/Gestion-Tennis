using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_convo_Tennis.Classes;

namespace Gestion_de_convo_Tennis.Classes
{
    class AdoEquipe
    {
        public static List<Equipe> all()
        {
            List<Equipe> classements = new List<Equipe>();
            SqlCommand requete = new SqlCommand("SELECT * FROM equipe");
            requete.Connection = Ado.OpenSqlConnection();
            SqlDataReader  reader = requete.ExecuteReader(); // Exécution de la requête SQL
            while (reader.Read())
            {
                 classements.Add(new Equipe(reader.GetBoolean(1),reader.GetInt32(2)));
            }
            reader.Close();
            return classements;
            
     
            
        }
    }
}
