using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wos_Wpf_Project.data
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CurrentPositionId { get; set; }
        public Position CurrentPosition { get; set; }
    }
}
