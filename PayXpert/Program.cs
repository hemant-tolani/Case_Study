using PayXpert.entity;
using PayXpert.Repository;
using System.Net;
using System.Reflection;
using System.Threading;
Console.WriteLine("\n\t\t\t\t\t--- WELCOME TO PayXpert ---\t\t\t\t");

Console.CursorVisible = false;
bool blinking = true;

Thread blinkThread = new Thread(() =>
{
    while (blinking)
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write("Press enter to continue   ");
        Thread.Sleep(500);

        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write("                          ");
        Thread.Sleep(500);
    }
});

blinkThread.Start();
Console.ReadKey(true);
blinking = false;
blinkThread.Join();
Console.Clear();
string c = "y";
IEmployeeService es = new EmployeeService();
IPayrollService ps = new PayrollService();
ITaxService ts = new TaxService();
IFinancialRecordService fs = new FinancialRecordService();

do
{
   label1: Console.WriteLine("\n\t\t\t\t\t--- WELCOME TO PayXpert ---\t\t\t\t");
    Console.WriteLine("1 for Employee");
    Console.WriteLine("2 for Payroll");
    Console.WriteLine("3 for Tax");
    Console.WriteLine("4 for Financial");
    Console.WriteLine("5 for Exit");
    int option1 = int.Parse(Console.ReadLine());
    Console.Clear();

    switch (option1)
    {

        case 1:


            string ch = "y";

            do
            {
                Console.WriteLine("\n\t\t\t\t\t--- WELCOME TO PayXpert ---\t\t\t\t");
                Console.WriteLine("1 for Add Employess");
                Console.WriteLine("2 for Update Employess");
                Console.WriteLine("3 for Delete Employess");
                Console.WriteLine("4 for View Employess");
                Console.WriteLine("5 for GetEmployeeById");
                Console.WriteLine("6 for CalculateAge");
                Console.WriteLine("7 for Main Menu");
                int option = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter Employee ID ...");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter First Name ...");
                        string firstname = Console.ReadLine();
                        Console.WriteLine("\nEnter Last Name ...");
                        string lastname = Console.ReadLine();
                        Console.WriteLine("\nEnter the DATE of DOB ...");
                        int date = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the MONTH of DOB ...");
                        int month = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the YEAR of DOB ...");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the Gender ...");
                        string gen = Console.ReadLine();
                        Console.WriteLine("\nEnter the Email-Id ...");
                        string mail = Console.ReadLine();
                        Console.WriteLine("\nEnter the Phone Number ...");
                        string phn = Console.ReadLine();
                        Console.WriteLine("\nEnter the Address ...");
                        string address = Console.ReadLine();
                        Console.WriteLine("\nEnter the Position ...");
                        string posi = Console.ReadLine();
                        Console.WriteLine("\nEnter the DATE of Joining ...");
                        int d = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the MONTH of Joining ...");
                        int m = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the YEAR of Joining ...");
                        int y = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nDo you have Termination Date ??? (Y/N)");
                        string yes = Console.ReadLine();
                        if (yes == "Y")
                        {
                            Console.WriteLine("\nEnter the DATE of Termination ...");
                            int d1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("\nEnter the MONTH of Termination ...");
                            int m1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("\nEnter the YEAR of Termination ...");
                            int y1 = int.Parse(Console.ReadLine());

                            Employee employee = new Employee()
                            {
                                EmployeeID = id,
                                FirstName = firstname,
                                LastName = lastname,
                                DateOfBirth = new DateTime(year, month, date),
                                Gender = gen,
                                Email = mail,
                                PhoneNumber = phn,
                                Address = address,
                                Position = posi,
                                JoiningDate = new DateTime(y, m, d),
                                TerminationDate = new DateTime(y1, m1, d1)
                            };
                                         
                            es.AddEmployee(employee);

                        }
                        else
                        {


                            Employee employee = new Employee()
                            {
                                EmployeeID = id,
                                FirstName = firstname,
                                LastName = lastname,
                                DateOfBirth = new DateTime(year, month, date),
                                Gender = gen,
                                Email = mail,
                                PhoneNumber = phn,
                                Address = address,
                                Position = posi,
                                JoiningDate = new DateTime(y, m, d),
                                TerminationDate = null
                            };
                           
                            Console.WriteLine(employee.FirstName);
                            es.AddEmployee(employee);

                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter the employee id ... !");
                        int t = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the new first name ... !");
                        string nfn = Console.ReadLine();
                        es.UpdateEmployee(t, nfn);
                        break;

                    case 3:
                        Console.WriteLine("Enter the employee id ... !");
                        int t1 = int.Parse(Console.ReadLine());
                        es.RemoveEmployee(t1);


                        break;

                    case 4:
                        //IEmployeeService es = new EmployeeService();

                        List<Employee> gae = es.GetAllEmployees();
                        //Console.WriteLine("HI");
                        //Console.WriteLine("Id   First_Name        Last_Name                 DOB                   Gender         Email          \t\tPhone_No        Address      Position   Joining_Date   Termination_Date\n");
                        //foreach (var item in gae)
                        //{
                        //    Console.WriteLine($"{item.EmployeeID}\t{item.FirstName}\t\t{item.LastName}\t\t   {item.DateOfBirth}\t\t{item.Gender}\t{item.Email}\t{item.PhoneNumber}\t{item.Address}\t     {item.Position}\t{item.JoiningDate}\t{item.TerminationDate}\n");
                        //}
                        //Console.WriteLine("Id   First_Name     Last_Name         DOB            Gender   Email             Phone_No       Address          Position       Joining_Date   Termination_Date");
                        //foreach (var item in gae)
                        //{
                        //    Console.WriteLine($"{item.EmployeeID,-4} {item.FirstName,-14} {item.LastName,-16} {item.DateOfBirth.ToString("yyyy-MM-dd"),-14} {item.Gender,-8} {item.Email,-17} {item.PhoneNumber,-14} {item.Address,-16} {item.Position,-14} {item.JoiningDate.ToString("yyyy-MM-dd"),-14} {item.TerminationDate?.ToString("yyyy-MM-dd") ?? "N/A",-16}");
                        //}
                        Console.WriteLine("Id   First_Name    Last_Name       DOB         Gender  Email             \t\tPhone_No  \t\tAddress    \tPosition    \t Joining_Date   Termination_Date");
                        foreach (var item in gae)
                        {
                            Console.WriteLine($"{item.EmployeeID,-4} {item.FirstName,-13} {item.LastName,-13} {item.DateOfBirth.ToString("yyyy-MM-dd"),-12} {item.Gender,-7} {item.Email,-17} \t\t{item.PhoneNumber,-20} {item.Address,-15} {item.Position,-12} {item.JoiningDate.ToString("yyyy-MM-dd"),-14} {item.TerminationDate?.ToString("yyyy-MM-dd") ?? "N/A",-16}");
                        }

                        gae.Clear();

                        break;


                    case 5:
                        Console.WriteLine("Enter the Employee ID:");
                        int idddd = int.Parse(Console.ReadLine());

                        // Call GetEmployeeById method and display the employee details
                        Employee emplo = es.GetEmployeeById(idddd);

                        if (emplo != null)
                        {
                            Console.WriteLine("\nEmployee Details:");
                            Console.WriteLine($"ID: {emplo.EmployeeID}");
                            Console.WriteLine($"First Name: {emplo.FirstName}");
                            Console.WriteLine($"Last Name: {emplo.LastName}");
                            Console.WriteLine($"Date of Birth: {emplo.DateOfBirth}");
                            Console.WriteLine($"Gender: {emplo.Gender}");
                            Console.WriteLine($"Email: {emplo.Email}");
                            Console.WriteLine($"Phone Number: {emplo.PhoneNumber}");
                            Console.WriteLine($"Address: {emplo.Address}");
                            Console.WriteLine($"Position: {emplo.Position}");
                            Console.WriteLine($"Joining Date: {emplo.JoiningDate}");
                            Console.WriteLine($"Termination Date: {(emplo.TerminationDate.HasValue ? emplo.TerminationDate.ToString() : "N/A")}");
                        }
                        else
                        {
                            Console.WriteLine("No employee found with the provided ID.");
                        }
                        break;

                    case 6:

                        Console.WriteLine("Enter Employee ID:");
                        if (int.TryParse(Console.ReadLine(), out int employeeId))
                        {
                            int age = es.CalculateEmployeeAge(employeeId);
                            if (age > 0)
                            {
                                Console.WriteLine($"Employee Age: {age}");
                            }
                            else
                            {
                                Console.WriteLine("Failed to calculate employee age.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Employee ID.");
                        }


                        break;


                    case 7:
                        goto label1;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Choice ... Your Highness .. !!!\nGood-Bye .. ");
                        break;


                }

                Console.WriteLine("\n\n\n\t\t\t\t\tDo you want the menu ... ?? (y/n)");
                ch = Console.ReadLine();
                Console.Clear();

            } while (ch == "y");

            break;

        case 2:

            string ch2 = "y";

            do
            {
                Console.WriteLine("\n\t\t\t\t\t--- WELCOME TO PayXpert ---\t\t\t\t");
                Console.WriteLine("1 for Generate_Payroll");
                Console.WriteLine("2 for Get_Payroll_By_Id");
                Console.WriteLine("3 for Get_Payrolls_Employee");
                Console.WriteLine("4 for Get_Payrolls_For_Period");
                Console.WriteLine("5 for Main Menu");
                int opt = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Enter Payroll ID ...");
                        int pid = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee ID ...");
                        int peid = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the DATE of Starting_of_Pay_Period ...");
                        int pdate = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the MONTH of Starting_of_Pay_Period ...");
                        int pmonth = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the YEAR of Starting_of_Pay_Period ...");
                        int pyear = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the DATE of Ending_of_Pay_Period ...");
                        int pd = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the MONTH of Ending_of_Pay_Period ...");
                        int pm = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the YEAR of Ending_of_Pay_Period ...");
                        int py = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the Basic Salary ...");
                        int pbs = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the Overtime Pay ...");
                        int pop = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the Deductions ...");
                        int pdu = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the Net Salary ...\n");
                        int pns = int.Parse(Console.ReadLine());


                        Payroll Payro = new Payroll()
                        {
                            PayrollID = pid,
                            EmployeeID = peid,
                            PayPeriodStartDate = new DateTime(pyear, pmonth, pdate),
                            PayPeriodEndDate = new DateTime(py, pm, pd),
                            BasicSalary = pbs,
                            OvertimePay = pop,
                            Deductions = pdu,
                            NetSalary = pns
                        };
                            
                        ps.GeneratePayroll(Payro);

                  
                        break;

                    case 2:
                        //Console.WriteLine("Enter Payroll_Id to Retrieve\n");
                        //int ii = int.Parse(Console.ReadLine());
                        //Payroll retrievedPayroll = ps.GetPayrollById(ii);
                        //if (retrievedPayroll != null)
                        //{
                        //    Console.WriteLine($"Payroll ID: {retrievedPayroll.PayrollID}, Employee ID: {retrievedPayroll.EmployeeID}, " +
                        //                      $"Net Salary: {retrievedPayroll.NetSalary}");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Payroll not found.");
                        //}


                        Console.WriteLine("Enter Payroll_Id to Retrieve\n");
                        int ii = int.Parse(Console.ReadLine());
                        Payroll retrievedPayroll = ps.GetPayrollById(ii);
                        if (retrievedPayroll != null)
                        {
                            Console.WriteLine($"Payroll ID: {retrievedPayroll.PayrollID}, Employee ID: {retrievedPayroll.EmployeeID}, " +
                                              $"Net Salary: {retrievedPayroll.NetSalary}");
                        }
                        else
                        {
                            Console.WriteLine("Payroll not found.");
                        }



                        break;

                    case 3:
                        Console.WriteLine("Enter Employee_Id to Retrieve Payroll\n");
                        int ii1 = int.Parse(Console.ReadLine());
                        var payrollsForEmployee = ps.GetPayrollsForEmployee(ii1);
                        if (payrollsForEmployee.Count > 0)
                        {
                            foreach (var payroll in payrollsForEmployee)
                            {
                                Console.WriteLine($"Payroll ID: {payroll.PayrollID}, Employee ID: {payroll.EmployeeID}, " +
                                                  $"Net Salary: {payroll.NetSalary}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No payrolls found for the employee.");
                        }

                        break;

                    case 4:
                        Console.WriteLine("--- Start Date ---");
                        Console.WriteLine("Enter the DATE of Starting_of_Pay_Period ...");
                        int pda = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the MONTH of Starting_of_Pay_Period ...");
                        int pmo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the YEAR of Starting_of_Pay_Period ...");
                        int pye = int.Parse(Console.ReadLine());

                        Console.WriteLine("--- End Date ---");
                        Console.WriteLine("Enter the DATE of Ending_of_Pay_Period ...");
                        int pd1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the MONTH of Ending_of_Pay_Period ...");
                        int pm1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the YEAR of Ending_of_Pay_Period ...");
                        int py1 = int.Parse(Console.ReadLine());

                        DateTime startDate = new DateTime(pye, pmo, pda);
                        DateTime endDate = new DateTime(py1, pm1, pd1);

                        var payrollsForPeriod = ps.GetPayrollsForPeriod(startDate, endDate);

                        if (payrollsForPeriod.Count > 0)
                        {
                            foreach (var payroll in payrollsForPeriod)
                            {
                                Console.WriteLine($"Payroll ID: {payroll.PayrollID}, Employee ID: {payroll.EmployeeID}, " +
                                                  $"Net Salary: {payroll.NetSalary}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No payrolls found for the specified period.");
                        }


                        break;


                    case 5:
                        goto label1;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Choice ... Your Highness .. !!!\nGood-Bye .. ");
                        break;


                }

                Console.WriteLine("\n\n\n\t\t\t\t\tDo you want the menu ... ?? (y/n)");
                ch2 = Console.ReadLine();
                Console.Clear();

            } while (ch2 == "y");

            break;


        case 3:

            string ch3 = "y";

            do
            {
                Console.WriteLine("\n\t\t\t\t\t--- WELCOME TO PayXpert ---\t\t\t\t");
                Console.WriteLine("1 for Calculate_Tax");
                Console.WriteLine("2 for Get_Tax_By_Id");
                Console.WriteLine("3 for Get_Tax_For_Employee");
                Console.WriteLine("4 for Get_Taxex_For_Year");
                Console.WriteLine("5 for Main Menu");
                int op11 = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (op11)
                {
                    case 1:
                        Console.WriteLine("Enter Tax ID ...");
                        int tid = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter Employee ID ...");
                        int teid = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the Tax Year ...");
                        int tyear = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the Taxable Income ...");
                        int tinc1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the Tax Amount ...");
                        int tamo = int.Parse(Console.ReadLine());

                        Tax tax1 = new Tax()
                        {
                            TaxID = tid, 
                            EmployeeID = teid,
                            TaxYear = tyear,
                            TaxableIncome = tinc1,
                            TaxAmount = tamo
                        };

                        ts.CalculateTax(tax1);


                        break;

                    case 2:
                        Console.WriteLine("Enter Tax ID to Retrieve:");
                        int tt = int.Parse(Console.ReadLine());

                        Tax retrievedTax = ts.GetTaxById(tt); // Assuming taxService is an instance of your TaxService

                        if (retrievedTax != null)
                        {
                            Console.WriteLine($"Tax ID: {retrievedTax.TaxID}, Employee ID: {retrievedTax.EmployeeID}, " +
                                              $"Tax Amount: {retrievedTax.TaxAmount}");
                        }
                        else
                        {
                            Console.WriteLine("Tax not found.");
                        }


                        break;

                    case 3:
                        Console.WriteLine("Enter Employee ID to Retrieve Tax:");
                        int employeeId = int.Parse(Console.ReadLine());

                        List<Tax> taxesForEmployee = ts.GetTaxesForEmployee(employeeId); // Assuming taxService is an instance of your TaxService

                        if (taxesForEmployee.Count > 0)
                        {
                            Console.WriteLine("Taxes for Employee:");
                            foreach (var tax in taxesForEmployee)
                            {
                                Console.WriteLine($"Tax ID: {tax.TaxID}, Employee ID: {tax.EmployeeID}, " +
                                                  $"Tax Amount: {tax.TaxAmount}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No taxes found for the employee.");
                        }


                        break;

                    case 4:
                        Console.WriteLine("Enter Year to Retrieve Tax:");
                        int year = int.Parse(Console.ReadLine());

                        List<Tax> taxesForYear = ts.GetTaxesForYear(year); // Assuming taxService is an instance of your TaxService

                        if (taxesForYear.Count > 0)
                        {
                            Console.WriteLine("Taxes for the Specified Year:");
                            foreach (var tax in taxesForYear)
                            {
                                Console.WriteLine($"Tax ID: {tax.TaxID}, Employee ID: {tax.EmployeeID}, " +
                                                  $"Tax Amount: {tax.TaxAmount}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No taxes found for the specified year.");
                        }


                        break;

                    case 5:
                        goto label1;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Choice ... Your Highness .. !!!\nGood-Bye .. ");
                        break;


                }

                Console.WriteLine("\n\n\n\t\t\t\t\tDo you want the menu ... ?? (y/n)");
                ch3 = Console.ReadLine();
                Console.Clear();

            } while (ch3 == "y");

            break;
        case 4:

            string chh12 = "y";

            do
            {
                Console.WriteLine("\n\t\t\t\t\t--- WELCOME TO PayXpert ---\t\t\t\t");
                Console.WriteLine("1 for Add Financial Record");
                Console.WriteLine("2 for Get_Financial_Record_By_Id");
                Console.WriteLine("3 for Get_Financial_Record_For_Employee");
                Console.WriteLine("4 for Get_Financial_Record_For_Year");
                Console.WriteLine("5 for Main Menu");
                int op1313 = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (op1313)
                {
                    case 1:
                        Console.WriteLine("Enter Record ID:");
                        int fid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Employee ID:");
                        int feid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the DAY of Record:");
                        int fd1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the MONTH of Record:");
                        int fm1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the YEAR of Record:");
                        int fy1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Description:");
                        string fdesc = Console.ReadLine();

                        Console.WriteLine("Enter the Amount:");
                        int famo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Record Type:");
                        string frc = Console.ReadLine();

                        FinancialRecord financialRecord = new FinancialRecord()
                        {
                            RecordID = fid,
                            EmployeeID = feid,
                            RecordDate = new DateTime(fy1, fm1, fd1),
                            Descriptions = fdesc,
                            Amount = famo,
                            RecordType = frc
                        };

                        fs.AddFinancialRecord(financialRecord); // Assuming financialRecordService is an instance of your FinancialRecordService



                        break;

                    case 2:
                        //Console.WriteLine("Enter Record_Id to Retrieve\n");
                        //int ttll = int.Parse(Console.ReadLine());
                        //FinancialRecord retrievedRecord = fs.GetFinancialRecordById(ttll);
                        //if (retrievedRecord != null)
                        //{
                        //    Console.WriteLine($"Record ID: {retrievedRecord.RecordID}, Employee ID: {retrievedRecord.EmployeeID}, " +
                        //                      $"Amount: {retrievedRecord.Amount}");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Financial record not found.");
                        //}


                        Console.WriteLine("Enter Record ID to Retrieve:");
                        int recordId = int.Parse(Console.ReadLine());

                        FinancialRecord retrievedRe = fs.GetFinancialRecordById(recordId); // Assuming financialRecordService is an instance of your FinancialRecordService

                        if (retrievedRe != null)
                        {
                            Console.WriteLine($"Record ID: {retrievedRe.RecordID}, Employee ID: {retrievedRe.EmployeeID}, " +
                                              $"Amount: {retrievedRe.Amount}, ");
                        }
                        else
                        {
                            Console.WriteLine("Financial record not found.");
                        }



                        break;

                    case 3:
                        //Console.WriteLine("Enter Employee_Id to Retrieve Record\n");
                        //int tt_1 = int.Parse(Console.ReadLine());
                        //var recordsForEmployee = fs.GetFinancialRecordsForEmployee(tt_1);
                        //if (recordsForEmployee.Count > 0)
                        //{
                        //    foreach (var record in recordsForEmployee)
                        //    {
                        //        Console.WriteLine($"Record ID: {record.RecordID}, Employee ID: {record.EmployeeID}, " +
                        //                          $"Amount: {record.Amount}");
                        //    }
                        //}
                        //else
                        //{
                        //    Console.WriteLine("No financial records found for the employee.");
                        //}


                        Console.WriteLine("Enter Employee ID to Retrieve Records:");
                        int employeeId = int.Parse(Console.ReadLine());

                        var recordsForEmployee = fs.GetFinancialRecordsForEmployee(employeeId); // Assuming financialRecordService is an instance of your FinancialRecordService

                        if (recordsForEmployee.Count > 0)
                        {
                            foreach (var record in recordsForEmployee)
                            {
                                Console.WriteLine($"Record ID: {record.RecordID}, Employee ID: {record.EmployeeID}, " +
                                                  $"Amount: {record.Amount}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No financial records found for the employee.");
                        }



                        break;

                    case 4:
                        //Console.WriteLine("\nEnter the DATE of Record ...");
                        //int fdd1 = int.Parse(Console.ReadLine());
                        //Console.WriteLine("\nEnter the MONTH of Record ...");
                        //int fmm1 = int.Parse(Console.ReadLine());
                        //Console.WriteLine("\nEnter the YEAR of Record ...");
                        //int fyy1 = int.Parse(Console.ReadLine());


                        //DateTime tt_t1 = new DateTime(fyy1, fmm1, fdd1);
                        //var recordsForDate = fs.GetFinancialRecordsForDate(tt_t1);
                        //if (recordsForDate.Count > 0)
                        //{
                        //    foreach (var record in recordsForDate)
                        //    {
                        //        Console.WriteLine($"Record ID: {record.RecordID}, Employee ID: {record.EmployeeID}, " +
                        //                          $"Amount: {record.Amount}");
                        //    }
                        //}
                        //else
                        //{
                        //    Console.WriteLine("No financial records found for the specified date.");
                        //}

                        Console.WriteLine("Enter the DATE of Record:");
                        int day = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the MONTH of Record:");
                        int month = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the YEAR of Record:");
                        int year = int.Parse(Console.ReadLine());

                        DateTime date = new DateTime(year, month, day);

                        var recordsForDate = fs.GetFinancialRecordsForDate(date); // Assuming financialRecordService is an instance of your FinancialRecordService

                        if (recordsForDate.Count > 0)
                        {
                            foreach (var record in recordsForDate)
                            {
                                Console.WriteLine($"Record ID: {record.RecordID}, Employee ID: {record.EmployeeID}, " +
                                                  $"Amount: {record.Amount}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No financial records found for the specified date.");
                        }



                        break;

                    case 5:
                        goto label1;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Choice ... Your Highness .. !!!\nGood-Bye .. ");
                        break;


                }

                Console.WriteLine("\n\n\n\t\t\t\t\tDo you want the menu ... ?? (y/n)");
                chh12 = Console.ReadLine();
                Console.Clear();

            } while (chh12 == "y");

            break;
        case 5:
            Console.WriteLine("Thank you for using our application. Have a great day!");
            Environment.Exit(0);
            break;


            break;
         


    }


    Console.WriteLine("\n\n\n\t\t\t\t\tDo you want the main menu ... ?? (y/n)");
    c = Console.ReadLine();
    Console.Clear();

} while (c == "y");






Console.ReadLine();
