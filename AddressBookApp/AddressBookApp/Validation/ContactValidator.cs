using System;
using System.Text.RegularExpressions;
using AddressBookApp.Models;
using AddressBookApp.Exceptions;

namespace AddressBookApp.Validation
{
	public class ContactValidator
	{

		public static void Validate(Contact c)
		{
			string namePattern = @"^[A-Z][A-Za-z]{2,}$";

			if(!Regex.IsMatch(c.FirstName, namePattern))
			{
				throw new InvalidContactException("Error: InvalidContactException: First name must start with a capital letter and be at least 3 characters.");
            }

            if (!Regex.IsMatch(c.LastName, namePattern))
            {
                throw new InvalidContactException("Error: InvalidContactException: Last name must start with a capital letter and be at least 3 characters.");
            }


            string addressPattern = @"^.{4,}$";

            if (!Regex.IsMatch(c.Address, addressPattern))
            {
                throw new InvalidContactException("Error: InvalidContactException: Address must have at least 4 characters.");
            }

            if (!Regex.IsMatch(c.City, addressPattern))
            {
                throw new InvalidContactException("Error: InvalidContactException: City must have at least 4 characters.");
            }

            if (!Regex.IsMatch(c.State, addressPattern))
            {
                throw new InvalidContactException("Error: InvalidContactException: State must have at least 4 characters.");
            }

            string zipPattern = @"^[0-9]{6}$";

            if (!Regex.IsMatch(c.Zip, zipPattern))
            {
                throw new InvalidContactException("Error: InvalidContactException: ZIP must have exactly 6 digits");
            }

            string phonePattern=@"^[0-9]{10}$";

            if (!Regex.IsMatch(c.PhoneNumber, phonePattern))
            {
                throw new InvalidContactException("Error: InvalidContactException: Phone number must have exactly 10 digits");
            }

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(c.Email, emailPattern))
            {
                throw new InvalidContactException("Error: InvalidContactException: Invalid Email Format");
            }
        }

	}
}

