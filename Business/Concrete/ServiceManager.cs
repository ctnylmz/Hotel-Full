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
    public class ServiceManager : IServiceService
    {
        ISercviceDal _sercviceDal;

        public ServiceManager(ISercviceDal sercviceDal)
        {
            _sercviceDal = sercviceDal;
        }

        public IResult Add(Service service)
        {
            _sercviceDal.Add(service);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(Service service)
        {
            _sercviceDal.Delete(service);
            return new SuccessResult("Başarıyla Silindi");
        }

        public IDataResult<Service> GetById(int id)
        {
            return new SuccessDataResult<Service>(_sercviceDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Service>> GetList()
        {
            return new SuccessDataResult<List<Service>>(_sercviceDal.GetList().ToList(), "Başarıyla Veriler Geldi");
        }

        public IResult Update(Service service)
        {
            _sercviceDal.Update(service);
            return new SuccessResult("Başarıyla Güncellendi");
        }
    }
}
