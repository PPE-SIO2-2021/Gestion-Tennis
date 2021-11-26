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
                // Récupération de l'id, nom, prenom, age, mail, license, certificat, categorie, classement
                joueurs.Add(new Joueur(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), MainWindow.classements.Where(x => x.Id == reader.GetInt32(8)).First())) ;
            }
            reader.Close();
            return joueurs;
        }
        public static void addJoueur(List<Joueur> joueurs)
        {
            delete();
            foreach (Joueur joueur in joueurs)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO joueur(nom,prenom,age,mail,categorie,certificat,licence,fk_id_classement) VALUES(@nom,@prenom,@age,@mail,@categorie, @certificat, @licence, @fk_id_classement)");
                cmd.Connection = Ado.OpenSqlConnection();
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@nom", joueur.Nom.Trim());
                cmd.Parameters.AddWithValue("@prenom", joueur.Prenom.Trim());
                cmd.Parameters.AddWithValue("@age", joueur.Age);
                cmd.Parameters.AddWithValue("@mail", joueur.Mail.Trim());
                cmd.Parameters.AddWithValue("@categorie", joueur.Categorie.Trim());
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
