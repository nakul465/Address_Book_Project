using System;
using AddressBookApp.Models;
namespace AddressBookApp.Services
{
	public class AddressBook
	{
		private List<Contact> contacts;

		public AddressBook()
		{
			contacts = new();
		}

		public void AddContact(Contact c)
		{
			contacts.Add(c);
			Console.WriteLine("Contact Added Successfully");
		}

		public void EditContact()
		{
            Console.Write("Enter first name to edit: ");
            string? fs = Console.ReadLine();

            Console.Write("Enter Last name to edit: ");
            string? ls = Console.ReadLine();

            Contact? c = contacts.FirstOrDefault(c => c.FirstName == fs && c.LastName == ls);

			if (c == null) Console.WriteLine("Contact not found");
			else
			{
                Console.Write("Enter Address to edit: ");
                string? address = Console.ReadLine();
                if (address != "")
                {
                    c.Address = address!;
                }

                Console.Write("Enter City to edit: ");
                string? city = Console.ReadLine();
                if (city != "")
                {
                    c.City = city!;
                }

                Console.Write("Enter State to edit: ");
                string? state = Console.ReadLine();
                if (state != "")
                {
                    c.State = state!;
                }

                Console.Write("Enter ZIP to edit: ");
                string? zip = Console.ReadLine();
                if (zip != "")
                {
                    c.Zip = zip!;
                }

                Console.Write("Enter Phone Number to edit: ");
                string? phone = Console.ReadLine();
                if (phone != "")
                {
                    c.PhoneNumber = phone!;
                }

                Console.Write("Enter Email to edit: ");
                string? email = Console.ReadLine();
                if (email != "")
                {
                    c.Email = email!;
                }

                Console.WriteLine("Contact Updated");
            }
		}

        public void RemoveContact()
        {
            Console.Write("Enter first name to delete: ");
            string? fs = Console.ReadLine();
            Console.Write("Enter last name to delete: ");
            string? ls = Console.ReadLine();

            Contact? c = contacts.FirstOrDefault(c=>c.FirstName==fs && c.LastName==ls);
            if (c == null)
            {
                Console.WriteLine("Contact not found");
            }
            else
            {
                contacts.Remove(c);
                Console.WriteLine("Contact deleted.");
            }
        }

		public void PrintAll()
		{
			foreach(Contact c in contacts)
			{
				Console.WriteLine(c.ToString());
			}
        }
	}
}

