﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestCoreApp.Areas.Employees.Models;
using TestCoreApp.Models;

namespace TestCoreApp.Data
{
   public class AppDbContext : IdentityDbContext<IdentityUser>
    {           //Contructor 1- DbContextsOptions is a generic which contain our class 2- options will be sent to DbContext constructor 

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { //we need to define item class datatypes 

        }
        public DbSet<Item> Items { get; set; } //All datatypes in class item model are defined 
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employees> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  

            modelBuilder.Entity<Category>().HasData(
                 new Category() {Id = 1, Name = "Electric Machine" },
                new Category() { Id = 2, Name = "Computer" },
                new Category() { Id = 3, Name = "Mobile" },
                new Category() { Id = 4, Name = "Non of the above" }
                );

        }
                
        }
    }

