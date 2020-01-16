using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Interface.Model
{
    public interface IEntityModel : IEntityModel<int>
    {

    }

    public interface IEntityModel<T> : IEntity
    {
        T GetPrimaryKey();
    }

    public interface IEntityModel<T1, T2> : IEntity
    {
        T1 GetPrimaryKey1();
        T2 GetPrimaryKey2();
    }

    public interface IEntity
    {

    }
}
