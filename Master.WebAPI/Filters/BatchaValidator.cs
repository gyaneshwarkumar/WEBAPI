using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using BusinessEntities;

namespace Master.WebAPI.Filters
{

    public class BatchaValidator : AbstractValidator<BatchEntity>
    {
        public BatchaValidator()
        {
            RuleFor(m => m.Academic_Year).NotEmpty().WithMessage("'Batch Name' must not be empty");
        }
    }

}

