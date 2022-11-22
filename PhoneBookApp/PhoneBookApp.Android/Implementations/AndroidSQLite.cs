using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PhoneBookApp.Droid.Implementations;
using PhoneBookApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly:Xamarin.Forms.Dependency(typeof(AndroidSQLite))]
namespace PhoneBookApp.Droid.Implementations
{
    public class AndroidSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var filename = "Contacts.db";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, filename);

            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}