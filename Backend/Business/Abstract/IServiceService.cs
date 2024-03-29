﻿using Entities.Concrete;
using Shareds.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceService
    {
        IResult Add(Service service);
        IResult Update(Service service);
        IResult Delete(Service service);
        IDataResult<List<Service>> GetList();
        IDataResult<Service> GetById(int id);

    }
}
