using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.AppUserDto
{
    public class AppUserLoginDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
