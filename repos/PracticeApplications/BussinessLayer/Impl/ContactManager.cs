using CommonLayer.CustomExceptions;
using CommonLayer.Models;
using ContactRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class ContactManager
    {
         ContactRepoInMemoryDictionary contactRepository = new ContactRepoInMemoryDictionary();
        public IEnumerable<Contact> GetContacts()
        {
            return contactRepository.DisplayContacts();
        }

        public bool AddContact(Contact contact)
        {
            try
            {
                return contactRepository.AddContacts(contact);
            }
            catch(DuplicateContactException exc)
            {
                throw new DuplicateContactException("Duplicate Product");
            }
           
        }

        public Contact GetContactByName(string name)
        {
            return contactRepository.GetContactByName(name);
        }

        public Contact GetContactByNumber(long num)
        {
            return contactRepository.GetContactByNum(num);
        }
    }
}
