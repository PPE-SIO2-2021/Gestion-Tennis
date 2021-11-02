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
            List<Journee> journees = new List<Journee>();
            SqlCommand requete = new SqlCommand("SELECT * FROM journee");
            requete.Connection = Ado.OpenSqlConnection();
            SqlDataReader  reader = requete.ExecuteReader(); // Exécution de la requête SQL
            while (reader.Read())
            {
                 journees.Add(new Journee(reader.GetInt32(0),reader.GetDateTime(1),reader.GetString(2)));
            }
            reader.Close();
            return journees;
        }
        public static void addJournee(List<Journee> journees)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO journee(dte_journee,categorie_journee) VALUES(@dte_journee,@categorie_journee)");
            cmd.Connection = Ado.OpenSqlConnection();
            cmd.Prepare();
            foreach (Journee journee in journees)
            {
                cmd.Parameters.AddWithValue("@dte_journee", journee.Date);
                cmd.Parameters.AddWithValue("@categorie_journee", journee.Categorie);
                cmd.ExecuteNonQuery();
            }
        }
        public static void addRencontre(List<Journee> journees)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO journee(adversaire,lieu,dte_rencontre,heure,fk_id_journee,fk_id_equipe) VALUES(@adversaire,@lieu,@dte_rencontre,@heure,@fk_id_journee,@fk_id_equipe)");
            cmd.Connection = Ado.OpenSqlConnection();
            cmd.Prepare();
            foreach (Journee journee in journees)
            {
                foreach (Rencontre rencontre in journee.Rencontres)
                { 
                        cmd.Parameters.AddWithValue("@adversaire", rencontre.Adversaire);
                        cmd.Parameters.AddWithValue("@lieu", rencontre.Lieu);
                        cmd.Parameters.AddWithValue("@dte_rencontre", rencontre.Dte); // Chercher juste la date
                        cmd.Parameters.AddWithValue("@heure", rencontre.Dte); // Chercher que l'heure
                        cmd.Parameters.AddWithValue("@fk_id_journee", journee.Id);
                        cmd.Parameters.AddWithValue("@fk_id_equipe", rencontre.Equipe.Id);
                        cmd.ExecuteNonQuery();
                }
            }
        }
        public static void delete()
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM journee");
            cmd.Connection = Ado.OpenSqlConnection();
            cmd.ExecuteNonQuery();
        }
    }
}
