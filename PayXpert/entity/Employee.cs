using PayXpert.Exceptions;
using PayXpert.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.entity
{
    public class Employee
    {

        //int employeeID;
        //string firstName;
        //string lastName;
        //DateTime dateOfBirth;
        //string gender;
        //string email;
        //string phoneNumber;
        //string address;
        //string position;
        //DateTime joiningDate;
        //DateTime? terminationDate;


        public Employee(int employeeID, string firstName, string lastName, DateTime dateOfBirth, string gender,
                        string email, string phoneNumber, string address, string position, DateTime joiningDate,
                        DateTime? terminationDate)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Position = position;
            JoiningDate = joiningDate;
            TerminationDate = terminationDate;
        }

        public Employee()
        {  //sqlConnection = new SqlConnection("Server=DESKTOP-0TE71RT;Database=PRODUCTAPPDB;Trusted_Connection=True");
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public int EmployeeID
        {
            get;
            set;  
        }

        public string FirstName
        {
        get;
        set;
    }

        public string LastName
        {
        get;
        set;
    }

        public DateTime DateOfBirth
        {
        get;
        set;
    }

        public string Gender
        {
        get;
        set;
    }

        public string Email
        {
        get;
        set;
    }

        public string PhoneNumber
        {
        get;
        set;
    }

        public string Address
        {
        get;
        set;
    }

        public string Position
        {
        get;
        set;
    }

        public DateTime JoiningDate
        {
        get;
        set;
    }

        public DateTime? TerminationDate
        {
        get;
        set;
    }

        //public int CalculateAge()
        //{
        //    DateTime today = DateTime.Today;
        //    int age = today.Year - DateOfBirth.Year;
        //    if (DateOfBirth.Year > today.AddYears(-age)) age--;
        //    return age;
        //}

        public string connectionString;
        SqlCommand cmd = null;

      

        public int CalculateAge()
        {
            try
            {
                int age = 0;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DateOfBirth FROM Employee WHERE EmployeeID = @EmployeeID", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", this.EmployeeID);

                        sqlConnection.Open();
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            DateTime dob = Convert.ToDateTime(result);
                            age = CalculateAgeFromDOB(dob);
                        }
                        else
                        {
                            throw new EmployeeNotFoundException("Employee with this ID does not exist.");
                        }
                    }
                }
                return age;
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0; // Return an error code or handle the absence of the employee in your own way
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return 0; // Return an error code or handle the exception in your own way
            }
        }

        private int CalculateAgeFromDOB(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;

            if (dob > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }



    }
}
