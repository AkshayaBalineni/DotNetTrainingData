using BussinessLayer;
using CommonLayer.CustomExceptions;
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsList
{
    public class ContactMenu
    {
        ContactManager contactManager = new ContactManager();
       
       public void Main()
        {
            int ch = 0;
            bool looping = true;
            while(looping)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("Add Contact");
                Console.WriteLine("Diaplay Contact");
                Console.WriteLine("Get contact by Number");
                Console.WriteLine("Get Contact by Name");
                Console.WriteLine("Enter your Choice");
                ch = Convert.ToInt32(Console.ReadLine()); ;
                switch (ch)
                {
                    case 1: AddContact(contactManager);
                        break;
                    case 2: DisplayContacts(contactManager);
                        break;
                    case 3: GetContactByNumber(contactManager);
                        break;
                    case 4:
                        GetContactByName(contactManager);
                        break;
                    default: Console.WriteLine("Invalid Entry");
                        break;
                }
                Console.WriteLine("Do you want to continue in product menu? y/n");
                String s = Console.ReadLine();
                if (String.Equals(s, "N", StringComparison.OrdinalIgnoreCase))
                    looping = false;

            }

        }

        private void GetContactByNumber(ContactManager contactManager)
        {
            Console.WriteLine("Enter the Contact Number to be searched :");
            long num = Convert.ToInt64(Console.ReadLine());
            Contact SearchByNum = contactManager.GetContactByNumber(num);
            Console.WriteLine("ContactName \t\t ConatctNumber");
            Console.WriteLine("***********************************************");
            Console.WriteLine($"{SearchByNum.ContactName}\t\t{SearchByNum.ContactNumber}");
        }

        private void GetContactByName(ContactManager contactManager)
        {
            Console.WriteLine("Enter the Contact Name to be searched :");
            string name = Console.ReadLine();
            Contact SearchByName = contactManager.GetContactByName(name);
            Console.WriteLine("ContactName \t\t ConatctNumber");
            Console.WriteLine("***********************************************");
            Console.WriteLine($"{SearchByName.ContactName}\t\t{SearchByName.ContactNumber}");

        }

        private void DisplayContacts(ContactManager contactManager)
        {
            var contacts = contactManager.GetContacts().ToList();
            Console.WriteLine("Contacts");
            Console.WriteLine("*********************");
            Console.WriteLine("ContactName \t\t ConatctNumber");
            Console.WriteLine("***********************************************");
            foreach( var contact in contacts)
            {
                Console.WriteLine($"{contact.ContactName}\t\t{contact.ContactNumber}");
            }


        }

        private void AddContact(ContactManager contactManager)
        {
            Contact contact = new Contact();
            Console.WriteLine("Enter Contact Name:");
            contact.ContactName = Console.ReadLine();
            Console.WriteLine("Enter Contact Number");
            contact.ContactNumber = Convert.ToInt64(Console.ReadLine());
            //contactManager.AddContact(contact);
            try
            {
                if (contactManager.AddContact(contact))
                {
                    Console.WriteLine("Contact Successfully Saved");
                }
                else
                {
                    Console.WriteLine("Contact not Saved try again!");
                }
            }
            catch (DuplicateContactException exe)
            {
                Console.WriteLine(exe.Message);
                Console.WriteLine(exe.InnerException.Message);
            }
            
        }
    }
}
