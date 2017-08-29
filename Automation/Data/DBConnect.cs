using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Automation.Data
{
    class DBConnect
    {
        public static List<Object> GetUser()
        {
            string connetionString = "Data Source=PRS-SQL-SERVER\\QASQLSERVER;Initial Catalog=LUIS_PARKING;User Id=luis_parking_user; Password=luispass!1";
            SqlConnection connection;
            SqlCommand command;
            string selects = " top 10 consumer_id, firstname, lastname, username ";
            string tables = " dbo.consumer ";
            string wheres = " firstname IS NOT NULL AND lastname IS NOT NULL and username IS NOT NULL AND firstname != '' AND lastname != '' and username != '' ";
            string query = "SELECT " + selects + " FROM " + tables + " WHERE " + wheres;
            SqlDataReader dataReader;
            connection = new SqlConnection(connetionString);
            List<Object> userData = new List<Object>();
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                dataReader = command.ExecuteReader();  
                
                while (dataReader.Read())
                {
                    for(int i = 0; i < 4; i++)
                    {
                        userData.Add(dataReader.GetValue(i));
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
            return userData;
            
        }

        public static Dictionary<int, string> getReservationDates(int reservationID)
        {
            List<Object> reservationDates = new List<Object>();
            Dictionary<int, string> reservationDictionary = new Dictionary<int, string>();

            string connetionString = "Data Source=PRS-SQL-SERVER\\QASQLSERVER;Initial Catalog=LUIS_PARKING;User Id=luis_parking_user; Password=luispass!1";
            SqlConnection connection;
            SqlCommand command;
            string selects = " StartDateUtc, EndDateUtc ";
            string tables = " dbo.Reservations ";
            string wheres = " id = " +  reservationID + " ";
            string query = "SELECT " + selects + " FROM " + tables + " WHERE " + wheres;
            SqlDataReader dataReader;
            connection = new SqlConnection(connetionString);

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
                        reservationDictionary.Add(i+1, dataReader.GetValue(i).ToString());
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
