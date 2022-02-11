using CollectionsLibrary.Abstract;
using CollectionsLibrary.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionsLibrary.Concrete
{
    public class ValidatedList<T, TValidator> : IValidatedCollection<T, TValidator> where TValidator : AbstractValidator<T>, new()
    {
        private T[] array = new T[0];
        private readonly TValidator _validator;
        public int Count => array.Length;

        public bool IsReadOnly { get; set; }

        public ValidatedList()
        {
            IsReadOnly = false;
            _validator = new TValidator();
        }

        public void Add(T item)
        {
            ValidationResult validation = new ValidationResult();
            try
            {

                validation = _validator.Validate(item);
                if (!validation.IsValid)
                {
                    throw new ValidationException(validation.Errors[0].ErrorMessage);
                }
                Console.WriteLine(validation.Errors.Count);
                T[] temporaryArr = new T[array.Length + 1];
                array.CopyTo(temporaryArr, 0);
                temporaryArr[array.Length] = item;
                array = new T[temporaryArr.Length];
                temporaryArr.CopyTo(array, 0);

            }
            catch (Exception e) 
            {

                throw;
            }


        }

        public void Clear()
        {
            array = new T[1];
        }

        public bool Contains(T item)
        {
            foreach (var arrItem in array)
            {
                if ((object)arrItem == (object)item)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            array.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        public bool Remove(T item)
        {
            
            var temporary = new T[array.Length-1];
            int tempIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if ((object)array[i] == (object)item)
                {

                    continue;
                }
                tempIndex++;
                if (tempIndex >= array.Length-1)
                {
                    return false;
                }
                temporary[tempIndex] = array[i];
            }
            array = new T[temporary.Length];
            temporary.CopyTo(array, 0);
            return true;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IValidatedCollection<T, TValidator> validatedCollection)
        {
            foreach (var item in array)
            {
                validatedCollection.Add(item);
            }
        }
    }
}
