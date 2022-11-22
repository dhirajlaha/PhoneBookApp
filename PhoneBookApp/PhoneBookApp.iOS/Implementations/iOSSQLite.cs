using Foundation;
using PhoneBookApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

namespace PhoneBookApp.iOS.Implementations
{
    public class iOSSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var filename = "Contacts.db";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");

            var path = Path.Combine(libraryPath, filename);

            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}