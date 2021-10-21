using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_convo_Tennis.Classes;

namespace Gestion_de_convo_Tennis.Classes
{
    class AdoJoueur
    {
        public static List<Joueur> all()
        {
            List<Joueur> joueurs = new List<Joueur>();
            SqlCommand requete = new SqlCommand("SELECT * FROM joueur");
            requete.Connection = Ado.OpenSqlConnection();
            SqlDataReader  reader = requete.ExecuteReader(); // Exécution de la requête SQL
            while (reader.Read())
            {
                // Récupération du nom, prenom, age, license, certificat & categorie
                joueurs.Add(new Joueur(reader.GetString(1),reader.GetString(2),reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetBoolean(6)));
            }
            reader.Close();
            return joueurs;
        }
        // Méthode push
        // Méthode de supression
    }
}
