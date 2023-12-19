using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Repository;
using PayXpert.Utility;

namespace PayXpert.entity
{
    public class PayrollService : IPayrollService    {

        private List<Payroll> payrolls = new List<Payroll>();

        //public void GeneratePayroll(Payroll payroll)
        //{
        //    payrolls.Add(payroll);
        //    Console.Clear();
        //    Console.WriteLine("Added Successfullyyy ... !!");
        //}


        public string connectionString;
        SqlCommand cmd = null;

        public PayrollService()
        {

            //sqlConnection = new SqlConnection("Server=DESKTOP-0TE71RT;Database=PRODUCTAPPDB;Trusted_Connection=True");
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }


        //public void GeneratePayroll(Payroll payroll)
        //{
        //    try
        //    {
        //        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("INSERT INTO Payroll VALUES (@PayrollID, @EmployeeID, @PayPeriodStartDate, @BasicSalary, @OvertimePay, @Deductions, @NetSalary,@PayPeriodEndDate)", sqlConnection))
        //            {
        //                cmd.Parameters.AddWithValue("@PayrollID", payroll.PayrollID);
        //                cmd.Parameters.AddWithValue("@EmployeeID", payroll.EmployeeID);
        //                cmd.Parameters.Add("@PayPeriodStartDate", SqlDbType.DateTime).Value = payroll.PayPeriodStartDate;
        //                cmd.Parameters.AddWithValue("@BasicSalary", payroll.BasicSalary);
        //                cmd.Parameters.AddWithValue("@OvertimePay", payroll.OvertimePay);
        //                cmd.Parameters.AddWithValue("@Deductions", payroll.Deductions);
        //                cmd.Parameters.AddWithValue("@NetSalary", payroll.NetSalary);
        //                cmd.Parameters.Add("@PayPeriodEndDate", SqlDbType.DateTime).Value = payroll.PayPeriodEndDate;

        //                sqlConnection.Open();
        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    Console.WriteLine("Payroll added successfully.");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Failed to add payroll.");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error occurred: {ex.Message}");
        //    }
        //}




        public void GeneratePayroll(Payroll payroll)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    // Check if the PayrollID already exists
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Payroll WHERE PayrollID = @PayrollID", sqlConnection))
                    {
                        checkCmd.Parameters.AddWithValue("@PayrollID", payroll.PayrollID);
                        int existingPayrollCount = (int)checkCmd.ExecuteScalar();

                        if (existingPayrollCount > 0)
                        {
                            Console.WriteLine("Payroll with this ID already exists.");
                            return;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Payroll VALUES (@PayrollID, @EmployeeID, @PayPeriodStartDate, @BasicSalary, @OvertimePay, @Deductions, @NetSalary, @PayPeriodEndDate)", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@PayrollID", payroll.PayrollID);
                        cmd.Parameters.AddWithValue("@EmployeeID", payroll.EmployeeID);
                        cmd.Parameters.Add("@PayPeriodStartDate", SqlDbType.DateTime).Value = payroll.PayPeriodStartDate;
                        cmd.Parameters.AddWithValue("@BasicSalary", payroll.BasicSalary);
                        cmd.Parameters.AddWithValue("@OvertimePay", payroll.OvertimePay);
                        cmd.Parameters.AddWithValue("@Deductions", payroll.Deductions);
                        cmd.Parameters.AddWithValue("@NetSalary", payroll.NetSalary);
                        cmd.Parameters.Add("@PayPeriodEndDate", SqlDbType.DateTime).Value = payroll.PayPeriodEndDate;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Payroll added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add payroll.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }





















        //public Payroll GetPayrollById(int payrollId)
        //{
        //    return payrolls.Find(p => p.PayrollID == payrollId);
        //}


        public Payroll GetPayrollById(int payrollId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Payroll WHERE PayrollID = @PayrollID", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@PayrollID", payrollId);

                        sqlConnection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            Payroll payroll = new Payroll
                            {
                                PayrollID = (int)reader["PayrollID"],
                                EmployeeID = (int)reader["EmployeeID"],
                                PayPeriodStartDate = (DateTime)reader["PayPeriodStartDate"],
                                BasicSalary = (int)reader["BasicSalary"],
                                OvertimePay = (int)reader["OvertimePay"],
                                Deductions = (int)reader["Deductions"],
                                NetSalary = (int)reader["NetSalary"],
                                PayPeriodEndDate = (DateTime)reader["PayPeriodEndDate"]
                            };

                            return payroll;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            return null;
        }



        //public List<Payroll> GetPayrollsForEmployee(int employeeId)
        //{
        //    return payrolls.FindAll(p => p.EmployeeID == employeeId);
        //}


        public List<Payroll> GetPayrollsForEmployee(int employeeId)
        {
            List<Payroll> employeePayrolls = new List<Payroll>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Payroll WHERE EmployeeID = @EmployeeID", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        sqlConnection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Payroll payroll = new Payroll();
                            payroll.PayrollID = (int)reader["PayrollID"];
                            payroll.EmployeeID = (int)reader["EmployeeID"];
                            payroll.PayPeriodStartDate = (DateTime)reader["PayPeriodStartDate"];
                            payroll.BasicSalary = (int)reader["BasicSalary"];
                            payroll.OvertimePay = (int)reader["OvertimePay"];
                            payroll.Deductions = (int)reader["Deductions"];
                            payroll.NetSalary = (int)reader["NetSalary"];
                            payroll.PayPeriodEndDate = (DateTime)reader["PayPeriodEndDate"];

                            employeePayrolls.Add(payroll);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
            return employeePayrolls;
        }



        public List<Payroll> GetPayrollsForPeriod(DateTime startDate, DateTime endDate)
        {
            List<Payroll> payrollsForPeriod = new List<Payroll>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Payroll WHERE PayPeriodStartDate >= @StartDate AND PayPeriodEndDate <= @EndDate", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);

                        sqlConnection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Payroll payroll = new Payroll
                            {
                                PayrollID = (int)reader["PayrollID"],
                                EmployeeID = (int)reader["EmployeeID"],
                                PayPeriodStartDate = (DateTime)reader["PayPeriodStartDate"],
                                PayPeriodEndDate = (DateTime)reader["PayPeriodEndDate"],
                                BasicSalary = (int)reader["BasicSalary"],
                                OvertimePay = (int)reader["OvertimePay"],
                                Deductions = (int)reader["Deductions"],
                                NetSalary = (int)reader["NetSalary"]
                            };
                            payrollsForPeriod.Add(payroll);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            return payrollsForPeriod;
        }



    }
}
