using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinePusher.Models
{
    class Round
    {
        public int RoundId { get; set; }
        public int WineId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Status { get; set; }
        public Nullable<decimal> Cost { get; set; }
    }
}
