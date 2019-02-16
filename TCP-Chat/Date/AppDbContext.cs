using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TCP_Chat.Models;

namespace TCP_Chat.Date {

    public class AppDbContext : IdentityDbContext<User> {

        public DbSet<Connection> Connections { get; set; }
        public DbSet<HistoryLog> HistoryLogs { get; set; }
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

    }

}