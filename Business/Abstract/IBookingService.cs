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
    public interface IBookingService
    {
        IResult Add(Booking booking);
        IResult Update(Booking booking);
        IResult Delete(Booking booking);
        IDataResult<List<Booking>> GetList();
        IDataResult<Booking> GetById(int id);
    }
}
