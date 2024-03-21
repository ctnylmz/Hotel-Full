using Entities.Concrete;
using Shareds.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(About about);
        IResult Update(About about);
        IResult Delete(About about);
        IDataResult<List<About>> GetList();
        IDataResult<About> GetById(int id);
    }
}
