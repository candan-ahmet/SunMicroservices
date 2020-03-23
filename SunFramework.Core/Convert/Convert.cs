using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Core.Convert
{
    public static class Convert
    {
        public static T To<T>(this object input)
        {
            Type cType = typeof(T);
            var result = input;
            if (cType == typeof(Int32))
            {
                result = System.Convert.ChangeType(ToInt32(input), typeof(Int32));
                return (T)result;
            }
            else if(cType.IsGenericType && cType.GenericTypeArguments[0] == typeof(Int32))
            {
                result = System.Convert.ChangeType(ToInt32(input), typeof(Int32));
                return (T)result;
            }

            try
            {
                if (input == null || input == DBNull.Value) return (T)input;
                if (typeof(T).IsEnum)
                {
                    result = (T)Enum.ToObject(typeof(T), result);
                }
                else if(typeof(T) == typeof(int))
                {

                }
                else
                {
                    var a = System.Convert.ChangeType(input, typeof(T));
                }
            }
            catch (Exception ex)
            {
                return (T)result;
            }

            return (T)result;
        }

        private static Int32 ToInt32(object input)
        {
            return System.Convert.ToInt32(input);
        }
    }
}
