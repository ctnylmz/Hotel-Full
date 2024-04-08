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
    public interface IRoomService
    {
        IResult Add(Room room);
        IResult Update(Room room);
        IResult Delete(Room room);
        IDataResult<List<Room>> GetList();
        IDataResult<Room> GetById(int id);
    }
}
