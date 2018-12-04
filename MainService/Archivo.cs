using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainService
{
    public class Archivo
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastAccessDate { get; set; }

        public int DaysSinceCreation()
        {
            return DateTime.Now.Subtract(CreationDate).Days;
        }
    }
}
