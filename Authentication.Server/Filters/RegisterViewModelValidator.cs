using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Token.WebApiCore.Server.Models;

namespace Authentication.Server.Filters
{
    //    public class RegisterViewModelValidator
    //    {
    //    }
    //}

    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(m => m.Email).EmailAddress();
            RuleFor(m => m.Password).NotEmpty().MinimumLength(6).MaximumLength(100);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords do not match");
        }
    }

}


