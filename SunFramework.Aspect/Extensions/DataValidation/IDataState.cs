using System;
using System.Collections.Generic;
using System.Text;
using SunFramework.Aspect.DynamicProxy;

namespace SunFramework.Aspect.Extensions.DataValidation
{
    [NonAspect]
    public interface IDataState
    {
        bool IsValid { get; }

        DataValidationErrorCollection Errors { get; }
    }
}