using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _191_MOMENT_4.Model
{
    public class AlbumModel
    {
        public int ID { get; set; }
        public string? Artists { get; set; }

        public int? SongAmount { get; set; }

        public int? TotLengthSec { get; set; }

        public string? Cathegory { get; set; }

        public int? YearPub { get; set; }
    }
}