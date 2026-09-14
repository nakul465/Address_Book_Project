using System;
using AddressBookApp.Models;
namespace AddressBookApp.Services
{
	public class AddressBook
	{
        private static int addressBookCount = 1;
        public int AddressBookId { get; }

		private List<Contact> contacts;

        private int count;
        public  int Count { get { return count; } }

		public AddressBook()
		{
            AddressBookId = addressBookCount++;
            count = 0;
			contacts = new();
		}

		public void AddContact(Contact c)
		{
            bool isPresent = contacts.Any(b => b.FirstName.Equals(c.FirstName,StringComparison.OrdinalIgnoreCase) && b.LastName.Equals(c.LastName,StringComparison.OrdinalIgnoreCase));
            if (isPresent)
            {
                Console.WriteLine($"Contact '{c.FirstName} {c.LastName}' already exists. Duplicate not added.");
                return;
            }
			contacts.Add(c);
            count++;
			Console.WriteLine("Contact Added Successfully");
		}

		public void EditContact()
		{
            Console.Write("Enter first name to edit: ");
            string? fs = Console.ReadLine();

            Console.Write("Enter Last name to edit: ");
            string? ls = Console.ReadLine();

            Contact? c = contacts.FirstOrDefault(c => c.FirstName.Equals(fs, StringComparison.OrdinalIgnoreCase) && c.LastName.Equals(ls, StringComparison.OrdinalIgnoreCase));

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

            Contact? c = contacts.FirstOrDefault(c=>c.FirstName.Equals(fs, StringComparison.OrdinalIgnoreCase) && c.LastName.Equals(ls, StringComparison.OrdinalIgnoreCase));
            if (c == null)
            {
                Console.WriteLine("Contact not found");
            }
            else
            {
                contacts.Remove(c);
                count--;
                Console.WriteLine("Contact deleted.");
            }
        }

        public List<Contact> GetContacts()
        {
            return contacts;
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

