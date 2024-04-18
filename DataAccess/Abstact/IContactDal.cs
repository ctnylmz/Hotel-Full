using Entities.Concrete;
using Shareds.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstact
{
    public interface IContactDal : IEntityRepository<Contact>
    {

    }
}
