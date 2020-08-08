using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.AppUserDto
{
    public class AppUserAddDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
