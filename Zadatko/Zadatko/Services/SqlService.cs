using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Zadatko.Interfaces;
using Zadatko.Models;

namespace Zadatko.Services
{
    public class SqlService
    {
        private SQLiteConnection database;

        public SqlService()
        {
            database = DependencyService.Get<ISqLiteService>().GetConnection();

            database.CreateTable<TodoItem>();
            database.CreateTable<EventItem>();
        }

        public void AddTodoItem(TodoItem todoItem)
        {
            database.InsertOrReplace(todoItem);
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            database.Update(todoItem);
        }

        public List<TodoItem> GetTodoItems()
        {
            return database.Table<TodoItem>().ToList();
        }

        public void AddEventItem(EventItem eventItem)
        {
            database.InsertOrReplace(eventItem);
        }

        public List<EventItem> GetEventItems()
        {
            return database.Table<EventItem>().ToList();
        } 
    }
}
