// See https://aka.ms/new-console-template for more information
using AddressBookApp;
using AddressBookApp.Models;

Contact person1 = new Contact("John","Doe", "12 MG Road","Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");

Console.WriteLine(person1.ToString());