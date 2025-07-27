using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApp.Models
{
    public class Item //Table called Items same as CREATE TABLE Items
    {
        [Key] //Means that Id is Primary Key
        public int Id { get; set; } //field , column of the table
        [Required] //Cant be null
        public string Name { get; set; } 
        [Required]
        [Range(5,30000, ErrorMessage ="The value for {0} must be between {1} and {2}. ")]
        [DisplayName("Price of item")]
        public decimal Price { get; set; } 
         
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategortId { get; set; }
        public Category? Category { get; set; }

      
    }
   
    }
