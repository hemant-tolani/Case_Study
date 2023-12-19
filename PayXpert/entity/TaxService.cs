using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Repository;
using PayXpert.Utility;

namespace PayXpert.entity
{
    public class TaxService : ITaxService
    {

        private List<Tax> taxes = new List<Tax>();

        public string connectionString;
        SqlCommand cmd = null;

        public TaxService()
        {

            //sqlConnection = new SqlConnection("Server=DESKTOP-0TE71RT;Database=PRODUCTAPPDB;Trusted_Connection=True");
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        //public void CalculateTax(Tax tax)
        //{
        //    taxes.Add(tax);
        //    Console.Clear();
        //    Console.WriteLine("Added Successfullyyy ... !!");
        //}

        //public void CalculateTax(Tax tax)
        //{
        //    try
        //    {
        //        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //        {
        //            sqlConnection.Open();

        //            using (SqlCommand cmd = new SqlCommand("INSERT INTO Tax (TaxID, EmployeeID, TaxYear, TaxableIncome, TaxAmount) " +
        //                                                    "VALUES (@TaxID, @EmployeeID, @TaxYear, @TaxableIncome, @TaxAmount)", sqlConnection))
        //            {
        //                cmd.Parameters.AddWithValue("@TaxID", tax.TaxID);
        //                cmd.Parameters.AddWithValue("@EmployeeID", tax.EmployeeID);
        //                cmd.Parameters.AddWithValue("@TaxYear", tax.TaxYear);
        //                cmd.Parameters.AddWithValue("@TaxableIncome", tax.TaxableIncome);
        //                cmd.Parameters.AddWithValue("@TaxAmount", tax.TaxAmount);

        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected != 0)
        //                {
        //                    Console.WriteLine("Tax calculated and added successfully.");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Failed to calculate tax.");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error occurred: {ex.Message}");
        //    }
        //}











        public void CalculateTax(Tax tax)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    // Check if the TaxID already exists
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Tax WHERE TaxID = @TaxID", sqlConnection))
                    {
                        checkCmd.Parameters.AddWithValue("@TaxID", tax.TaxID);
                        int existingTaxCount = (int)checkCmd.ExecuteScalar();

                        if (existingTaxCount > 0)
                        {
                            Console.WriteLine("Tax record with this ID already exists.");
                            return;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Tax (TaxID, EmployeeID, TaxYear, TaxableIncome, TaxAmount) " +
                                                            "VALUES (@TaxID, @EmployeeID, @TaxYear, @TaxableIncome, @TaxAmount)", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@TaxID", tax.TaxID);
                        cmd.Parameters.AddWithValue("@EmployeeID", tax.EmployeeID);
                        cmd.Parameters.AddWithValue("@TaxYear", tax.TaxYear);
                        cmd.Parameters.AddWithValue("@TaxableIncome", tax.TaxableIncome);
                        cmd.Parameters.AddWithValue("@TaxAmount", tax.TaxAmount);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected != 0)
                        {
                            Console.WriteLine("Tax calculated and added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to calculate tax.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }














        //public Tax GetTaxById(int taxId)
        //{
        //    return taxes.Find(t => t.TaxID == taxId);
        //}


        public Tax GetTaxById(int taxId)
        {
            Tax tax = null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tax WHERE TaxID = @TaxID", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@TaxID", taxId);
                        sqlConnection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            tax = new Tax
                            {
                                TaxID = (int)reader["TaxID"],
                                EmployeeID = (int)reader["EmployeeID"],
                                TaxYear = (int)reader["TaxYear"],
                                TaxableIncome = (int)reader["TaxableIncome"],
                                TaxAmount = (int)reader["TaxAmount"]
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            return tax;
        }



        //public List<Tax> GetTaxesForEmployee(int employeeId)
        //{
        //    return taxes.FindAll(t => t.EmployeeID == employeeId);
        //}


        public List<Tax> GetTaxesForEmployee(int employeeId)
        {
            List<Tax> employeeTaxes = new List<Tax>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tax WHERE EmployeeID = @EmployeeID", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        sqlConnection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Tax tax = new Tax
                            {
                                TaxID = (int)reader["TaxID"],
                                EmployeeID = (int)reader["EmployeeID"],
                                TaxYear = (int)reader["TaxYear"],
                                TaxableIncome = (int)reader["TaxableIncome"],
                                TaxAmount = (int)reader["TaxAmount"]
                            };

                            employeeTaxes.Add(tax);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            return employeeTaxes;
        }



        //public List<Tax> GetTaxesForYear(int year)
        //{
        //    return taxes.FindAll(t => t.TaxYear == year);
        //}


        public List<Tax> GetTaxesForYear(int year)
        {
            List<Tax> taxesForYear = new List<Tax>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tax WHERE TaxYear = @TaxYear", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@TaxYear", year);
                        sqlConnection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Tax tax = new Tax
                            {
                                TaxID = (int)reader["TaxID"],
                                EmployeeID = (int)reader["EmployeeID"],
                                TaxYear = (int)reader["TaxYear"],
                                TaxableIncome = (int)reader["TaxableIncome"],
                                TaxAmount = (int)reader["TaxAmount"]
                            };

                            taxesForYear.Add(tax);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            return taxesForYear;
        }


    }
}
