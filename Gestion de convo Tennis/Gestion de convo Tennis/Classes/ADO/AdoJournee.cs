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
            SqlCommand requeteJournee = new SqlCommand("SELECT * FROM journee");
            requeteJournee.Connection = Ado.OpenSqlConnection();
            SqlDataReader  readerJournee = requeteJournee.ExecuteReader(); // Exécution de la requête SQL
            while (readerJournee.Read())
            {
                Journee j = new Journee(
                     readerJournee.GetInt32(0),            //id
                     readerJournee.GetDateTime(1),         //date
                     readerJournee.GetString(2).Trim());   //categorie  

                //RÉCUPÉRATION DES DISPONIBILITÉS
                SqlCommand requeteDispo = new SqlCommand("SELECT * FROM disponible");
                requeteDispo.Connection = Ado.OpenSqlConnection();
                SqlDataReader readerDispo = requeteDispo.ExecuteReader();

                while (readerDispo.Read())
                {
                    if (readerDispo.GetInt32(1) == j.Id)
                    {
                       
                        bool dispo;
                        if (readerDispo.GetByte(2) == 0)
                        {
                            dispo = false;
                        }
                        else
                        {
                            dispo = true;
                        }
                        j.Dispo.Add(MainWindow.joueurs.Where(x => x.Id == readerDispo.GetInt32(0)).First(), dispo);
                    }
                }
                readerDispo.Close();
                journees.Add(j);                
            }
            readerJournee.Close();
            
            return journees;
        }
        public static void addJournee(List<Journee> journees)
        {
            delete();
            foreach (Journee journee in journees)
            {
                SqlCommand cmdJournee = new SqlCommand("INSERT INTO journee(dte, categorie) VALUES(@dte, @categorie)");
                cmdJournee.Connection = Ado.OpenSqlConnection();
                cmdJournee.Prepare();
                cmdJournee.Parameters.AddWithValue("@dte", journee.Date);
                cmdJournee.Parameters.AddWithValue("@categorie", journee.Categorie.Trim());
                cmdJournee.ExecuteNonQuery();

                foreach(var j in journee.Dispo)
                {
                    SqlCommand cmdDispo = new SqlCommand("INSERT INTO disponible(fk_id_joueur, fk_id_journee, is_dispo) VALUES (@id_joueur, @id_journee, @dispo);");
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
        public static void addRencontre(List<Journee> journees)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO rencontre(adversaire,lieu,dte_rencontre,heure,fk_id_journee,fk_id_equipe) VALUES(@adversaire,@lieu,@dte_rencontre,@heure,@fk_id_journee,@fk_id_equipe)");
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
            SqlCommand cmd = new SqlCommand("DELETE FROM journee; DELETE FROM disponible; DBCC CHECKIDENT (journee, RESEED, 0);");
            cmd.Connection = Ado.OpenSqlConnection();
            cmd.ExecuteNonQuery();
        }
    }
}
