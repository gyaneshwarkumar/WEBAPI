using BusinessEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.WebAPI.Filters
{


    public class CourseValidator : AbstractValidator<CourseEntity>
    {
        public CourseValidator()
        {
            RuleFor(m => m.Course_Name).NotEmpty().WithMessage("'Course Name' must not be empty");
        }
    }

}
