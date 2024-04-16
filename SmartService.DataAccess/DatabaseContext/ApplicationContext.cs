using Microsoft.EntityFrameworkCore;
using SmartService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartService.DataAccess.DatabaseContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ListCategory> ListCategories { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<SmartService.Domain.Models.Task> Tasks { get; set; }
        public DbSet<TaskUserCache> TaskUserCaches { get; set; }
        public DbSet<TaskResponsibleUser> TaskResponsibleUsers { get; set; }
        public DbSet<UserTaskListCategory> UserTaskListCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskUserCache>()
                .ToTable("#TaskUserCacheADM")
                .HasKey(tuc => new { tuc.TaskID, tuc.UserID, tuc.TaskListCategoryID });

            modelBuilder.Entity<UserTaskListCategory>()
                .ToTable("#UserTaskListCategory")
                .HasKey(utc => new { utc.UserID, utc.TaskListCategoryID });

            modelBuilder.Entity<TaskResponsibleUser>()
                .ToTable("#TaskResponsibleUser")
                .HasKey(tru => new { tru.TaskID, tru.UserID });

            modelBuilder.Entity<Employment>()
                .ToTable("#Employment")
                .HasKey(e => e.UserID);

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
