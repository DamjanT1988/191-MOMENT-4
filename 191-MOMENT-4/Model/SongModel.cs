using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _191_MOMENT_4.Model
{
    public class SongModel
    {
        public int ID { get; set; }
        public string? Artist { get; set; }

        public string? SongTitle { get; set; }
        
        public int? LengthSec { get; set; }

        public string? Category { get; set; }

        public int? YearPub { get; set; }
    }
}