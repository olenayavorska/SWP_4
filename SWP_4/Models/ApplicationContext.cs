using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWP_4.Models
{
    public class ApplicationContext :  DbContext
    {
       
            public DbSet<User> Users { get; set; }
           
            public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
            {
                Database.EnsureCreated();
            }
            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
               
            //    User adminUser1 = new User { Id = 1, Email = "admin@mail.com", Password = "123456"};
            //    User adminUser2 = new User { Id = 2, Email = "tom@mail.com", Password = "123456" };
            //    User simpleUser1 = new User { Id = 3, Email = "bob@mail.com", Password = "123456"};
            //    User simpleUser2 = new User { Id = 4, Email = "sam@mail.com", Password = "123456"};

            //    base.OnModelCreating(modelBuilder);
            //}
        }
        
       
    
}
