using Shareds.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Trailer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoTitle { get; set; }
        public string VideoImage{ get; set; }
        public string VideoLink { get; set; }
    }
}
