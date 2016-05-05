using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Zadatko.Pages
{
    public class ZadatkoTabbedPage:TabbedPage
    {
        public ZadatkoTabbedPage()
        {
            this.Children.Insert(0, new PendingTodoItemsPage());
            this.Children.Insert(1, new FinishedTasksPage());
            this.Children.Insert(2, new EventsPage());
        }
    }
}
