using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Automation.Data
{
    class DBConnect
    {
        public static void getUser()
        {
            string connetionString = "Data Source=PRS-SQL-SERVER\\QASQLSERVER;Initial Catalog=LUIS_PARKING;User Id=luis_parking_user; Password=luispass!1";
            SqlConnection connection;
            SqlCommand command;
            string sql = "Select top 10 consumer_ID from dbo.consumer";
            SqlDataReader dataReader;
            connection = new SqlConnection(connetionString);
            List<string> userData = new List<string>();
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();              

                while (dataReader.Read())
                {
                    Console.Write(dataReader.GetValue(0) + "\n");
                    //userData.Add((string) dataReader.GetValue(0));
                }
 
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message + "Can not open connection ! ");
            }

            
        }
    }
}
