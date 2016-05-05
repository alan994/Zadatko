using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zadatko.Models;

namespace Zadatko.Services
{
    public class DataService
    {
        private SqlService _sqlService;

        private List<TodoItem> _todoItems;

        private List<EventItem> _eventItems;

        public List<EventItem> EventItems
        {
            get { return _eventItems;}
            set
            {
                if (_eventItems != value)
                {
                    _eventItems = value;
                }
            }
        }

        public DataService()
        {
            _eventItems = new List<EventItem>();
            _todoItems = new List<TodoItem>();
            _sqlService = new SqlService();

            //Initial load from database
            _eventItems.AddRange(_sqlService.GetEventItems());
            _todoItems.AddRange(_sqlService.GetTodoItems());

            MessagingCenter.Subscribe<TodoItem, TodoItem>(this, "NotificationFinished", (sender, arg) =>
            {
                _sqlService.UpdateTodoItem(arg);

                var eventItem = new EventItem()
                {
                    TodoItemId = arg.Id,
                    EventType = EventType.Finished,
                    EventTime = arg.FinishedAt
                };
                _eventItems.Add(eventItem);
                _sqlService.AddEventItem(eventItem);
                MessagingCenter.Send(this, "NewEvent");
            });
        }


        public void AddNewTodoItem(TodoItem todoItem)
        {
            _todoItems.Add(todoItem);
            _sqlService.AddTodoItem(todoItem);
            MessagingCenter.Send(this, "NewTodoItem");

            var eventItem = new EventItem()
            {
                TodoItemId = todoItem.Id,
                EventType = EventType.Created,
                EventTime = todoItem.CreatedAt
            };
            _eventItems.Add(eventItem);
            _sqlService.AddEventItem(eventItem);
            MessagingCenter.Send(this, "NewEvent");
        }

        public List<TodoItem> GetPendingTodoItems()
        {
            return _todoItems.Where(x => x.Done.Equals(false)).ToList();
        }

        public List<TodoItem> GetDoneTodoItems()
        {
            return _todoItems.Where(x => x.Done.Equals(true)).ToList();
        }

        //public List<EventItem> GetEventItems()
        //{
        //    var list = new List<EventItem>();
        //    list.AddRange(
        //        _todoItems.Select(
        //            x => new EventItem()
        //            {
        //                EventTime = x.CreatedAt,
        //                EventType = EventType.Created,
        //                TodoItemId = x.Id
        //            }));

        //    list.AddRange(
        //        _todoItems.Where(x => x.Done.Equals(true))
        //            .Select(
        //                x =>
        //                    new EventItem()
        //                    {
        //                        EventTime = x.FinishedAt,
        //                        EventType = EventType.Finished,
        //                        TodoItemId = x.Id
        //                    }));

        //    return list;
        //}

        public TodoItem GetTodoItem(Guid guid)
        {
            return _todoItems.FirstOrDefault(x => x.Id.Equals(guid));
        }

    }
}
