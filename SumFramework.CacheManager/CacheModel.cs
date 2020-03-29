using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumFramework.Cache
{
    public class CacheModel
    {
        private object value;

        public object Value 
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }
        public DateTime CacheDate { get; set; }

        public CacheModel(object value)
        {
            Value = value;
            CacheDate = DateTime.Now;
        }
    }
}
