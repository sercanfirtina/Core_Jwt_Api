using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAppUserDal:IGenericDal<AppUser>
    {
        Task<List<AppRole>> GetRolesByUserName(string userName);            
    }
}
