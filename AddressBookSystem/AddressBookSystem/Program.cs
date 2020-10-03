using System;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            addressBook.addContacts("Soumya", "Banerjee", "Ranibagan", "Berhampore", "West Bengal", 742101, 9898989898, "abcd@gmail.com");
            addressBook.print();
        }
    }
}
