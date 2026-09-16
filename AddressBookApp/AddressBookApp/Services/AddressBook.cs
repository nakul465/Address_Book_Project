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

        public Contact CreateContact()
        {
            Console.Write("Enter First Name: ");
            string? firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string? lastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            string? address = Console.ReadLine();
            Console.Write("Enter City Name: ");
            string? city = Console.ReadLine();
            Console.Write("Enter State Name: ");
            string? state = Console.ReadLine();
            Console.Write("Enter ZIP Code: ");
            string? zip = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string? phoneNumber = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            string? email = Console.ReadLine();

            return new Contact(firstName!, lastName!, address!, city!, state!, zip!, phoneNumber!, email!);
        }

		public void AddContact(Contact c)
		{
            bool isPresent = contacts.Any(b => b.FirstName.Equals(c.FirstName,StringComparison.OrdinalIgnoreCase) && b.LastName.Equals(c.LastName,StringComparison.OrdinalIgnoreCase));
            if (isPresent)
            {
                Console.WriteLine($"Contact '{c.FirstName} {c.LastName}' already exists. Duplicate not added.");
                return;
            }
            else if (!c.IsValid)
            {
                Console.WriteLine("Inavlid Contact");
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
                if (address == "")
                {
                    address = c.Address;
                }

                Console.Write("Enter City to edit: ");
                string? city = Console.ReadLine();
                if (city == "")
                {
                    city = c.City;
                }

                Console.Write("Enter State to edit: ");
                string? state = Console.ReadLine();
                if (state == "")
                {
                    state = c.State;
                }

                Console.Write("Enter ZIP to edit: ");
                string? zip = Console.ReadLine();
                if (zip == "")
                {
                    zip = c.Zip;
                }

                Console.Write("Enter Phone Number to edit: ");
                string? phone = Console.ReadLine();
                if (phone == "")
                {
                    phone = c.PhoneNumber;
                }

                Console.Write("Enter Email to edit: ");
                string? email = Console.ReadLine();
                if (email == "")
                {
                    email = c.Email;
                }

                Contact temp = new Contact(c.FirstName,c.LastName,address!,city!,state!,zip!,phone!,email!);

                if (temp.IsValid)
                {
                    c.Address = address!;
                    c.City = city!;
                    c.State = state!;
                    c.Zip = zip!;
                    c.PhoneNumber = phone!;
                    c.Email = email!;
                    Console.WriteLine("Contact Updated");
                }
                
                
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

