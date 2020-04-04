﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Interface.Manager.Model
{
    public interface ICacheModel
    {
        object Value { get; set; }
        DateTime CacheDate { get; set; }
    }
}