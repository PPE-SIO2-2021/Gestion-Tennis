using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_convo_Tennis.Classes
{
    class AdoClassement
    {
        public static List<Classement> all()
        {
            List<Classement> classements = new List<Classement>();
            SqlCommand requete = new SqlCommand("SELECT * FROM classement");
            requete.Connection = Ado.OpenSqlConnection();
          SqlDataReader  reader = requete.ExecuteReader(); // Exécution de la requête SQL
            while (reader.Read())
            {
                 classements.Add(new Classement(reader.GetInt32(0),reader.GetInt32(2)));
            }
            reader.Close();
            return classements;
            
     
            
        }
    }
}
