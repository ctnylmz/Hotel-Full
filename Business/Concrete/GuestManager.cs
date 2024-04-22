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
    public class GuestManager : IGuestService
    {
        IGuestDal _guestDal;

        public GuestManager(IGuestDal guestDal)
        {
            _guestDal = guestDal;
        }

        public IResult Add(Guest guest)
        {
            _guestDal.Add(guest);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(Guest guest)
        {
            _guestDal.Delete(guest);
            return new SuccessResult("Başarıyla Silindi");
        }

        public IDataResult<Guest> GetById(int id)
        {
            return new SuccessDataResult<Guest>(_guestDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Guest>> GetList()
        {
            return new SuccessDataResult<List<Guest>>(_guestDal.GetList().ToList(),"Başarıyla Veriler Geldi");
        }

        public IResult Update(Guest guest)
        {
            _guestDal.Update(guest);
            return new SuccessResult("Başarıyla Güncellendi");
        }
    }
}
