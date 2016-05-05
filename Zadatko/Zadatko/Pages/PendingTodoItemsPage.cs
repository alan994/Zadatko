using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zadatko.Models;
using Zadatko.Services;

namespace Zadatko.Pages
{
    public class PendingTodoItemsPage:ContentPage
    {
        public List<TodoItem> TodoItems { get; set; }

        private ListView _listView;

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    TodoItems = App.DataService.GetPendingTodoItems();
        //    _listView.ItemsSource = TodoItems;
        //}

        public PendingTodoItemsPage()
        {
            Title = "Pending";

            MessagingCenter.Subscribe<DataService>(this, "NewTodoItem", service =>
            {
                TodoItems = App.DataService.GetPendingTodoItems();
                _listView.ItemsSource = TodoItems;
            });

            MessagingCenter.Subscribe<TodoItem, TodoItem>(this, "NotificationFinished", (service, arg) =>
            {
                TodoItems = App.DataService.GetPendingTodoItems();
                _listView.ItemsSource = TodoItems;
            });

            TodoItems = App.DataService.GetPendingTodoItems();

            var grid = new Grid()
            {
                RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition() {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition() {Height = new GridLength(60, GridUnitType.Absolute)}
                }
            };

            _listView = new ListView()
            {
                ItemsSource = TodoItems,
                ItemTemplate = new DataTemplate(typeof (TextCell)),
                BindingContext = TodoItems,
                IsPullToRefreshEnabled = true
            };
            _listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            _listView.ItemTemplate.SetBinding(TextCell.DetailProperty,"ScheduledAt");
            _listView.ItemTapped += ListView_ItemTapped;
            _listView.Refreshing += ListView_Refreshing;


            grid.Children.Add(_listView, 0, 0);

            var addNewButton = new Button()
            {
                Text = "Add new Todo item"
            };
            addNewButton.Clicked += AddNewButton_Clicked;

            grid.Children.Add(addNewButton, 0, 1);

            Content = grid;
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            TodoItems = App.DataService.GetPendingTodoItems();
            ((ListView) sender).ItemsSource = TodoItems;
            ((ListView) sender).IsRefreshing = false;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new TodoItemDetailsPage((TodoItem) e.Item));
            ((ListView)sender).SelectedItem = null;
        }

        private void AddNewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewTodoItemPage());
        }
    }
}
