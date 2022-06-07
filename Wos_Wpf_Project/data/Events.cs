using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wos_Wpf_Project.data
{
    public class Events
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string EventDate { get; set; }
        public string HallName { get; set; }
        public Hall Hall { get; set; }
    }
}
