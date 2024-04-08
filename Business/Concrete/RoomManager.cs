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
    public class RoomManager : IRoomService
    {
        IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public IResult Add(Room room)
        {
            _roomDal.Add(room);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(Room room)
        {
            _roomDal.Delete(room);
            return new SuccessResult("Başarıyla Silindi");
        }

        public IDataResult<Room> GetById(int id)
        {
            return new SuccessDataResult<Room>(_roomDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Room>> GetList()
        {
            return new SuccessDataResult<List<Room>>(_roomDal.GetList().ToList(),"Başarıyla Veriler Geldi");
        }

        public IResult Update(Room room)
        {
            _roomDal.Update(room);
            return new SuccessResult("Başarıyla Güncellendi");
        }
    }
}
