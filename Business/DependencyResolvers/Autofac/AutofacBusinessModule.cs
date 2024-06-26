﻿using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstact;
using DataAccess.Concrete.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RoomManager>().As<IRoomService>().SingleInstance();
            builder.RegisterType<EfRoomDal>().As<IRoomDal>().SingleInstance();

            builder.RegisterType<StaffManager>().As<IStaffService>().SingleInstance();
            builder.RegisterType<EfStaffDal>().As<IStaffDal>().SingleInstance();

            builder.RegisterType<TestimonialManager>().As<ITestimonialService>().SingleInstance();
            builder.RegisterType<EfTestimonialDal>().As<ITestimonialDal>().SingleInstance();

            builder.RegisterType<ServiceManager>().As<IServiceService>().SingleInstance();
            builder.RegisterType<EfServiceDal>().As<ISercviceDal>().SingleInstance();

            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();

            builder.RegisterType<TrailerManager>().As<ITrailerService>().SingleInstance();
            builder.RegisterType<EfTrailerDal>().As<ITrailerDal>().SingleInstance();

            builder.RegisterType<SubscribeManager>().As<ISubscribeService>().SingleInstance();
            builder.RegisterType<EfSubscribeDal>().As<ISubscribeDal>().SingleInstance();

            builder.RegisterType<BookingManager>().As<IBookingService>().SingleInstance();
            builder.RegisterType<EfBookingDal>().As<IBookingDal>().SingleInstance();

            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<EfContactDal>().As<IContactDal>().SingleInstance();

            builder.RegisterType<GuestManager>().As<IGuestService>().SingleInstance();
            builder.RegisterType<EfGuesttDal>().As<IGuestDal>().SingleInstance();

            builder.RegisterType<SendMessageManager>().As<ISendMessageService>().SingleInstance();
            builder.RegisterType<EfSendMessageDal>().As<ISendMessageDal>().SingleInstance();

        }
    }
}
