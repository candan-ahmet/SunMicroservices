﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SunFramework.Aspect.Extensions.AspNetCore.Http
{
    public static class ExecutionContextHelper
    {
        public static ExecutionContext Current { get; set; }
    }
}
