using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.entity;

namespace PayXpert.Repository
{
    public interface IFinancialRecordService
    {

        void AddFinancialRecord(FinancialRecord record);
        FinancialRecord GetFinancialRecordById(int recordId);
        List<FinancialRecord> GetFinancialRecordsForEmployee(int employeeId);
        List<FinancialRecord> GetFinancialRecordsForDate(DateTime date);


    }
}
