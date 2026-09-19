using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Services;
using AddressBookApp.Validation;

namespace AddressBookAppTesting;

public class AddressBookTests
{
    private Contact ValidContact() => new Contact("Nakul", "Arora", "12 MG Road", "Rewari","Haryana", "123456", "9876543210", "nakul@example.com");

    private Contact ValidContact(string first = "Nakul", string last = "Arora")=> new Contact(first, last, "12 MG Road", "Rewari","Haryana", "123456", "9876543210",$"{first.ToLower()}@example.com");

    private Contact ValidContact(string first, string last, string city, string state) => new Contact(first, last, "12 MG Road", city, state, "123456", "9876543210", $"{first.ToLower()}@example.com");

    [Test]
    public void ValidContact_ShouldBeTrue()
    {
        var contact = ValidContact();
        Assert.That(contact.IsValid, Is.True);
    }

    [Test]
    public void InvalidZip_ShouldBeFalse()
    {
        var contact = new Contact("Nakul", "Arora", "12 MG Road", "Rewari","Haryana", "12345", "9876543210", "nakul@example.com");

        Assert.That(contact.IsValid, Is.False);
    }

    [Test]
    public void InvalidZip_WhenValidatorCalled_ShouldThrowInvalidContactException()
    {
        var contact = new Contact("Nakul", "Arora", "12 MG Road", "Rewari","Haryana", "12345", "9876543210", "nakul@example.com");

        var ex = Assert.Throws<InvalidContactException>(() => ContactValidator.Validate(contact));

        Assert.That(ex!.Message, Does.Contain("ZIP"));
    }

    [Test]
    public void NullFirstName_WhenValidatorCalled_ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new Contact(null!, "Arora", "12 MG Road", "Rewari", "Haryana", "123456", "9876543210", "nakul@example.com"));
    }

    [Test]
    public void AddValidContact_ShouldIncreaseCount()
    {
        var book = new AddressBook();
        var contact = ValidContact();

        book.AddContact(contact);

        Assert.That(book.Count, Is.EqualTo(1));
        Assert.That(book.GetContacts(), Does.Contain(contact));
    }

    [Test]
    public void AddInvalidContact_ShouldNotIncreaseCount()
    {
        var book = new AddressBook();
        var contact = new Contact("Nakul", "Arora", "12 MG Road", "Rewari","Haryana", "12345", "9876543210", "nakul@example.com");

        book.AddContact(contact);

        Assert.That(book.Count, Is.EqualTo(0));
    }

    [Test]
    public void AddDuplicateContact_ShouldNotIncreaseCount()
    {
        var book = new AddressBook();

        book.AddContact(ValidContact("Nakul", "Arora"));
        book.AddContact(ValidContact("nakul", "ARORA"));

        Assert.That(book.Count, Is.EqualTo(1));
    }

    [Test]
    public void NewAddressBook_ShouldHaveZeroContacts()
    {
        var book = new AddressBook();

        Assert.That(book.Count, Is.EqualTo(0));
        Assert.That(book.GetContacts(), Is.Empty);
    }


    [Test]
    public void TotalContacts_ShouldReturnTotalAcrossBooks()
    {
        var main = new AddressBookMain();
        var book1 = new AddressBook();
        var book2 = new AddressBook();

        book1.AddContact(ValidContact("Nakul", "Arora", "Rewari", "Haryana"));
        book1.AddContact(ValidContact("Manish", "Bansal", "Delhi", "Delhi"));
        book2.AddContact(ValidContact("Manan", "Goel", "Rewari", "Haryana"));

        main.AddBook(book1);
        main.AddBook(book2);

        Assert.That(main.TotalContacts(), Is.EqualTo(3));
    }

    [Test]
    public void TotalContacts_WithEmptyBooks_ShouldReturnZero()
    {
        var main = new AddressBookMain();
        main.AddBook(new AddressBook());
        main.AddBook(new AddressBook());

        Assert.That(main.TotalContacts(), Is.EqualTo(0));
    }

    [Test]
    public void InvalidFirstName_ShouldThrowInvalidContactException()
    {
        var contact = new Contact("na", "Arora", "12 MG Road", "Rewari","Haryana", "123456", "9876543210", "nakul@example.com");

        Assert.Throws<InvalidContactException>(() => ContactValidator.Validate(contact));
    }

    [Test]
    public void InvalidEmail_ShouldThrowInvalidContactException()
    {
        var contact = new Contact("Nakul", "Arora", "12 MG Road", "Rewari","Haryana", "123456", "9876543210", "not-an-email");

        Assert.Throws<InvalidContactException>(() => ContactValidator.Validate(contact));
    }

    [Test]
    public void InvalidPhone_ShouldThrowInvalidContactException()
    {
        var contact = new Contact("Nakul", "Arora", "12 MG Road", "Rewari","Haryana", "123456", "12345", "nakul@example.com");

        Assert.Throws<InvalidContactException>(() => ContactValidator.Validate(contact));
    }
}
