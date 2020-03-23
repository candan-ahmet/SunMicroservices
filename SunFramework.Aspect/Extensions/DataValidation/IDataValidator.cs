using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.Extensions.DataValidation
{
    [NonAspect]
    public interface IDataValidator
    {
        void Validate(DataValidationContext context);
    }
} 