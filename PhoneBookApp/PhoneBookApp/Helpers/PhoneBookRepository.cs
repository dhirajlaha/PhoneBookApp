using PhoneBookApp.Model;
using PhoneBookApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Helpers
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private DatabaseHelper _databaseHelper;
        public PhoneBookRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }
        public void DeletePerson(int id)
        {
            _databaseHelper.DeleteContact(id);
        }

        public List<Person> GetAllContacts()
        {
            return _databaseHelper.GetAllContactsData();
        }

        public Person GetPerson(int id)
        {
            return _databaseHelper.GetContactData(id);
        }

        public void InsertContact(Person person)
        {
             _databaseHelper.InsertContact(person);
        }

        public void UpdateContact(Person person)
        {
            _databaseHelper.UpdateContact(person);
        }
    }
}
