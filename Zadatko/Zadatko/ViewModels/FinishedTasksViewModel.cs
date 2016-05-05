using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zadatko.Annotations;
using Zadatko.Models;
using Zadatko.Services;

namespace Zadatko.ViewModels
{
    public class FinishedTasksViewModel:INotifyPropertyChanged
    {
        private List<TodoItem> _todoItems;

        public List<TodoItem> TodoItems
        {
            get { return _todoItems;}
            set
            {
                if (_todoItems != value)
                {
                    _todoItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public FinishedTasksViewModel()
        {
            TodoItems = App.DataService.GetDoneTodoItems();

            MessagingCenter.Subscribe<TodoItem, TodoItem>(this, "NotificationFinished", (service, arg) =>
            {
                TodoItems = App.DataService.GetDoneTodoItems();
            });
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
