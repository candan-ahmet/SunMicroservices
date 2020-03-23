using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.Extensions.DataValidation
{
    [NonAspect]
    public interface IDataStateFactory
    {
        IDataState CreateDataState(DataValidationContext dataValidationContext);
    }
}