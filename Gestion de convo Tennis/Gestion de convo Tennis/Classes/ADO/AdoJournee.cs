﻿using System;
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
                // Récupération de la date & la catégorie (senior/senior+)
                 journees.Add(new Journee(reader.GetDateTime(1),reader.GetBoolean(2)));
            }
            reader.Close();
            return journees;
            
     
            
        }
    }
}
