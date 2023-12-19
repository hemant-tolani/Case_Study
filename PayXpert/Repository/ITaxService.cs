using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.entity;

namespace PayXpert.Repository
{
    public interface ITaxService
    {

        void CalculateTax(Tax tax);
        Tax GetTaxById(int taxId);
        List<Tax> GetTaxesForEmployee(int employeeId);
        List<Tax> GetTaxesForYear(int year);

    }
}
