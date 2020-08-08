﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IJwtService
    {
        string GenereateJwt(AppUser appUser, List<AppRole> roles);

    }
}
