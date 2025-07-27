using System.ComponentModel.DataAnnotations;

namespace TestCoreApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Item> Items { get; set; } //Navigation properity to lets know 1 category for many Items


    }
}
