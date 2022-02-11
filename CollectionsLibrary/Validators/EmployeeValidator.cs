using CollectionsLibrary.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsLibrary.Validators
{
    public class EmployeeValidator:AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(c => c.FirstName).MinimumLength(3);
            RuleFor(c => c.LastName).MinimumLength(3);
            RuleFor(c => c.Id).GreaterThan(0);
        }
    }
}
