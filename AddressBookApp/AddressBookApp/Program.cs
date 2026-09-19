// See https://aka.ms/new-console-template for more information
using AddressBookApp.Models;
using AddressBookApp.Services;

AddressBookMain books = new AddressBookMain();
AddressBook book = new AddressBook();
books.AddBook(book);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("--------------Menu--------------");
    Console.WriteLine();
    Console.WriteLine("1. Add Contact\n2. Show All Contact\n3. Edit Contact\n4. Remove Contact\n5. Add new Address Book\n6. Switch to Another Existing Address Book\n7. Contact Count in current Address Book\n8. Total number of Contacts in all Address Books\n9. Search by City\n10. Search by State\n11. View by City/State\n12. Count by City/State\n13. Sort by Name\n14. Sort by City / State / Zip\n0. Exit");
    Console.WriteLine();
    int input;
    Console.Write(">");
    try
    {
        input = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        break;
    }
    
    Console.WriteLine();
    switch (input)
    {
        case 1:
            Contact c = book.CreateContact();
            book.AddContact(c);
            break;
        case 2:
            book.PrintAll();
            break;
        case 3:
            book.EditContact();
            break;
        case 4:
            book.RemoveContact();
            break;
        case 5:
            book = new AddressBook();
            books.AddBook(book);
            Console.WriteLine($"New Address Book successfully Created with id {book.AddressBookId}");
            break;
        case 6:
            AddressBook temp = books.FindBook();
            if (temp != null)
                book = temp;
            else
                Console.WriteLine("Book with the given id not found");
            break;
        case 7:
            Console.WriteLine($"Total no of contacts in current Address Book: {book.Count}");
            break;
        case 8:
            Console.WriteLine(books.TotalContacts());
            break;
        case 9:
            books.FindPersonByCity();
            break;
        case 10:
            books.FindPersonByState();
            break;
        case 11:
            books.GroupByCityOrState();
            break;
        case 12:
            books.CountByCityOrState();
            break;
        case 13:
            books.SortByName();
            break;
        case 14:
            Console.WriteLine("Which Field to sort by :\n1. City\n2. State\n3. ZIP");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n == 1)
                books.SortByCity();
            else if (n == 2)
                books.SortByState();
            else if (n == 3)
                books.SortByZip();
            else
                Console.WriteLine("Invalid Input");

            break;
        case 0:
            return;
        default:
            Console.WriteLine("Invalid Input");
            break;
    }
}
