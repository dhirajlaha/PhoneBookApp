using PhoneBookApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhoneBookApp.Services
{
    public class DatabaseHelper 
    {
        static SQLiteConnection SQLiteConnection;

        public DatabaseHelper()
        {
            SQLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
            SQLiteConnection.CreateTable<Person>();
        }

        // Get All Contact data      
        public List<Person> GetAllContactsData()
        {
            return (from data in SQLiteConnection.Table<Person>()
                    select data).ToList();
        }

        //Get Specific Contact data  
        public Person GetContactData(int id)
        {
            return SQLiteConnection.Table<Person>().FirstOrDefault(t => t.Id == id);
        }


        // Delete Specific Contact  
        public void DeleteContact(int id)
        {
            SQLiteConnection.Delete<Person>(id);
        }

        // Insert new Contact to DB   
        public void InsertContact(Person contact)
        {
            SQLiteConnection.Insert(contact);
        }

        // Update Contact Data  
        public void UpdateContact(Person contact)
        {
            SQLiteConnection.Update(contact);
        }
    }
}
