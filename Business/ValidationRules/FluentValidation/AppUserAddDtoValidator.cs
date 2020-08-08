using Entities.Dtos.AppUserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AppUserAddDtoValidator:AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(I => I.FullName).NotEmpty().WithMessage("Ad ve Soyad alanı boş geçilemez");
        }

    }
}
