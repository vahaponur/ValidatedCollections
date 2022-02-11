using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsLibrary.Abstract
{
    public interface IValidatedCollection<T,TValidator>:ICollection<T> where TValidator:  AbstractValidator<T>,new()
    {
        public void CopyTo(IValidatedCollection<T,TValidator> validatedCollection);
    }
}
