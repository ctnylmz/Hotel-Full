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
    public interface IStaffService
    {
        IResult Add(Staff staff);
        IResult Update(Staff staff);
        IResult Delete(Staff staff);
        IDataResult<List<Staff>> GetList();
        IDataResult<Staff> GetById(int id);
    }
}
