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
    public interface ITrailerService
    {
        IResult Add(Trailer trailer);
        IResult Update(Trailer trailer);
        IResult Delete(Trailer trailer);
        IDataResult<List<Trailer>> GetList();
        IDataResult<Trailer> GetById(int id);
    }
}
