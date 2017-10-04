using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Automation.Data
{
    class Channels
    {
        public Channels()
        {
        }

        public IEnumerable<string> GetAllChannels()
        {
            string connectionString = "Data Source=PRS-SQL-SERVER\\QASQLSERVER;Initial Catalog=LUIS_PARKING;User Id=luis_parking_user; Password=luispass!1";
            SqlConnection connection;
            SqlCommand command;
            string selects = " channel_name ";
            string tables = " channel ";
            string wheres = " company_id = 68 and is_active = 1 and end_date > getDate() and channel_type_id = 6 ";
            string orderBy = " 1 ASC ";
            string query = "SELECT " + selects + " FROM " + tables + " WHERE " + wheres + " ORDER BY " + orderBy;
            SqlDataReader dataReader;
            connection = new SqlConnection(connectionString);

            connection.Open();
            command = new SqlCommand(query, connection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                yield return dataReader.GetString(dataReader.GetOrdinal("channel_name"));
            }

            dataReader.Close();
            command.Dispose();
            connection.Close();
        }
    }
}