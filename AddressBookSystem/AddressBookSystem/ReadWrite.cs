using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AddressBookSystem
{
    public class ReadWrite
    {
        public static void ReadFromStreamReader()
        {
            string path = @"C:\git uploads\AddressBook\AddressBookSystem\AddressBookSystem\AddressBookSystem\Contacts.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    String fileData = "";
                    while ((fileData = sr.ReadLine()) != null)
                        Console.WriteLine((fileData));
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No file");
            }
        }
        internal static void WriteUsingStreamWriter(List<Contact> data)
        {
            string path = @"C:\git uploads\AddressBook\AddressBookSystem\AddressBookSystem\AddressBookSystem\Contacts.txt";
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    foreach (Contact contact in data)
                    {
                        streamWriter.WriteLine(contact.firstName);
                    }
                    streamWriter.Close();
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No file");
            }
        }
    }
}
