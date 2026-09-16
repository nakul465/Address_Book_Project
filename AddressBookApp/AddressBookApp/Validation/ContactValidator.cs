using System;
using System.Text.RegularExpressions;
using AddressBookApp.Models;
using AddressBookApp.Exceptions;

namespace AddressBookApp.Validation
{
	public class ContactValidator
	{
        private static string namePattern = @"^[A-Z][A-Za-z]{2,}$";
        private static string addressPattern = @"^.{4,}$";
        private static string zipPattern = @"^[0-9]{6}$";
        private static string phonePattern = @"^[0-9]{10}$";
        private static string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        private static bool IsValidName(string firstName)
        {
            return Regex.IsMatch(firstName, namePattern);
        }

        private static bool IsValidAddress(string lastName)
        {
            return Regex.IsMatch(lastName, addressPattern);
        }

        private static bool IsValidZip(string zip)
        {
            return Regex.IsMatch(zip, zipPattern);
        }

        private static bool IsValidPhone(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, emailPattern);
        }

        public static void Validate(Contact c)
		{
			if(!IsValidName(c.FirstName)) throw new InvalidContactException("Error: InvalidContactException: First name must start with a capital letter and be at least 3 characters.");

            if (!IsValidName(c.LastName)) throw new InvalidContactException("Error: InvalidContactException: Last name must start with a capital letter and be at least 3 characters.");

            if (!IsValidAddress(c.Address)) throw new InvalidContactException("Error: InvalidContactException: Address must have at least 4 characters.");

            if (!IsValidAddress(c.City)) throw new InvalidContactException("Error: InvalidContactException: City must have at least 4 characters.");

            if (!IsValidAddress(c.State)) throw new InvalidContactException("Error: InvalidContactException: State must have at least 4 characters.");

            if (!IsValidZip(c.Zip)) throw new InvalidContactException("Error: InvalidContactException: ZIP must have exactly 6 digits");

            if (!IsValidPhone(c.PhoneNumber)) throw new InvalidContactException("Error: InvalidContactException: Phone number must have exactly 10 digits");

            if (!IsValidEmail(c.Email)) throw new InvalidContactException("Error: InvalidContactException: Invalid Email Format");
        }

	}
}

