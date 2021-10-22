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
            List<Rencontre> rencontres = new List<Rencontre>();
            SqlCommand requete = new SqlCommand("SELECT * FROM rencontre");
            requete.Connection = Ado.OpenSqlConnection();
            SqlDataReader  reader = requete.ExecuteReader(); // Exécution de la requête SQL
            while (reader.Read())
            {
                // Récupération de la date, lieu & adversaire
                rencontres.Add(new Rencontre(reader.GetDateTime(1),reader.GetString(2), reader.GetString(3)));
            }
            reader.Close();
            return rencontres;
        }
        public static delete()
        {
            SqlCommand requete = new SqlCommand("DELETE FROM rencontre";
            cmd.Connection = Ado.OpenSqlConnection();
            cmd.ExecuteNonQuery();
        }
    }
}
