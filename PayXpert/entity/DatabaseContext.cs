//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PayXpert.entity
//{
//    internal class DatabaseContext
//    {

//        private string connectionString; // Your database connection string

//        public DatabaseContext(string connectionString)
//        {
//            this.connectionString = connectionString;
//        }

//        // Example method to perform database operations (e.g., execute SQL queries)
//        public void ExecuteQuery(string query)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand(query, connection);
//                    command.ExecuteNonQuery();
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("Error executing query: " + ex.Message);
//                    // Handle exceptions or log errors accordingly
//                }
//            }
//        }

//        // Other methods for database operations, such as retrieving data, updating records, etc.
//        // ...

//        // Dispose method to release resources if necessary
//        public void Dispose()
//        {
//            // Dispose resources like connections, if required
//        }

//    }
//}
