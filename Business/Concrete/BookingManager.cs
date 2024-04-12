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
    public class BookingManager : IBookingService
    {
        IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public IResult Add(Booking booking)
        {
            _bookingDal.Add(booking);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(Booking booking)
        {
            _bookingDal.Delete(booking);
            return new SuccessResult("Başarıyla Silindi");
        }

        public IDataResult<Booking> GetById(int id)
        {
            return new SuccessDataResult<Booking>(_bookingDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Booking>> GetList()
        {
            return new SuccessDataResult<List<Booking>>(_bookingDal.GetList().ToList(),"Başarıyla Veriler Geldi");
        }

        public IResult Update(Booking booking)
        {
            _bookingDal.Update(booking);
            return new SuccessResult("Başarıyla Güncellendi");
        }
    }
}
