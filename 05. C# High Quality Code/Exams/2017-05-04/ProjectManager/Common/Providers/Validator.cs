using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;

namespace ProjectManager.Common.Providers
{
    public class Validator : IValidator
    {
        public void Validate<T>(T obj) where T : class
        {
            IEnumerable<string> validationErrors = this.GetValidationErrors(obj);
            bool isValid = validationErrors.Count() == 0;

            if (!isValid)
            {
                this.LogValidationErrors(validationErrors);
            }
        }

        public void LogValidationErrors(IEnumerable<string> validationErrors)
        {
            throw new UserValidationException(validationErrors.First());
        }

        private IEnumerable<string> GetValidationErrors(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            Type attributeType = typeof(ValidationAttribute);

            foreach (var propertyInfo in properties)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(attributeType, inherit: true);
                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;
                    bool isValid = validationAttribute.IsValid(propertyInfo.GetValue(obj, BindingFlags.GetProperty, null, null, null));

                    if (!isValid)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }
    }
}