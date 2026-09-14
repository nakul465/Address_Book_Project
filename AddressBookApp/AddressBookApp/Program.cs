// See https://aka.ms/new-console-template for more information
using AddressBookApp.Models;
using AddressBookApp.Services;

AddressBook book = new AddressBook();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("--------------Menu--------------");
    Console.WriteLine();
    Console.WriteLine("1. Add Contact\n2. Show All Contact\n3. Edit Contact\n4. Remove Contact\n0. Exit");
    Console.WriteLine();

    int input = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
    if (input == 1)
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

        Contact c = new Contact(firstName!, lastName!, address!, city!, state!, zip!, phoneNumber!, email!);
        book.AddContact(c);
    }
    else if (input == 2)
    {
        book.PrintAll();
    }
    else if (input == 3)
    {
        book.EditContact();
    }else if (input == 4)
    {
        book.RemoveContact();
    }
    else if (input == 0)
    {
        break;
    }

}