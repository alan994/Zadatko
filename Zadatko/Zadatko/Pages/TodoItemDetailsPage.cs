using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zadatko.Models;

namespace Zadatko.Pages
{
    public class TodoItemDetailsPage:ContentPage
    {
        private TodoItem _todoItem;

        public TodoItemDetailsPage(TodoItem todoItem)
        {
            _todoItem = todoItem;
            Title = "Todo Item Details";
            var nameLabel = new Label()
            {
                Text = _todoItem.Name
            };
            var descriptionlabel = new Label()
            {
                Text = _todoItem.Description
            };
            var scheduledAtlabel = new Label()
            {
                Text = _todoItem.ScheduledAt.ToString()
            };
            var finishTodoItemButton = new Button()
            {
                Text = "Finish Todo Item",
                IsEnabled = !_todoItem.Done
            };
            finishTodoItemButton.Clicked += FinishTodoItemButton_Clicked;
            Content = new StackLayout()
            {
                Children = {nameLabel, descriptionlabel, scheduledAtlabel, finishTodoItemButton}
            };
        }
        private void FinishTodoItemButton_Clicked(object sender, EventArgs e)
        {
            _todoItem.Done = true;

            Navigation.PopAsync();
        }
    }
}
