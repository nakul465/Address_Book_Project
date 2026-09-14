using System;
using AddressBookApp.Models;

namespace AddressBookApp.Services
{
	public class AddressBookMain
	{
		private List<AddressBook> books;
		public AddressBookMain()
		{
			books = new();
		}

		public void AddBook(AddressBook book)
		{
			books.Add(book);
			Console.WriteLine("Book added Successfully");
		}

		public void FindPersonByCity()
		{
			Console.Write("Enter City to search: ");
			string? city = Console.ReadLine();
			List<Contact> res = new();
			foreach(AddressBook b in books)
			{
				List<Contact> temp = b.GetContacts().Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
				res.AddRange(temp);
			}
			Console.WriteLine($"Found {res.Count} contact(s):");
			foreach(Contact c in res)
			{
				Console.WriteLine(c.ToString());
			}
		}

        public void FindPersonByState()
        {
            Console.Write("Enter State to search: ");
            string? state = Console.ReadLine();
            List<Contact> res = new();
            foreach (AddressBook b in books)
            {
                List<Contact> temp = b.GetContacts().Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase)).ToList();
                res.AddRange(temp);
            }
            Console.WriteLine($"Found {res.Count} contact(s):");
            foreach (Contact c in res)
            {
                Console.WriteLine(c.ToString());
            }
        }

        public AddressBook FindBook()
		{
			Console.WriteLine("Enter Address Book's Id you want to find: ");
			int id = Convert.ToInt32(Console.ReadLine());
			AddressBook? book = books.FirstOrDefault(b => b.AddressBookId == id);
			return book!;
		}

		public void GroupByCityOrState()
		{
			var groupsCity = books.SelectMany(b => b.GetContacts()).GroupBy(c => c.City);
			Console.WriteLine("--- By City ---");
			Console.WriteLine();
			foreach( var group in groupsCity)
			{
				Console.WriteLine(group.Key+":");
				foreach(Contact c in group)
				{
					Console.WriteLine($"    {c.FirstName} {c.LastName}");
				}
                Console.WriteLine();
            }

            var groupsState = books.SelectMany(b => b.GetContacts()).GroupBy(c => c.State);
            Console.WriteLine("--- By State ---");
            Console.WriteLine();
            foreach (var group in groupsState)
            {
                Console.WriteLine(group.Key + ":");
                foreach (Contact c in group)
                {
                    Console.WriteLine($"    {c.FirstName} {c.LastName}");
                }
                Console.WriteLine();
            }
        }

		public int TotalContacts()
		{
			int result = books.Sum(b => b.Count);
			return result;
		}
	}
}

