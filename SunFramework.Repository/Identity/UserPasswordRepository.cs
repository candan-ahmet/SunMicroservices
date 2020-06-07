﻿using SunFramework.Interface.Repository;
using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunFramework.Abstract.Repository;
using System.Data.Entity;

namespace SunFramework.Repository.Identity
{
    public class UserPasswordRepository : BaseRepository<IUserPasswordModel>
    {
        public UserPasswordRepository(DbContext context) : base(context)
        {
        }
    }
}