using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Zadatko.Interfaces
{
    public interface ISqLiteService
    {
        SQLiteConnection GetConnection();
    }
}
