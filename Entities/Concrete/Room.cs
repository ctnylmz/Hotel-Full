using Shareds.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Room : IEntity
    {
        public int Id { get; set; }
        public string CoverImage { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public int BedCount { get; set; }
        public int Bath { get; set; }
        public bool Wifi { get; set; }
        public string Description { get; set; }
        public string RoomNumber { get; set; }

    }
}
