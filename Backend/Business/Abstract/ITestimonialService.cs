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
    public interface ITestimonialService
    {
        IResult Add(Testimonial testimonial);
        IResult Update(Testimonial testimonial);
        IResult Delete(Testimonial testimonial);
        IDataResult<List<Testimonial>> GetList();
        IDataResult<Testimonial> GetById(int id);
    }
}
