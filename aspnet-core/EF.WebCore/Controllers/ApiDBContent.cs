﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.WebCore
{
    public class ApiDBContent : DbContext
    {
        public ApiDBContent(DbContextOptions<ApiDBContent> options)
            : base(options)
        {
        }
        public DbSet<UserInfo> Users { get; set; }
    }


    public class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
