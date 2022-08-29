using CommonLayer.CustomExceptions;
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactRepository
{
    public class ContactRepoInMemoryDictionary
    {
        public Dictionary<string, Contact> contacts = new Dictionary<string, Contact>();

        public bool AddContacts(Contact contact)
        {
            bool isAdded = false;
            var isDuplicate = this.GetContactByName(contact.ContactName);
            if (isDuplicate==null)
            {
                contacts.Add(contact.ContactName, contact);
                isAdded = true;
            }
            else
            {
                throw new DuplicateContactException($"contact with contact name {contact.ContactName} already exists");
            }

            return isAdded;

        }

        public IEnumerable<Contact> DisplayContacts()
        {
            return contacts.Values;
            /*Dictionary<long, string> temp = new Dictionary<long, string>();

            foreach (KeyValuePair<long, string> contact in contacts)
            {
                temp.Add(contact.Key, contact.Value);
                
            }
            return (IEnumerable<Contact>)temp;*/
        }

        public Contact GetContactByNum(long contactNumber)
        {
            Contact found = null;
            foreach (var contact in contacts.Values)
            {
                if (contact.ContactNumber == contactNumber)
                {
                    found = contact;
                    break;
                }
            }
            return found;
        }
        public Contact GetContactByName(string name)
        {
            return this.contacts.GetValueOrDefault(name);
        }
    }
}
