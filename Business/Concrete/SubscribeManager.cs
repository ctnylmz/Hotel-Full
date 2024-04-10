using Business.Abstract;
using DataAccess.Abstact;
using Entities.Concrete;
using Shareds.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public IResult Add(Subscribe subscribe)
        {
            _subscribeDal.Add(subscribe);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(Subscribe subscribe)
        {
            _subscribeDal.Delete(subscribe);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IDataResult<Subscribe> GetById(int id)
        {
            return new SuccessDataResult<Subscribe>(_subscribeDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Subscribe>> GetList()
        {
            return new SuccessDataResult<List<Subscribe>>(_subscribeDal.GetList().ToList(), "Başarıyla Veriler Geldi");
        }

        public IResult Update(Subscribe subscribe)
        {
            _subscribeDal.Update(subscribe);
            return new SuccessResult("Başarıyla Eklendi");
        }
    }
}
