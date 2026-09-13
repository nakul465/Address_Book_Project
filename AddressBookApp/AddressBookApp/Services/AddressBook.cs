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

		public void PrintAll()
		{
			foreach(Contact c in contacts)
			{
				Console.WriteLine(c.ToString());
			}
        }
	}
}

