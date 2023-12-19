using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.entity
{
    public class Payroll
    {
         

        public Payroll(int payrollID, int employeeID, DateTime payPeriodStartDate, DateTime payPeriodEndDate,
                       decimal basicSalary, int overtimePay, int deductions, int netSalary)
        {
            PayrollID = payrollID;
            EmployeeID = employeeID;
            PayPeriodStartDate = payPeriodStartDate;
            PayPeriodEndDate = payPeriodEndDate;
            BasicSalary = basicSalary;
            OvertimePay = overtimePay;
            Deductions = deductions;
            NetSalary = netSalary;
        }

        public Payroll() { }
        public int PayrollID
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            set;
        }

        public DateTime PayPeriodStartDate
        {
            get;
            set;
        }

        public DateTime PayPeriodEndDate
        {
            get;
            set;
        }

        public decimal BasicSalary
        {
            get;
            set;
        }

        public decimal OvertimePay
        {
            get;
            set;
        }

        public int Deductions
        {
            get;
            set;
        }

        public int NetSalary
        {
            get;
            set;
        }

    }
}
