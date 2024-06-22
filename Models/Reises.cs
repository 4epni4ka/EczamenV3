using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EczamenV3.Models
{
    public class Reises
    {
        public int Id { get; set; }
        public DateTime TimeVilet { get; set; }
        public DateTime TimePrilet { get; set; }
        public DateTime TimeOnFly { get; set; }
        public DateTime DateVilet { get; set; }
        public DateTime DatePrilet { get; set; }
        public string PunktVilet { get; set; }
        public string PunktPrilet { get; set; }
        public int IdPlain { get; set; }
    }
}
