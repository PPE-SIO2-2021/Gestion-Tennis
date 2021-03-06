using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_convo_Tennis.Classes;

namespace Gestion_de_convo_Tennis.Classes
{
    class AdoEquipe
    {
        public static List<Equipe> all()
        {
            List<Equipe> equipes = new List<Equipe>();
            SqlCommand requete = new SqlCommand("SELECT * FROM equipe");
            requete.Connection = Ado.OpenSqlConnection();
            SqlDataReader  reader = requete.ExecuteReader(); // Exécution de la requête SQL
            while (reader.Read())
            {
                // Récupération de l'id , de la catégorie & de l'ordre de l'équipe
                 equipes.Add(new Equipe(
                     reader.GetInt32(0),            //Id
                     reader.GetString(1).Trim(),    //Categorie
                     reader.GetInt32(2)));          //Ordre
            }
            reader.Close();
            return equipes;
        }
        public static void addEquipe(List<Equipe> equipes)
        {
            delete();
            foreach (Equipe equipe in equipes)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO equipe(categorie, ordre) VALUES(@categorie, @ordre)");
                cmd.Connection = Ado.OpenSqlConnection();
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@categorie", equipe.Categorie.Trim());
                cmd.Parameters.AddWithValue("@ordre", equipe.Ordre);
                cmd.ExecuteNonQuery();
            }
        }
        public static void delete()
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM equipe; DBCC CHECKIDENT (equipe, RESEED, 0);");
            cmd.Connection = Ado.OpenSqlConnection();
            cmd.ExecuteNonQuery();
        }
    }
}
