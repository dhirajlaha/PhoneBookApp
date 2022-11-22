using PhoneBookApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Services
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
