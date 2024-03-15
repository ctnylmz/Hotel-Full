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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public IResult Add(Testimonial testimonial)
        {
            _testimonialDal.Add(testimonial);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(Testimonial testimonial)
        {
            _testimonialDal.Delete(testimonial);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IDataResult<Testimonial> GetById(int id)
        {
            return new SuccessDataResult<Testimonial>(_testimonialDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Testimonial>> GetList()
        {
            return new SuccessDataResult<List<Testimonial>>(_testimonialDal.GetList().ToList(), "Başarıyla Veriler Geldi");
        }

        public IResult Update(Testimonial testimonial)
        {
            _testimonialDal.Update(testimonial);
            return new SuccessResult("Başarıyla Eklendi");
        }
    }
}
