using System;
namespace AddressBookApp.Exceptions
{
	public class InvalidContactException:Exception
	{
		public InvalidContactException(string msg):base(msg)
		{
		}
	}
}

