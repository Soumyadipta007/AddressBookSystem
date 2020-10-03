using System;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            takeInputAndAddToContacts(addressBook);
            takeInputAndAddToContacts(addressBook);
            addressBook.print();
            Console.WriteLine("Enter FirstName of Contact to be edited");
            string firstNameOfContactToBeEdited = Console.ReadLine();
            Console.WriteLine("Enter LastName of Contact to be edited");
            string lastNameOfContactToBeEdited = Console.ReadLine();
            addressBook.edit(firstNameOfContactToBeEdited, lastNameOfContactToBeEdited);
        }
        public static void takeInputAndAddToContacts(AddressBook addressBook)
        {
            Console.WriteLine("Enter FirstName");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter LastName");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter PhoneNumber");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Email id");
            string email = Console.ReadLine();
            addressBook.addContacts(firstName, lastName, address, city, state, zip, phoneNumber, email);
        }
    }
}
