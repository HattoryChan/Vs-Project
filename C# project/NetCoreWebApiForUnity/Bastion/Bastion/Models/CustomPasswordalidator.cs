using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace Bastion.Models
{
    public class CustomPasswordValidator : IPasswordValidator<ApplicationUser>
    {
        public int RequiredLength { get; set; } // минимальная длина

        public CustomPasswordValidator(int length)
        {
            RequiredLength = length;
        }

        public Task<IdentityResult> ValidateAsync
            (UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (String.IsNullOrEmpty(password) || password.Length < RequiredLength)
            {
                errors.Add(new IdentityError
                {
                    Description = String.Format("Минимальная длина пароля равна {0}", RequiredLength)
                });
            }
          // string pattern = "^[0-9]+$";

          /*  if (!Regex.IsMatch(password, pattern))
            {
                errors.Add(new IdentityError
                {
                    Description = "Пароль должен состоять только из цифр"
                });
            }*/
            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
