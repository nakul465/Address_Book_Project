using System;
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

		public AddressBook FindBook()
		{
			Console.WriteLine("Enter Address Book's Id you want to find: ");
			int id = Convert.ToInt32(Console.ReadLine());
			AddressBook? book = books.FirstOrDefault(b => b.AddressBookId == id);
			return book!;
		}

		public int TotalContacts()
		{
			int result = books.Sum(b => b.Count);
			return result;
		}
	}
}

