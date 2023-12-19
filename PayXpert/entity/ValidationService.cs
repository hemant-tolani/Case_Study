using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.entity
{
    internal class ValidationService
    {

        public bool IsValidEmail(string email)
        {
            // This is a basic example of email validation using a simple pattern matching
            // You can use more sophisticated validation based on your requirements
            return !string.IsNullOrEmpty(email) && email.Contains("@") && email.Contains(".");
        }

        // Validate if a phone number is in a valid format
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            // This is a basic example of phone number validation
            // You can use regex or more detailed validation based on specific phone number formats
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length >= 10;
        }

        // Validate if a date of birth indicates the person is of a valid age
        public bool IsValidDateOfBirth(DateTime dateOfBirth)
        {
            // Example: Check if the person is at least 18 years old
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - dateOfBirth.Year;
            if (dateOfBirth > currentDate.AddYears(-age)) age--;
            return age >= 18;
        }

    }
}
