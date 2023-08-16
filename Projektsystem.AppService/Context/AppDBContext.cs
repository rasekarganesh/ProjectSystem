using System;
using Microsoft.EntityFrameworkCore;
using Projektsystem.Model;

namespace Projektsystem.AppService.Context
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Project> Project { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }
        public DbSet<Budget> Budget { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<UILanguage> UILanguage { get; set; }
        public DbSet<UIText> UIText { get; set; }
        public DbSet<ProjectUser> ProjectUser { get; set; }
    }
}

