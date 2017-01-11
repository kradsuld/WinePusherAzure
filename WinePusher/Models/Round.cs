using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinePusher.Models
{
    class Round
    {
        public int WineId { get; set; }
        public string WineType { get; set; }
        public string WineName { get; set; }
        public string Store { get; set; }
        public string Url { get; set; }
        public decimal WinePrice { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; }
    }
}
