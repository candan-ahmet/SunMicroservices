using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunFramework.Services.Models
{
    public enum ResponseStatus
    {
        None = 0,
        Completed = 1,
        Error = 2,
        TimedOut = 3,
        Aborted = 4
    }
}