using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AppUserManager:GenericManager<AppUser>,IAppUserService
    {
        public AppUserManager(IGenericDal<AppUser>genericDal):base(genericDal)
        {

        }
    }
}
