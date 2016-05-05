using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Xamarin.Forms;
using Zadatko.Droid.Services;
using Zadatko.Interfaces;
using Environment = System.Environment;

[assembly: Xamarin.Forms.Dependency(typeof(SqLiteService))]
namespace Zadatko.Droid.Services
{
    public class SqLiteService:ISqLiteService
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Zadatko.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);

            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}