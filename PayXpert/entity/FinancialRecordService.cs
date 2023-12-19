using PayXpert.Repository;
using PayXpert.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.entity
{
    public class FinancialRecordService : IFinancialRecordService
    {

        private List<FinancialRecord> financialRecords = new List<FinancialRecord>();

        //public void AddFinancialRecord(FinancialRecord record)
        //{
        //    financialRecords.Add(record);
        //    Console.Clear();
        //    Console.WriteLine("Added Successfullyyy ... !!");
        //}

        public string connectionString;
        SqlCommand cmd = null;

        public FinancialRecordService()
        {

            //sqlConnection = new SqlConnection("Server=LAPTOP-POVHQKLI;Database=payxpert;Trusted_Connection=True");
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }


        //public void AddFinancialRecord(FinancialRecord record)
        //{

        //        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //        {

        //            cmd.Parameters.AddWithValue("@RecordID", record.RecordID);
        //            cmd.Parameters.AddWithValue("@EmployeeID", record.EmployeeID);
        //            cmd.Parameters.AddWithValue("@RecordDate", record.RecordDate);
        //            cmd.Parameters.AddWithValue("@Description", record.Description);
        //            cmd.Parameters.AddWithValue("@Amount", record.Amount);
        //            cmd.Parameters.AddWithValue("@RecordType", record.RecordType);

        //            cmd.Connection = sqlConnection;
        //            sqlConnection.Open();
        //            int rowsAffected = cmd.ExecuteNonQuery();

        //            if (rowsAffected != 0)
        //            {
        //                Console.WriteLine("Financial record added successfully.");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Failed to add financial record.");
        //            }

        //        }

        //        cmd.Parameters.Clear();


        //}



        //public void AddFinancialRecord(FinancialRecord record)
        //{
        //    try
        //    {
        //        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "INSERT INTO FinancialRecord (RecordID, EmployeeID, RecordDate, Descriptions, Amount, RecordType) " +
        //                                  "VALUES (@RecordID, @EmployeeID, @RecordDate, @Descriptions, @Amount, @RecordType)";

        //                cmd.Parameters.AddWithValue("@RecordID", record.RecordID);
        //                cmd.Parameters.AddWithValue("@EmployeeID", record.EmployeeID);
        //                cmd.Parameters.AddWithValue("@RecordDate", record.RecordDate);
        //                cmd.Parameters.AddWithValue("@Descriptions", record.Descriptions);
        //                cmd.Parameters.AddWithValue("@Amount", record.Amount);
        //                cmd.Parameters.AddWithValue("@RecordType", record.RecordType);

        //                cmd.Connection = sqlConnection;
        //                sqlConnection.Open();
        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    Console.WriteLine("Financial record added successfully.");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Failed to add financial record.");
        //                }
        //            }
        //        }
        //        cmd.Parameters.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error occurred: {ex.Message}");
        //    }
        //}










        public void AddFinancialRecord(FinancialRecord record)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    // Check if the RecordID already exists
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM FinancialRecord WHERE RecordID = @RecordID", sqlConnection))
                    {
                        checkCmd.Parameters.AddWithValue("@RecordID", record.RecordID);
                        int existingRecordCount = (int)checkCmd.ExecuteScalar();

                        if (existingRecordCount > 0)
                        {
                            Console.WriteLine("Financial record with this ID already exists.");
                            return;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "INSERT INTO FinancialRecord (RecordID, EmployeeID, RecordDate, Descriptions, Amount, RecordType) " +
                                          "VALUES (@RecordID, @EmployeeID, @RecordDate, @Descriptions, @Amount, @RecordType)";

                        cmd.Parameters.AddWithValue("@RecordID", record.RecordID);
                        cmd.Parameters.AddWithValue("@EmployeeID", record.EmployeeID);
                        cmd.Parameters.AddWithValue("@RecordDate", record.RecordDate);
                        cmd.Parameters.AddWithValue("@Descriptions", record.Descriptions);
                        cmd.Parameters.AddWithValue("@Amount", record.Amount);
                        cmd.Parameters.AddWithValue("@RecordType", record.RecordType);

                        cmd.Connection = sqlConnection;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Financial record added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add financial record.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }













        //public FinancialRecord GetFinancialRecordById(int recordId)
        //{
        //    return financialRecords.Find(r => r.RecordID == recordId);
        //}


        public FinancialRecord GetFinancialRecordById(int recordId)
        {
            FinancialRecord financialRecord = null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM FinancialRecord WHERE RecordID = @RecordID", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@RecordID", recordId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                financialRecord = new FinancialRecord
                                {
                                    RecordID = (int)reader["RecordID"],
                                    EmployeeID = (int)reader["EmployeeID"],
                                    RecordDate = (DateTime)reader["RecordDate"],
                                    Descriptions = reader["Descriptions"].ToString(),
                                    Amount = (int)reader["Amount"],
                                    RecordType = reader["RecordType"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            return financialRecord;
        }




        //public List<FinancialRecord> GetFinancialRecordsForEmployee(int employeeId)
        //{
        //    return financialRecords.FindAll(r => r.EmployeeID == employeeId);
        //}

        public List<FinancialRecord> GetFinancialRecordsForEmployee(int employeeId)
        {
            List<FinancialRecord> rec = new List<FinancialRecord>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM FinancialRecord WHERE EmployeeID = @EmployeeID", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FinancialRecord financialRecord = new FinancialRecord
                                {
                                    RecordID = (int)reader["RecordID"],
                                    EmployeeID = (int)reader["EmployeeID"],
                                    RecordDate = (DateTime)reader["RecordDate"],
                                    Descriptions = reader["Descriptions"].ToString(),
                                    Amount = (int)reader["Amount"],
                                    RecordType = reader["RecordType"].ToString()
                                };

                                rec.Add(financialRecord);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            return rec;
        }



        //public List<FinancialRecord> GetFinancialRecordsForDate(DateTime date)
        //{
        //    return financialRecords.FindAll(r => r.RecordDate.Date == date.Date);
        //}



        public List<FinancialRecord> GetFinancialRecordsForDate(DateTime date)
        {
            List<FinancialRecord> ds = new List<FinancialRecord>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM FinancialRecord WHERE CONVERT(DATE, RecordDate) = @RecordDate", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@RecordDate", date.Date);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FinancialRecord financialRecord = new FinancialRecord
                                {
                                    RecordID = (int)reader["RecordID"],
                                    EmployeeID = (int)reader["EmployeeID"],
                                    RecordDate = (DateTime)reader["RecordDate"],
                                    Descriptions = reader["Descriptions"].ToString(),
                                    Amount = (int)reader["Amount"],
                                    RecordType = reader["RecordType"].ToString()
                                };

                                ds.Add(financialRecord);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            return ds;
        }






    }
}
