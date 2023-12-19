using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.entity
{
    public class FinancialRecord
    {

         //int recordID;
         //int employeeID;
         //DateTime recordDate;
         //string description;
         //decimal amount;
         //string recordType;


        public FinancialRecord(int recordID, int employeeID, DateTime recordDate, string description, int amount, string recordType)
        {
            RecordID = recordID;
            EmployeeID = employeeID;
            RecordDate = recordDate;
            Descriptions = description;
            Amount = amount;
            RecordType = recordType;
        }

        public FinancialRecord() { }    

        public int RecordID
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            set;
        }

        public DateTime RecordDate
        {
            get;
            set;
        }

        public string Descriptions
        {
            get;
            set;
        }

        public int Amount
        {
            get;
            set;
        }

        public string RecordType
        {
            get;
            set;
        }

    }
}
