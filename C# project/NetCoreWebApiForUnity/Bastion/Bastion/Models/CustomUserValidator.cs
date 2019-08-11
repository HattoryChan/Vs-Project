using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Bastion.Models
{
    public class CustomUserValidator : IUserValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (user.Email.ToLower().EndsWith("@spam.com"))
            {
                errors.Add(new IdentityError
                {
                    Description = "Данный домен находится в спам-базе. Выберите другой почтовый сервис"
                });
            }
            if (user.UserName.Contains("admin"))
            {
                errors.Add(new IdentityError
                {
                    Description = "Ник пользователя не должен содержать слово 'admin'"
                });
            }
            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}

