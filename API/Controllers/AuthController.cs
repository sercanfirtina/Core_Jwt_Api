using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.CustomFilters;
using AutoMapper;
using Business.Interfaces;
using Entities.Concrete;
using Entities.Dtos.AppUserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _mapper = mapper;
            _jwtService = jwtService;
            _appUserService = appUserService;
        }


        [HttpGet("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserService.FindByUserName(appUserLoginDto.UserName);
            if (appUser == null)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
            else
            {
                if (await _appUserService.CheckPassword(appUserLoginDto))
                {
                    var roles =await _appUserService.GetRolesByUserName(appUserLoginDto.UserName);
                    var token =_jwtService.GenereateJwt(appUser, roles);
                    return Created("", token);
                }
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }


        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto)
        {
            var appUser = await _appUserService.FindByUserName(appUserAddDto.UserName);
            if (appUser!=null)            
                return BadRequest($"{appUserAddDto.UserName} zaten alınmış");

            await _appUserService.Add(_mapper.Map<AppUser>(appUserAddDto));
            return Created("", appUserAddDto);
        }
    }
}
