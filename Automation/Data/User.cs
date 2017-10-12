using System;
using System.Data.SqlClient;

namespace Automation.Data
{
    class User : DBConnect
    {
        private string firstname;
        private string lastname;
        private string username;
        private string password;
        private string consumer_Id;
        private string address;
        private string state;
        private string zip;
        private string phone;
        private string city;
        
        public User()
        {
            //Building query 
            string selects = " consumer_id, firstname, lastname, username, password, address_1, state_region, postal_code, home_phone, city ";
            string tables = " dbo.consumer ";
            string wheres = " firstname IS NOT NULL AND firstname != '' AND lastname IS NOT NULL AND lastname != '' and username IS NOT NULL  and username != '' AND address_1 IS NOT NULL AND address_1 != '' AND state_region IS NOT NULL AND state_region != '' AND postal_code IS NOT NULL AND postal_code != '' and home_phone IS NOT NULL and home_phone != '' AND city IS NOT NULL AND city != '' ";
            string orderBy = " 1, 2 ASC OFFSET " + GetRandomNumber() + " ROWS FETCH NEXT 1 ROWS ONLY; ";
            string query = "SELECT " + selects + " FROM " + tables + " WHERE " + wheres + " ORDER BY " + orderBy;
            
            //Open connection
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
                    SetAddress(dataReader.GetValue(5).ToString());
                    SetState(dataReader.GetValue(6).ToString());
                    SetZip(dataReader.GetValue(7).ToString());
                    SetPhone(dataReader.GetValue(8).ToString());
                    SetCity(dataReader.GetValue(9).ToString());
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
            string myNumber = random.Next(100, 20000).ToString();            
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
        public string GetAddress()
        {
            return address;
        }
        public string GetState()
        {
            return state;
        }
        public string GetZip()
        {
            return zip;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public void SetState(string state)
        {
            this.state = state;
        }

        public void SetZip(string zip)
        {
            this.zip = zip;
        }
        public string GetPhone()
        {
            return phone;
        }
        public void SetPhone(string phone)
        {
            this.phone = phone;
        }
        public void SetCity(string city)
        {
            this.city = city;
        }
        public string GetCity()
        {
            return city;
        }
    }
}