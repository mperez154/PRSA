using System;
using System.Data.SqlClient;

namespace Automation.Data
{
    class User
    {
        private string firstname;
        private string lastname;
        private string username;
        private string password;
        private string consumer_Id;

        public User()
        {
            string connectionString = "Data Source=PRS-SQL-SERVER\\QASQLSERVER;Initial Catalog=LUIS_PARKING;User Id=luis_parking_user; Password=luispass!1";
            SqlConnection connection;
            SqlCommand command;
            string selects = " consumer_id, firstname, lastname, username, password ";
            string tables = " dbo.consumer ";
            string wheres = " firstname IS NOT NULL AND lastname IS NOT NULL and username IS NOT NULL AND firstname != '' AND lastname != '' and username != '' ";
            string orderBy = " 1, 2 ASC OFFSET " + GetRandomNumber() + " ROWS FETCH NEXT 1 ROWS ONLY; ";
            string query = "SELECT " + selects + " FROM " + tables + " WHERE " + wheres + " ORDER BY " + orderBy;
            SqlDataReader dataReader;
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    SetConsumerID(dataReader.GetValue(0).ToString());
                    SetFirstname(dataReader.GetValue(1).ToString());
                    SetLastname(dataReader.GetValue(2).ToString());
                    SetUsername(dataReader.GetValue(3).ToString());
                    SetPassword(dataReader.GetValue(4).ToString());
                }

                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message + "Can not open connection!");
            }
        }

        public string GetRandomNumber()
        {
            Random random = new Random();
            string myNumber = random.Next(100, 500000).ToString();            
            return myNumber;
        }

        public string GetFirstName()
        {
            return firstname;
        }
        public void SetFirstname(string firstname)
        {
            this.firstname = firstname;
        }

        public string GetLastname()
        {
            return lastname;
        }
        public void SetLastname(string lastname)
        {
            this.lastname = lastname;
        }

        public string GetConsumerID()
        {
            return consumer_Id;
        }

        public void SetConsumerID(string consumerID)
        {
            this.consumer_Id = consumerID;
        }
        public string GetUsername()
        {
            return username;
        }
        public void SetUsername(string username)
        {
            this.username = username;
        }
        public string GetPassword()
        {
            return password;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
    }
}