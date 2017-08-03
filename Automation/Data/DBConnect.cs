using System;
using System.Data.SqlClient;
using System.Data;

namespace Automation.Data
{
    class DBConnect
    {
        public static void myDbConnection()
        {
            string connectionString = "Data Source=DatabaseServer; Initial Catalog=Luis_Parking; User ID=YourUserID; Password=YourPassword";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT TOP 5 * FROM dbo.Customers ORDER BY CustomerID";
                using (SqlCommand sqlCommand = new SqlCommand(queryStatement, con))
                {
                    DataTable reservationsTable = new DataTable("Top5Customers");

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);

                    con.Open();
                    sqlAdapter.Fill(reservationsTable);
                    con.Close();
                }
            }
        }
    }
}
