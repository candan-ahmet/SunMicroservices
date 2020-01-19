using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackableEntities;

namespace SunFramework.Interface.Model
{
    public interface IEntity<TPrimaryKey> : IEntity
    {

    }

    public interface IEntity : ITrackable
    {

    }
}
