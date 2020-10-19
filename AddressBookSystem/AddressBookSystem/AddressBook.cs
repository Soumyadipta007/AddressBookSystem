using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class AddressBook
    {
        private List<Contact> contactList;
        public AddressBook()
        {
            this.contactList = new List<Contact>();
        }
        public void addContacts(string fistName, string lastName, string address, string city, string state, int zip, long phoneNumber, string email)
        {
            bool duplicate = equals(fistName, lastName);
            if (!duplicate)
            {
                Contact contact = new Contact();
                contact.firstName = fistName;
                contact.lastName = lastName;
                contact.address = address;
                contact.city = city;
                contact.state = state;
                contact.zip = zip;
                contact.phoneNumber = phoneNumber;
                contact.email = email;
                this.contactList.Add(contact);
            }
            else
                Console.WriteLine("Cannot add duplicate Contact");
        }
        private bool equals(string fName, string lName)
        {
            if (this.contactList.Any(e => e.firstName == fName && e.lastName == lName))
                return true;
            else
                return false;
        }
        public void print()
        {
            Console.WriteLine("Printing contacts in AddressBook ->");
            if (this.contactList.Count == 0)
            {
                Console.WriteLine("No contacts");
                return;
            }                        
            foreach (Contact contact in this.contactList)
            {
                Console.WriteLine("FirstName: " + contact.firstName);
                Console.WriteLine("LastName: " + contact.lastName);
                Console.WriteLine("Address: " + contact.address);
                Console.WriteLine("City: " + contact.city);
                Console.WriteLine("State: " + contact.state);
                Console.WriteLine("Zip: " + contact.zip);
                Console.WriteLine("PhoneNumber: " + contact.phoneNumber);
                Console.WriteLine("Email id: " + contact.email);
            }
        }
        public void edit(string firstName, string lastName)
        {
            Contact contactToBeEdited = null;
            foreach (Contact contact in this.contactList)
            {
                if (contact.firstName == firstName && contact.lastName == lastName)
                    contactToBeEdited = contact;
            }
            if (contactToBeEdited == null)
            {
                Console.WriteLine("No such contact exists");
                return;
            }            
            this.editThisContact(contactToBeEdited);
        }
        public void editThisContact(Contact contactToBeEdited)
        {
            while (true)
            {
                Console.WriteLine("Enter 1 to edit FirstName");
                Console.WriteLine("Enter 2 to edit LastName");
                Console.WriteLine("Enter 3 to edit Address");
                Console.WriteLine("Enter 4 to edit City");
                Console.WriteLine("Enter 5 to edit State");
                Console.WriteLine("Enter 6 to edit Zip");
                Console.WriteLine("Enter 7 to edit PhoneNumber");
                Console.WriteLine("Enter 8 to edit Email Id");
                Console.WriteLine("Enter 9 if Editing is done");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter new FirstName");
                        string fName = Console.ReadLine();
                        contactToBeEdited.firstName = fName;
                        break;
                    case 2:
                        Console.WriteLine("Enter new LastName");
                        string lName = Console.ReadLine();
                        contactToBeEdited.lastName = lName;
                        break;
                    case 3:
                        Console.WriteLine("Enter new Address");
                        string address = Console.ReadLine();
                        contactToBeEdited.address = address;
                        break;
                    case 4:
                        Console.WriteLine("Enter new City");
                        string city = Console.ReadLine();
                        contactToBeEdited.city = city;
                        break;
                    case 5:
                        Console.WriteLine("Enter new State");
                        string state = Console.ReadLine();
                        contactToBeEdited.state = state;
                        break;
                    case 6:
                        Console.WriteLine("Enter new Zip");
                        int zip = Convert.ToInt32(Console.ReadLine());
                        contactToBeEdited.zip = zip;
                        break;
                    case 7:
                        Console.WriteLine("Enter new PhoneNumber");
                        long phoneNumber = long.Parse(Console.ReadLine());
                        contactToBeEdited.phoneNumber = phoneNumber;
                        break;
                    case 8:
                        Console.WriteLine("Enter new Email Id");
                        string email = Console.ReadLine();
                        contactToBeEdited.email = email;
                        break;
                    case 9:
                        Console.WriteLine("Editing done.New Contact :-");
                        this.printSpecificContact(contactToBeEdited);
                        return;
                }
            }            
        }
        public void printSpecificContact(Contact contact)
        {
            Console.WriteLine("FirstName: " + contact.firstName);
            Console.WriteLine("LastName: " + contact.lastName);
            Console.WriteLine("Address: " + contact.address);
            Console.WriteLine("City: " + contact.city);
            Console.WriteLine("State: " + contact.state);
            Console.WriteLine("Zip: " + contact.zip);
            Console.WriteLine("PhoneNumber: " + contact.phoneNumber);
            Console.WriteLine("Email id: " + contact.email);
        }
        public void delete(string firstName, string lastName)
        {
            Contact contactToBeDeleted = null;
            foreach (Contact contact in this.contactList)
            {
                if (contact.firstName == firstName && contact.lastName == lastName)
                {
                    contactToBeDeleted = contact;
                    this.contactList.Remove(contactToBeDeleted);
                    break;
                }
            }
            if (contactToBeDeleted == null)
                Console.WriteLine("No such contact exists");
            else
                Console.WriteLine("Deletion Done.");
        }
        public List<String> findPersonsInCity(string place)
        {
            List<String> personsFounded = new List<string>();
            foreach (Contact contact in contactList.FindAll(e => (e.city.Equals(place))).ToList())
            {
                string name = contact.firstName + " " + contact.lastName;
                personsFounded.Add(name);
            }
            if (personsFounded.Count==0)
            {
                foreach (Contact contact in contactList.FindAll(e => (e.state.Equals(place))).ToList())
                {
                    string name = contact.firstName + " " + contact.lastName;
                    personsFounded.Add(name);
                }
            }
            return personsFounded;
        }
        public List<String> findPersonsInState(string place)
        {
            List<String> personsFounded = new List<string>();            
            foreach (Contact contact in contactList.FindAll(e => (e.state.Equals(place))).ToList())
            {
                string name = contact.firstName + " " + contact.lastName;
                personsFounded.Add(name);
            }        
            return personsFounded;
        }
    }
}
