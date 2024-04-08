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
    public class TrailerManager : ITrailerService
    {
        ITrailerDal _trailerDal;

        public TrailerManager(ITrailerDal trailerDal)
        {
            _trailerDal = trailerDal;
        }

        public IResult Add(Trailer trailer)
        {
            _trailerDal.Add(trailer);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(Trailer trailer)
        {
            _trailerDal.Delete(trailer);
            return new SuccessResult("Başarıyla Silindi");
        }

        public IDataResult<Trailer> GetById(int id)
        {
            return new SuccessDataResult<Trailer>(_trailerDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Trailer>> GetList()
        {
            return new SuccessDataResult<List<Trailer>>(_trailerDal.GetList().ToList(),"Başarıyla Veriler Geldi");
        }

        public IResult Update(Trailer trailer)
        {
            _trailerDal.Update(trailer);
            return new SuccessResult("Başarıyla Güncellendi");
        }
    }
}
