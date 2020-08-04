using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AppRoleManager:GenericManager<AppRole>,IAppRoleService
    {
        public AppRoleManager(IGenericDal<AppRole>genericDal):base(genericDal)
        {

        }
    }
}
