using Business.Interfaces;
using Business.StringInfos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService,IAppUserRoleService appUserRoleService,IAppRoleService appRoleService)
        {
           var adminRole= await appRoleService.FindByName(RoleInfo.Admin);

            if (adminRole==null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Admin
                });
            }

            var memberRole = await appRoleService.FindByName(RoleInfo.Member);

            if (memberRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Member
                });
            }

            var adminnUser = await appUserService.FindByUserName("sercan");
            if (adminnUser==null)
            {
                await appUserService.Add(new AppUser
                {
                    FullName="sercan fırtına",
                    UserName="sercan",
                    Password="5"
                });

                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var admin = await appUserService.FindByUserName("sercan");

                await appUserRoleService.Add(new AppUserRole
                {
                    AppUserId=admin.Id,
                    AppRoleId=role.Id
                });
            }
        }
    }
}
