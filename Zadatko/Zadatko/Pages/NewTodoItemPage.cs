using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zadatko.Models;

namespace Zadatko.Pages
{
    public class NewTodoItemPage:ContentPage
    {
        private Entry _name;
        private Editor _description;
        private DatePicker _datePicker;
        private TimePicker _timePicker;

        public NewTodoItemPage()
        {
            Title = "New Todo Item";

            _name = new Entry();
            _description = new Editor() {HeightRequest = 150};
            _datePicker = new DatePicker()
            {
                Date = DateTime.Now
            };
            _timePicker = new TimePicker()
            {
                Time = new TimeSpan(0)
            };

            var addButton = new Button()
            {
                Text = "Add"
            };
            addButton.Clicked += AddButton_Clicked;

            Content = new StackLayout()
            {
                Children = {_name, _description, _datePicker, _timePicker, addButton}
            };
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            var todoItem = new TodoItem()
            {
                Name = _name.Text,
                Description = _description.Text,
                ScheduledAt = _datePicker.Date.Add(_timePicker.Time)
            };
            App.DataService.AddNewTodoItem(todoItem);

            Navigation.PopAsync();
        }
    }
}
