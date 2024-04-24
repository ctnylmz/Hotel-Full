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
    public class SendMessageManager : ISendMessageService
    {
        ISendMessageDal _sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }

        public IResult Add(SendMessage sendMessage)
        {
            _sendMessageDal.Add(sendMessage);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(SendMessage sendMessage)
        {
            _sendMessageDal.Delete(sendMessage);
            return new SuccessResult("Başarıyla Silindi");
        }

        public IDataResult<SendMessage> GetById(int id)
        {
            return new SuccessDataResult<SendMessage>(_sendMessageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<SendMessage>> GetList()
        {
            return new SuccessDataResult<List<SendMessage>>(_sendMessageDal.GetList().ToList(),"Başarıyla Veriler Geldi");
        }

        public IResult Update(SendMessage sendMessage)
        {
            _sendMessageDal.Update(sendMessage);
            return new SuccessResult("Başarıyla Güncellendi");
        }
    }
}
