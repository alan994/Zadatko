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
    public class FinishedTasksPage:ContentPage
    {
        public FinishedTasksPage()
        {
            Title = "Finished";

            BindingContext = new FinishedTasksViewModel();

            var dataTemplate = new DataTemplate(typeof (TextCell));
            dataTemplate.SetBinding(TextCell.TextProperty, nameof(TodoItem.Name));
            dataTemplate.SetBinding(TextCell.DetailProperty, nameof(TodoItem.FinishedAt));

            var listView=new ListView() {ItemTemplate = dataTemplate, VerticalOptions = LayoutOptions.FillAndExpand};
            listView.SetBinding(ListView.ItemsSourceProperty, nameof(FinishedTasksViewModel.TodoItems));

            Content = listView;
        }
    }
}
