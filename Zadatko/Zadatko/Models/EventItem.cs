using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatko.Models
{
    public class EventItem
    {
        public Guid TodoItemId { get; set; }
        public DateTime EventTime { get; set; }
        public EventType EventType { get; set; }
    }

    public enum EventType
    {
        Created,
        Finished
    }
}
