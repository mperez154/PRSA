using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Automation.Data
{
    class Reservation : DBConnect
    {
        public Reservation()
        {

        }

        public Dictionary<int, string> GetReservationDates(int reservationID)
        {
            List<Object> reservationDates = new List<Object>();
            Dictionary<int, string> reservationDictionary = new Dictionary<int, string>();

            string selects = " StartDateUtc, EndDateUtc ";
            string tables = " dbo.Reservations ";
            string wheres = " id = " + reservationID + " ";
            string query = "SELECT " + selects + " FROM " + tables + " WHERE " + wheres;
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    for (int i = 0; i < 2; i++)
                    {
                        //reservationDates.Add(dataReader.GetValue(i));
                        reservationDictionary.Add(i + 1, dataReader.GetValue(i).ToString());
                    }
                }

                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message + "Can not open connection!");
            }
            return reservationDictionary;
        }
    }
}
