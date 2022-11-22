using PhoneBookApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Helpers
{
    public interface IPhoneBookRepository
    {
        List<Person> GetAllContacts();
        Person GetPerson(int id);

        void DeletePerson(int id);
        void UpdateContact(Person person);

        void InsertContact(Person person);
    }
}
