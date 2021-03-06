﻿using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.DataLayer
{
    public class DatabaseScreening
    {
        private static string connectionString = "Server =tcp:cintim.database.windows.net,1433;Initial Catalog=Cinema;Persist Security Info=False;User ID=GamerIsTheNamer;Password=Ikbencool20042000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection = new SqlConnection(connectionString);

        public List<ScreeningModel> Screenings { get; set; }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

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
                    ScreeningModel screening = new ScreeningModel(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetTimeSpan(4));
                    Screenings.Add(screening);
                }
            }

            connection.Close();
            return (Screenings);
        }


        public void AddScreening(ScreeningModel screening)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Screening OUTPUT Inserted.Id VALUES (@IdMovie, @IdHall, @DateOfScreening, @TimeOfScreening)", connection);
            command.Parameters.AddWithValue("@IdMovie", screening.MovieId);
            command.Parameters.AddWithValue("@IdHall", screening.HallId);
            command.Parameters.AddWithValue("@DateOfScreening", screening.DateOfScreening);
            command.Parameters.AddWithValue("@TimeOfScreening", screening.TimeOfScreening);
            //MovieModel newMovie = new MovieModel(((int)command.ExecuteScalar()), screening.Id, screening.MovieId);
            command.ExecuteScalar();
            connection.Close();
        }

        public void EditScreening(ScreeningModel screening)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Screening SET IdMovie = @IdMovie, IdHall = @IdHall, DateOfScreening = @DateOfScreening, " +
                "TimeOfScreening = @TimeOfScreening WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", screening.Id);
            command.Parameters.AddWithValue("@IdMovie", screening.MovieId);
            command.Parameters.AddWithValue("@IdHall", screening.HallId);
            command.Parameters.AddWithValue("@DateOfScreening", screening.DateOfScreening);
            command.Parameters.AddWithValue("@TimeOfScreening", screening.TimeOfScreening);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void DeleteScreening(ScreeningModel screening)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Screening WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", screening.Id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
