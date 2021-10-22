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
                if (reader.IsDBNull(0))
                {
                    joueurs.Add(new Joueur(reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetBoolean(6), MainWindow.classements.Where(x => x.Id == reader.GetInt32(7)).First()));
                    reader.Close();
                    return joueurs;
                }
                else
                {
                    Console.Write("Aucun joueur n'a été détecter dans la BDD");
                    return null;
                }
            }

        }
        public static void addJoueur(List<Joueur> joueurs)
        {
            foreach (Joueur joueur in joueurs)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO joueur(nom,prenom,age,categorie_joueur, certificat, licence, fk_id_classement) VALUES(@nom,@prenom,@categorie_joueur, @certificat, @licence, @fk_id_classement)");
                cmd.Connection = Ado.OpenSqlConnection();
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@nom", joueur.Nom);
                cmd.Parameters.AddWithValue("@prenom", joueur.Prenom);
                cmd.Parameters.AddWithValue("@age", joueur.Age);
                cmd.Parameters.AddWithValue("@categorie_joueur", joueur.Categorie);
                cmd.Parameters.AddWithValue("@certificat", joueur.Certificat);
                cmd.Parameters.AddWithValue("@licence", joueur.License);
                cmd.Parameters.AddWithValue("@fk_id_classement", joueur.Classement.Id);
                cmd.ExecuteNonQuery();
            }
        }
        public static void delete()
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM joueur");
            cmd.Connection = Ado.OpenSqlConnection();
            cmd.ExecuteNonQuery();
        }
        // Méthode de supression
    }
}
