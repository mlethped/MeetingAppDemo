using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingAppDemo.Models
{
    public class MeetingRoom
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string LOcation { get; set; }

        public int Size { get; set; }
    }
}
