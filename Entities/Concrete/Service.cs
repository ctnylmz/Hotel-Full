using Shareds.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
