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
    public interface ISubscribeService
    {
        IResult Add(Subscribe subscribe);
        IResult Update(Subscribe subscribe);
        IResult Delete(Subscribe subscribe);
        IDataResult<List<Subscribe>> GetList();
        IDataResult<Subscribe> GetById(int id);
    }
}
