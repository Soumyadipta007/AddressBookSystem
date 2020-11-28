using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Globalization;

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
        public static void ImplementCSVDataHandling()
        {
            string filePath = @"C:\Users\User\Desktop\New folder\AddressBookSystem\AddressBookSystem\AddressBookSystem\Utility\Contacts.xlsx";
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();
                Console.WriteLine("Data Reading done successfully from Contact.csv file");
                foreach (Contact contact in records)
                {
                    Console.Write("\t" + contact.firstName);
                    Console.Write("\t" + contact.lastName);
                    Console.Write("\t" + contact.address);
                    Console.Write("\t" + contact.city);
                    Console.Write("\t" + contact.state);
                    Console.Write("\t" + contact.zip);
                    Console.Write("\t" + contact.phoneNumber);
                    Console.Write("\t" + contact.email);
                    Console.Write("\n");
                }
            }
        }
        internal static void WriteCSVFile(List<Contact> data)
        {
            string filePath = @"C:\Users\User\Desktop\New folder\AddressBookSystem\AddressBookSystem\AddressBookSystem\Utility\Contacts.xlsx";
            using (var writer = new StreamWriter(filePath))
            using (var csvWrite = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                Console.WriteLine("Data Writing done successfully from Contact.csv file");
                csvWrite.WriteRecords(data);
            }
        }
    }
}
