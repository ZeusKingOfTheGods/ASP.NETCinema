﻿using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Data
{
    public class DatabaseScreening
    {
        private static string connectionString = "Server =tcp:cintim.database.windows.net,1433;Initial Catalog=Cinema;Persist Security Info=False;User ID=GamerIsTheNamer;Password=Ikbencool20042000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection = new SqlConnection(connectionString);

        public List<ScreeningModel> Screenings { get; set; }

        public List<ScreeningModel> GetScreenings()
        {
            //using ASPNETCinema.Models; added
            Screenings = new List<ScreeningModel>();
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Screening", connection);
            

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ScreeningModel screening = new ScreeningModel(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3));
                    Screenings.Add(screening);
                }
            }

            connection.Close();
            return (Screenings);
        }

        /* [Id]                     INT      IDENTITY (1, 1) NOT NULL,
    [IdMovie]                INT      NULL,
    [IdHall]                 INT      NULL,
    [DateAndTimeOfScreening] DATETIME NULL,*/
    }
}
