using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SongHistory
    {
        public int HistoryId { get; set; }
        public int SongId { get; set; }
        public bool StatusPromoted { get; set; }
    }
}
