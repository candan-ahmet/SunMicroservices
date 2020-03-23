using System.Collections.Generic;
using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.Extensions.DataValidation
{
    [NonAspect]
    public interface IPropertyValidator
    {
        IEnumerable<DataValidationError> Validate(PropertyValidationContext propertyValidationContext);
    }
}