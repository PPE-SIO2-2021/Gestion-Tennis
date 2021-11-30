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
                SqlCommand requeteDispo = new SqlCommand("SELECT * FROM Disponible");
                requeteDispo.Connection = Ado.OpenSqlConnection();
                SqlDataReader readerDispo = requeteDispo.ExecuteReader();

                while (readerDispo.Read())
                {
                    if (readerDispo.GetInt32(1) == j.Id)
                    {
                        int i = readerDispo.GetInt32(0);
                        j.Dispo.Add(MainWindow.joueurs.Find(x => x.Id == i), Convert.ToBoolean(readerDispo.GetByte(2)));
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
       
        public static void delete()
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM journee; DELETE FROM disponible; DBCC CHECKIDENT (journee, RESEED, 0);");
            cmd.Connection = Ado.OpenSqlConnection();
            cmd.ExecuteNonQuery();
        }
    }
}
