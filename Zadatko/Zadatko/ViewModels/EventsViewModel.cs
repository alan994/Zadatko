using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zadatko.Annotations;
using Zadatko.Models;
using Zadatko.Services;

namespace Zadatko.ViewModels
{
    public class EventsViewModel:INotifyPropertyChanged
    {
        private List<EventItem> _eventItems;

        public List<EventItem> EventItems
        {
            get { return _eventItems; }
            set
            {
                if (_eventItems != value)
                {
                    _eventItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public EventsViewModel()
        {
            EventItems = App.DataService.EventItems;

            MessagingCenter.Subscribe<DataService>(this, "NewEvent", service =>
            {
                EventItems = App.DataService.EventItems;
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
