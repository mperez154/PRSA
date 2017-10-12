using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Automation.Data
{
    class DBConnect
    {
        public string connectionString = "Data Source=PRS-SQL-SERVER\\QASQLSERVER;Initial Catalog=LUIS_PARKING;User Id=luis_parking_user; Password=luispass!1";
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader dataReader;
    }
}
