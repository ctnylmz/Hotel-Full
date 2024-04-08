using Business.Abstract;
using DataAccess.Abstact;
using Entities.Concrete;
using Shareds.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public IResult Add(About about)
        {
            _aboutDal.Add(about);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(About about)
        {
            _aboutDal.Delete(about);
            return new SuccessResult("Başarıyla Silindi");
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(_aboutDal.Get(c => c.Id == id));
        }

        public IDataResult<List<About>> GetList()
        {
            return new SuccessDataResult<List<About>>(_aboutDal.GetList().ToList(),"Başarıyla Veriler Geldi");
        }

        public IResult Update(About about)
        {
            _aboutDal.Update(about);
            return new SuccessResult("Başarıyla Güncellendi");
        }
    }
}
