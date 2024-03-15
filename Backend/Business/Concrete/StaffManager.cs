using Business.Abstract;
using DataAccess.Abstact;
using DataAccess.Concrete.EntityFramework.Repository;
using Entities.Concrete;
using Shareds.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StaffManager : IStaffService
    {
        IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public IResult Add(Staff staff)
        {
            _staffDal.Add(staff);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(Staff staff)
        {
            _staffDal.Delete(staff);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IDataResult<Staff> GetById(int id)
        {
            return new SuccessDataResult<Staff>(_staffDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Staff>> GetList()
        {
            return new SuccessDataResult<List<Staff>>(_staffDal.GetList().ToList(), "Başarıyla Veriler Geldi");
        }

        public IResult Update(Staff staff)
        {
            _staffDal.Update(staff);
            return new SuccessResult("Başarıyla Eklendi");
        }
    }
}
