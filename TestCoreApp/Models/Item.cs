using System.ComponentModel.DataAnnotations;

namespace TestCoreApp.Models
{
    public class Item //Table called Items same as CREATE TABLE Items
    {
        [Key] //Means that Id is Primary Key
        public int Id { get; set; } //field , column of the table
        [Required] //Cant be null
        public string Name { get; set; } 
        [Required]
        public decimal Price { get; set; } 
         
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
