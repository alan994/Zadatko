using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace Zadatko.Models
{
    public class TodoItem
    {
        [PrimaryKey]
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledAt { get; set; }
        private bool _done = false;
        public bool Done
        {
            get { return _done; }
            set
            {
                if (_done != value)
                {
                    _done = value;
                    FinishedAt = DateTime.Now;
                    MessagingCenter.Send(this, "NotificationFinished", this);
                }
            }
        }

        public DateTime CreatedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }

        public TodoItem()
        {
            Id = Guid.NewGuid();
            CreatedAt=DateTime.Now;
        }
    }
}
