using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TCP_Chat.Date {

    public class AppDbContext : IdentityDbContext<IdentityUser> {

        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

    }

}