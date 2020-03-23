using System.Collections.Generic;
using System.Linq;
using SunFramework.Aspect.DynamicProxy;
using SunFramework.Aspect.DynamicProxy.Parameters;

namespace SunFramework.Aspect.Extensions.DataValidation
{
    public sealed class DataValidationContext
    {
        public IEnumerable<DataMetaData> DataMetaDatas { get; }

        public AspectContext AspectContext { get; }

        public DataValidationContext(AspectContext aspectContext)
        {
            AspectContext = aspectContext;
            DataMetaDatas = aspectContext.GetParameters().Select(param => new DataMetaData(param)).ToArray();
        }
    }
}