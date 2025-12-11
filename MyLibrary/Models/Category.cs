using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name{ get; set; }
        public string  Description {get; set; }
        public ICollection<Book> Books { get; set; }    
    }
}
