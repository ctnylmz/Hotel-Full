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
    public interface ISendMessageService
    {
        IResult Add(SendMessage sendMessage);
        IResult Update(SendMessage sendMessage);
        IResult Delete(SendMessage sendMessage);
        IDataResult<List<SendMessage>> GetList();
        IDataResult<SendMessage> GetById(int id);
    }
}
