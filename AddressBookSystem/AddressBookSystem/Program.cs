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
            Console.WriteLine("Press c for city or s for state");
            string place= Console.ReadLine();
            place = place.ToLower();
            Console.WriteLine("Enter name of place");
            String findPlace = Console.ReadLine();            
            Dictionary<string, List<string>> dictionaryCity = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> dictionaryState = new Dictionary<string, List<string>>();
            foreach (var element in addressBookDict)
            {
                List<String> listOfPersonsinPlace=new List<string>();
                if (place.Equals("c"))
                {
                    listOfPersonsinPlace = element.Value.findPersonsInCity(findPlace);
                    foreach (var name in listOfPersonsinPlace)
                    {
                        if (!dictionaryCity.ContainsKey(findPlace))
                        {
                            List<string> list = new List<string>();
                            list.Add(name);
                            dictionaryCity.Add(findPlace, list);
                        }
                        else
                            dictionaryCity[findPlace].Add(name);
                    }
                }
                else
                {
                    listOfPersonsinPlace = element.Value.findPersonsInState(findPlace);
                    foreach (var name in listOfPersonsinPlace)
                    {
                        if (!dictionaryState.ContainsKey(findPlace))
                        {
                            List<string> list = new List<string>();
                            list.Add(name);
                            dictionaryState.Add(findPlace, list);
                        }
                        else
                            dictionaryState[findPlace].Add(name);
                    }
                }                
            }
            if (dictionaryCity.Count != 0)
            {
                Console.WriteLine("Persons in the city :-");
                foreach (var mapElement in dictionaryCity)
                {
                    foreach (var listElement in mapElement.Value)
                    {
                        Console.WriteLine(listElement);
                    }
                }
            }
            else
            {
                Console.WriteLine("Persons in the state :-");
                foreach (var mapElement in dictionaryState)
                {
                    foreach(var listElement in mapElement.Value)
                    {
                        Console.WriteLine(listElement);
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
