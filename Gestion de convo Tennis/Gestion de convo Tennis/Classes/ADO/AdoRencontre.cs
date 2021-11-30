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

        public static void addRencontre(List<Journee> journees)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO rencontre(adversaire,lieu,dte_rencontre,fk_id_journee,fk_id_equipe) VALUES(@adversaire,@lieu,@dte_rencontre,@heure,@fk_id_journee,@fk_id_equipe)");
            cmd.Connection = Ado.OpenSqlConnection();
            cmd.Prepare();
            foreach (Journee journee in journees)
            {
                foreach (Rencontre rencontre in journee.Rencontres)
                {
                    cmd.Parameters.AddWithValue("@adversaire", rencontre.Adversaire);
                    cmd.Parameters.AddWithValue("@lieu", rencontre.Lieu);
                    cmd.Parameters.AddWithValue("@dte_rencontre", rencontre.DteHeure); // Chercher juste la date // Chercher que l'heure
                    cmd.Parameters.AddWithValue("@fk_id_journee", journee.Id);
                    cmd.Parameters.AddWithValue("@fk_id_equipe", rencontre.Equipe.Id);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmdJournee = new SqlCommand("INSERT INTO journee(dte, categorie) VALUES(@dte, @categorie); SELECT SCOPE_IDENTITY();");
                    cmdJournee.Connection = Ado.OpenSqlConnection();
                    cmdJournee.Prepare();
                    cmdJournee.Parameters.AddWithValue("@dte", journee.Date);
                    cmdJournee.Parameters.AddWithValue("@categorie", journee.Categorie.Trim());
                    journee.Id = Convert.ToInt32(cmdJournee.ExecuteScalar());

                    foreach (var j in journee.Dispo)
                    {
                        SqlCommand cmdDispo = new SqlCommand("INSERT INTO disponible(fk_id_joueur, fk_id_journee, is_dispo) VALUES (@id_joueur, @id_journee, @dispo); ");
                        cmdDispo.Connection = Ado.OpenSqlConnection();
                        cmdDispo.Prepare();
                        cmdDispo.Parameters.AddWithValue("@id_joueur", j.Key.Id);
                        cmdDispo.Parameters.AddWithValue("@id_journee", journee.Id);
                        cmdDispo.Parameters.AddWithValue("@dispo", j.Value);
                        cmdDispo.ExecuteNonQuery();
                        cmdDispo.Connection.Close();
                    }
                    cmdJournee.Connection.Close();
                }
            }
        }

        public static void delete()
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM rencontre; DBCC CHECKIDENT (rencontre, RESEED, 0);");
            cmd.Connection = Ado.OpenSqlConnection();
            cmd.ExecuteNonQuery();
        }
    }
}
