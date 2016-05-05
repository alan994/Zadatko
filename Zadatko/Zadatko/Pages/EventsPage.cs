using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zadatko.Models;
using Zadatko.ViewModels;

namespace Zadatko.Pages
{
    public class EventsPage:ContentPage
    {
        public EventsPage()
        {
            Title = "Events";

            BindingContext=new EventsViewModel();

            var dataTemplate = new DataTemplate(typeof (TextCell));
            dataTemplate.SetBinding(TextCell.TextProperty, nameof(EventItem.EventType));
            dataTemplate.SetBinding(TextCell.DetailProperty, nameof(EventItem.EventTime));

            var listView=new ListView() {ItemTemplate = dataTemplate, VerticalOptions = LayoutOptions.FillAndExpand};
            listView.SetBinding(ListView.ItemsSourceProperty, nameof(EventsViewModel.EventItems));

            Content = listView;
        }
    }
}
