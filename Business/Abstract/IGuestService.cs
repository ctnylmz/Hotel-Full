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
    public interface IGuestService
    {
        IResult Add(Guest guest);
        IResult Update(Guest guest);
        IResult Delete(Guest guest);
        IDataResult<List<Guest>> GetList();
        IDataResult<Guest> GetById(int id);
    }
}
