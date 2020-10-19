namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Welcome to Address Book Program in AddressBookMain class on START Master Branch");
            Dictionary<string, AddressBook> addressBookDict = new Dictionary<string, AddressBook>();
            Console.WriteLine("How many address Book you want to add");
            int numAddressBook = Convert.ToInt32(Console.ReadLine()); 
            for(int i = 1; i <= numAddressBook; i++)
            {
                Console.WriteLine("Enter the name of address book " + i + ": ");
                string addressBookName = Console.ReadLine();
                AddressBook addressBook = new AddressBook();
                addressBookDict.Add(addressBookName, addressBook);
            }
            foreach (var element in addressBookDict)
            {
                Console.WriteLine("Enter how many contacts you want to add in address book " + element.Key);
                int number = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= number; i++)
                {
                    takeInputAndAddToContacts(element.Value);
                }
                element.Value.print();
            }
            Console.WriteLine("Enter Address Book name where you want to edit contact");
            string editContactInAddressBook = Console.ReadLine();
            Console.WriteLine("Enter FirstName of Contact to be edited");
            string firstNameOfContactToBeEdited = Console.ReadLine();
            Console.WriteLine("Enter LastName of Contact to be edited");
            string lastNameOfContactToBeEdited = Console.ReadLine();
            addressBookDict[editContactInAddressBook].edit(firstNameOfContactToBeEdited, lastNameOfContactToBeEdited);
            addressBookDict[editContactInAddressBook].print();
            Console.WriteLine("Enter Address Book name where you want to delete contact");
            string deleteContactInAddressBook = Console.ReadLine();
            Console.WriteLine("Enter FirstName of Contact to be deleted");
            string firstNameOfContactToBeDeleted = Console.ReadLine();
            Console.WriteLine("Enter LastName of Contact to be deleted");
            string lastNameOfContactToBeDeleted = Console.ReadLine();
            addressBookDict[deleteContactInAddressBook].delete(firstNameOfContactToBeDeleted, lastNameOfContactToBeDeleted);
            addressBookDict[deleteContactInAddressBook].print();
            Console.WriteLine("Enter the city or state where you want to find the persons");
            String findPlace = Console.ReadLine();
            foreach (var element in addressBookDict)
            {
                List<String> listOfPersonsinPlace = element.Value.findPersons(findPlace);
                if (listOfPersonsinPlace.Count == 0)
                {
                    Console.WriteLine("No Person in that city/state for address book " + element.Key);
                }
                else
                {
                    Console.WriteLine("Persons in that city/state for address book " + element.Key + " :-");
                    foreach (var name in listOfPersonsinPlace)
                    {
                        Console.WriteLine(name);
                    }
                }
            }            
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
