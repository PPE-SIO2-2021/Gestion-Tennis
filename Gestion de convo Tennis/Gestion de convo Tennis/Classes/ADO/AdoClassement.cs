using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_convo_Tennis.Classes;

namespace Gestion_de_convo_Tennis.Classes
{
    class AdoClassement
    {
        public static List<Classement> all()
        {
            List<Classement> classements = new List<Classement>();
            SqlCommand requete = new SqlCommand("SELECT * FROM classement ORDER BY ID DESC");
            requete.Connection = Ado.OpenSqlConnection();
            SqlDataReader  reader = requete.ExecuteReader(); // Exécution de la requête SQL
            while (reader.Read())
            {
                // Récupération de l'Id, de l'ordre et du Rang
                classements.Add(new Classement(
                    reader.GetInt32(0),             //Id
                    reader.GetInt32(1),             //Ordre
                    reader.GetString(2).Trim()));   //Rang
            }
            reader.Close();
            return classements;
        }
    }
}
