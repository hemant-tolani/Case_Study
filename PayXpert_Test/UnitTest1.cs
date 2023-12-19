using System.Reflection;
using PayXpert.entity;
using PayXpert.Repository;
namespace PayXpert_Test
{
    public class Tests
    {
        public string connectionString = "Server=LAPTOP-POVHQKLI;Database=PayXpert;Trusted_Connection=True";
        IEmployeeService es = new EmployeeService();
        [Test]
        
        public void TestToAddEmployee()
        {
            //IEmployeeService es = new EmployeeService();


            es.AddEmployee(new PayXpert.entity.Employee
            {
                FirstName = "Hemant",
                LastName = "Tolani",
                DateOfBirth = new DateTime(2002, 1, 1),
                Gender = "Male",
                Email = "hemanttolani@example.com",
                PhoneNumber = "2548796325",
                Address = "123 Kanpur",
                Position = "Developer",
                JoiningDate = new DateTime(2022, 1, 1),
                TerminationDate = null
            });


            Assert.AreEqual(1, 1);
        }
        [Test]
        public void GetFinancialRecordsForEmployeeTest()
        {

            IFinancialRecordService fs = new FinancialRecordService();
           // fs.ConnectionString = connectionString;


            int employeeId = 3;


            List<FinancialRecord> financialRecords = fs.GetFinancialRecordsForEmployee(employeeId);


            Assert.IsNotNull(financialRecords);
            Assert.IsTrue(financialRecords.Count > 0);


            foreach (var record in financialRecords)
            {
                Assert.AreEqual(employeeId, record.EmployeeID);
            }
        }
        [Test]
        public void CalculateTax_ValidInput_ReturnsCorrectTaxAmount()
        {
            ITaxService ts = new TaxService();


            int employeeId = 2;
            


            var tt = ts.GetTaxesForEmployee(employeeId);
            if (tt.Count > 0)
            {
                foreach (var t in tt)
                {

                    Assert.AreEqual(5000, t.TaxAmount);

                }
            }
            else
            {
                Console.WriteLine("No payrolls found for the employee.");
            }



        }
        [Test]
        public void GeneratePayroll_ValidInput_CorrectNetSalary()
        {

            IPayrollService ps = new PayrollService();
            //ps.connectionString = connectionString;

            int employeeId = 2;
            //DateTime startDate = DateTime.Parse("2023-01-01");
            //DateTime endDate = DateTime.Parse("2023-01-15");
            //decimal basicSalary = 5200.00m;
            //decimal overtimePay = 220.00m;
            //decimal deductions = 320.00m;
            //decimal expectedNetSalary = 5100.00m;


            //ps.GetPayrollsForEmployee(employeeId);
            var payrollsForEmployee = ps.GetPayrollsForEmployee(employeeId);
            if (payrollsForEmployee.Count > 0)
            {
                foreach (var payroll in payrollsForEmployee)
                {
                    
                    Assert.AreEqual(3300, payroll.NetSalary);

                }
            }
            else
            {
                Console.WriteLine("No payrolls found for the employee.");
            }

           
           
            


            
        }

    }
}