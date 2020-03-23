using System;
using System.Linq;
using SunFramework.Aspect.DynamicProxy.Parameters;
using SunFramework.Aspect.Extensions.Reflection;
using System.ComponentModel.DataAnnotations;

namespace SunFramework.Aspect.Extensions.DataValidation
{
    public sealed class DataMetaData
    {
        public Type Type { get; }

        public Attribute[] Attributes { get; }

        public object Value { get; }

        public DataValidationErrorCollection Errors { get; }

        public DataValidationState State { get; set; }

        public DataMetaData(Parameter paramter)
        {
            Type = paramter.Type;
            Value = paramter.Value;
            Attributes = paramter.ParameterInfo.GetReflector().GetCustomAttributes();
            Errors = new DataValidationErrorCollection();
        }
    }
}