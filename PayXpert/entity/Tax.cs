using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.entity
{
    public class Tax
    {

        public int TaxID { get; set; }
        public int EmployeeID { get; set; }
        public int TaxYear { get; set; }
        public int TaxableIncome { get; set; }
        public int TaxAmount { get; set; }
        public Tax(int taxID, int employeeID, int taxYear, int taxableIncome, int taxAmount)
        {
            TaxID = taxID;
            EmployeeID = employeeID;
            TaxYear = taxYear;
            TaxableIncome = taxableIncome;
            TaxAmount = taxAmount;
        }
        public Tax() { }

    }
}
