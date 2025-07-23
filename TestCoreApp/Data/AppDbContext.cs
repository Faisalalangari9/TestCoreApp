using Microsoft.EntityFrameworkCore;
using TestCoreApp.Models;

namespace TestCoreApp.Data
{
   public class AppDbContext : DbContext
    {           //Contructor 1- DbContextsOptions is a generic which contain our class 2- options will be sent to DbContext constructor 
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { //we need to define item class datatypes 

        }
        public DbSet<Item> Items { get; set; } //All datatypes in class item model are defined 
        
                
        }
    }

