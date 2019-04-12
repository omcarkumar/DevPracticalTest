using FluentValidation;
using SharedContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.FluentValidation
{
    public class PatientDemographicsValidator : AbstractValidator<PatientDemographics>
    {
        public PatientDemographicsValidator()
        {
            RuleFor(x => x.Forenames).MinimumLength(3).WithErrorCode(((int)1).ToString()).WithMessage("minimum 3 characters in length.");
            RuleFor(x => x.Forenames).MaximumLength(50).WithErrorCode(((int)1).ToString()).WithMessage("maximum 50 characters in length.");
            RuleFor(x => x.Forenames).NotNull().WithErrorCode(((int)1).ToString()).WithMessage("cannot be null or empty.");

            RuleFor(x => x.Surname).MinimumLength(2).WithErrorCode(((int)2).ToString()).WithMessage("minimum 3 characters in length.");
            RuleFor(x => x.Surname).MaximumLength(50).WithErrorCode(((int)2).ToString()).WithMessage("maximum 50 characters in length.");
            RuleFor(x => x.Surname).NotNull().WithErrorCode(((int)2).ToString()).WithMessage("cannot be null or empty.");

            RuleFor(x => x.Gender).NotNull().WithErrorCode(((int)4).ToString()).WithMessage("cannot be null or empty.");

            RuleFor(x => x.DateofBirth).Must(MactchDateFormat).WithErrorCode(((int)3).ToString()).WithMessage("Password must have at least 1 special character.");

        }

        private bool MactchDateFormat(DateTime arg)
        {
            return true; // Apply the Regexp.IsMatch()
        }
    }
}
