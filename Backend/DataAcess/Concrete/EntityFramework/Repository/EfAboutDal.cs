using DataAccess.Abstact;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Shareds.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfAboutDal : EfEntityRepositoryBase<About,HotelFullContext>,IAboutDal
    {
    }
}
