using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Repository;
using System.Data.SqlClient;
using PayXpert.Utility;
using System.Data;

namespace PayXpert.entity
{
    public class EmployeeService : IEmployeeService
    {

        public List<Employee> employees = new List<Employee>();

        public string connectionString;
        SqlCommand cmd = null;

        public EmployeeService()
        {

            //sqlConnection = new SqlConnection("Server=DESKTOP-0TE71RT;Database=PRODUCTAPPDB;Trusted_Connection=True");
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee = null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Employee WHERE EmployeeID = @EmployeeID", sqlConnection);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            EmployeeID = (int)reader["EmployeeID"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            Gender = (string)reader["Gender"],
                            Email = (string)reader["Email"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            Address = (string)reader["Address"],
                            Position = (string)reader["Position"],
                            JoiningDate = (DateTime)reader["JoiningDate"],
                            TerminationDate = reader.IsDBNull(reader.GetOrdinal("TerminationDate")) ? (DateTime?)null : (DateTime?)reader["TerminationDate"]
                        };
                    }
                    else
                    {
                        Console.WriteLine($"No employee found with ID {employeeId}.");
                    }
                }
                cmd.Parameters.Clear();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            return employee;
        }


        public List<Employee> GetAllEmployees()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Employee";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeID = (int)reader["EmployeeID"];
                        employee.FirstName = (string)reader["FirstName"];
                        employee.LastName = (string)reader["LastName"];
                        employee.DateOfBirth = (DateTime)reader["DateOfBirth"];
                        employee.Gender = (string)reader["Gender"];
                        employee.Email = (string)reader["Email"];
                        employee.PhoneNumber = (string)reader["PhoneNumber"];
                        employee.Address = (string)reader["Address"];
                        employee.Position = (string)reader["Position"];
                        employee.JoiningDate = (DateTime)reader["JoiningDate"];


                        if (reader["TerminationDate"] != DBNull.Value)
                        {
                            employee.TerminationDate = (DateTime)reader["TerminationDate"];
                        }
                        else
                        {
                            employee.TerminationDate = null; 
                        }


                        employees.Add(employee);
                    }
                }
                cmd.Parameters.Clear();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
            return employees;
        }

        //public void AddEmployee(Employee employee)
        //{
        //    //employees.Add(employee);
        //    //Console.Clear();
        //    //Console.WriteLine("Employee Added Successfully ... !!!");
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        if (employee.TerminationDate != null)
        //        {
        //            cmd.CommandText = "insert into Employee values(@employeeid,@first,@last,@dob,@gender,@email,@phn,@address,@posi,@jd,@td)";
        //            cmd.Parameters.AddWithValue("@employeeid", employee.EmployeeID);
        //            cmd.Parameters.AddWithValue("@first", employee.FirstName);
        //            cmd.Parameters.AddWithValue("@last", employee.LastName);
        //            cmd.Parameters.AddWithValue("@dob", employee.DateOfBirth.Date);
        //            cmd.Parameters.AddWithValue("@gender", employee.Gender);
        //            cmd.Parameters.AddWithValue("@email", employee.Email);
        //            cmd.Parameters.AddWithValue("@phn", employee.PhoneNumber);
        //            cmd.Parameters.AddWithValue("@address", employee.Address);
        //            cmd.Parameters.AddWithValue("@posi", employee.Position);
        //            cmd.Parameters.AddWithValue("@jd", employee.JoiningDate.Date);
        //            cmd.Parameters.AddWithValue("@td", employee.TerminationDate?.Date);

        //            cmd.Connection = sqlConnection;
        //            sqlConnection.Open();
        //            int addProductStatus = cmd.ExecuteNonQuery();
        //            if (addProductStatus != 0)
        //            {
        //                Console.WriteLine("Employee added successfully ...");
        //            }
        //            else
        //            {
        //                Console.WriteLine("  adding failed ...");

        //            }

        //        }

        //        else
        //        {

        //            cmd.CommandText = "insert into Employee (EmployeeID, FirstName, LastName, DateOfBirth, Gender, Email, PhoneNumber, Address, Position, JoiningDate) values (@employeeid,@first,@last,@dob,@gender,@email,@phn,@address,@posi,@jd)";
        //            cmd.Parameters.AddWithValue("@employeeid", employee.EmployeeID);
        //            cmd.Parameters.Add("@first", SqlDbType.VarChar, 20).Value =  employee.FirstName;
        //            cmd.Parameters.AddWithValue("@last", employee.LastName);
        //            cmd.Parameters.AddWithValue("@dob", employee.DateOfBirth.Date);
        //            cmd.Parameters.AddWithValue("@gender", employee.Gender);
        //            cmd.Parameters.AddWithValue("@email", employee.Email);
        //            cmd.Parameters.AddWithValue("@phn", employee.PhoneNumber);
        //            cmd.Parameters.AddWithValue("@address", employee.Address);
        //            cmd.Parameters.AddWithValue("@posi", employee.Position);
        //            cmd.Parameters.AddWithValue("@jd", employee.JoiningDate.Date);


        //            cmd.Connection = sqlConnection;
        //            sqlConnection.Open();
        //            int addProductStatus = cmd.ExecuteNonQuery();
        //            if (addProductStatus != 0)
        //            {
        //                Console.WriteLine("Employee added successfully ...");

        //            }
        //            else
        //            {
        //                Console.WriteLine("  adding failed ...");

        //            }
        //        }
        //        cmd.Parameters.Clear();

        //    }
        //}








        public int CalculateEmployeeAge(int employeeId)
        {
            Employee employee = GetEmployeeById(employeeId);
            if (employee != null)
            {
                return employee.CalculateAge();
            }
            else
            {
                // Handle if employee is not found
                Console.WriteLine("Employee not found.");
                return 0; // Return an error code or handle the absence of the employee in your own way
            }
        }















        public void AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    if (employee.TerminationDate != null)
                    {
                        cmd.CommandText = "INSERT INTO Employee VALUES(@employeeid,@first,@last,@dob,@gender,@email,@phn,@address,@posi,@jd,@td)";
                        // Add parameter values for the command
                        cmd.Parameters.AddWithValue("@employeeid", employee.EmployeeID);
                        cmd.Parameters.AddWithValue("@first", employee.FirstName);
                        cmd.Parameters.AddWithValue("@last", employee.LastName);
                        cmd.Parameters.AddWithValue("@dob", employee.DateOfBirth.Date);
                        cmd.Parameters.AddWithValue("@gender", employee.Gender);
                        cmd.Parameters.AddWithValue("@email", employee.Email);
                        cmd.Parameters.AddWithValue("@phn", employee.PhoneNumber);
                        cmd.Parameters.AddWithValue("@address", employee.Address);
                        cmd.Parameters.AddWithValue("@posi", employee.Position);
                        cmd.Parameters.AddWithValue("@jd", employee.JoiningDate.Date);
                        cmd.Parameters.AddWithValue("@td", employee.TerminationDate?.Date);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO Employee (EmployeeID, FirstName, LastName, DateOfBirth, Gender, Email, PhoneNumber, Address, Position, JoiningDate) VALUES (@employeeid,@first,@last,@dob,@gender,@email,@phn,@address,@posi,@jd)";
                        // Add parameter values for the command
                        cmd.Parameters.AddWithValue("@employeeid", employee.EmployeeID);
                        cmd.Parameters.AddWithValue("@first", employee.FirstName);
                        cmd.Parameters.AddWithValue("@last", employee.LastName);
                        cmd.Parameters.AddWithValue("@dob", employee.DateOfBirth.Date);
                        cmd.Parameters.AddWithValue("@gender", employee.Gender);
                        cmd.Parameters.AddWithValue("@email", employee.Email);
                        cmd.Parameters.AddWithValue("@phn", employee.PhoneNumber);
                        cmd.Parameters.AddWithValue("@address", employee.Address);
                        cmd.Parameters.AddWithValue("@posi", employee.Position);
                        cmd.Parameters.AddWithValue("@jd", employee.JoiningDate.Date);
                    }

                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int addProductStatus = cmd.ExecuteNonQuery();

                    if (addProductStatus != 0)
                    {
                        Console.WriteLine("Employee added successfully ...");
                    }
                    else
                    {
                        Console.WriteLine("Adding failed ...");
                    }

                    cmd.Parameters.Clear();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique key constraint violation
                {
                    Console.WriteLine("Employee with this ID already exists. Please provide a different Employee ID.");
                }
                else
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
































        public void UpdateEmployee(int employeeId, string newFirstName)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE Employee SET FirstName = @NewFirstName WHERE EmployeeID = @EmployeeID", sqlConnection);
                    cmd.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Employee with ID {employeeId} updated successfully. New first name: {newFirstName}");
                    }
                    else
                    {
                        Console.WriteLine($"No employee found with ID {employeeId} or no changes were made.");
                    }
                }
                cmd.Parameters.Clear();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }



        //public void UpdateEmployee(int employeeId, string newFirstName)
        //{
        //    Employee employeeToUpdate = employees.Find(emp => emp.EmployeeID == employeeId);

        //    if (employeeToUpdate != null)
        //    {
        //        // Found the employee with the provided ID
        //        // Prompt user for new first name and update if it's not empty or null
        //        if (!string.IsNullOrEmpty(newFirstName))
        //        {
        //            Console.WriteLine($"Employee found with ID: {employeeId}");
        //            Console.WriteLine($"Current First Name: {employeeToUpdate.FirstName}");
        //            Console.WriteLine($"Enter the new First Name for the employee:");
        //            string userInputFirstName = newFirstName;

        //            if (!string.IsNullOrEmpty(userInputFirstName))
        //            {
        //                employeeToUpdate.FirstName = userInputFirstName;
        //                Console.WriteLine($"Employee's first name updated to: {userInputFirstName}");
        //            }
        //            else
        //            {
        //                Console.WriteLine("New first name cannot be empty or null.");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("New first name cannot be empty or null.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Employee with the provided ID not found.");
        //    }
        //}






        //public void UpdateEmployee(Employee employee, int id, string fn)
        //{
        //    Employee emp = employees.Find(emp => id == employee.EmployeeID);
        //    if (emp != null)
        //    {
        //        // Update employee details
        //        // For example: emp.FirstName = employee.FirstName;
        //        // Update other properties accordingly
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Employee not found");
        //    }
        //}

        //public void RemoveEmployee(int employeeId)
        //{
        //    //Employee emp = employees.Find(emp => emp.EmployeeID == employeeId);
        //    //if (emp != null)
        //    //{
        //    //    employees.Remove(emp);
        //    //    Console.WriteLine("\nRemoved Succesully");
        //    //}
        //    //else
        //    //{
        //    //    throw new ArgumentException("Employee not found");
        //    //}


        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        cmd.CommandText = "Delete from Employee Where EmployeeID=@EmployeeID";
        //        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
        //        cmd.Connection = sqlConnection;
        //        sqlConnection.Open();
        //        int deleteProductStatus = cmd.ExecuteNonQuery();
        //        if (deleteProductStatus > 0) 
        //        {

        //            Console.WriteLine("Removed Successfully ... ");

        //        }
        //        else 
        //        { 

        //            Console.WriteLine("Failed"); 
        //        }

        //    }


        //}
        public void RemoveEmployee(int employeeId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int deleteProductStatus = cmd.ExecuteNonQuery();
                    if (deleteProductStatus > 0)
                    {
                        Console.WriteLine("Removed Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No employee found with the provided ID or deletion failed.");
                    }
                }
                cmd.Parameters.Clear();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }


    }
}
