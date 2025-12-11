using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.ViewModel
{
    public class AddBookViewModel
    {  
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public IFormFile CoverImageUrl { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public string ShelfLocation { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<SelectListItem> AllCategory { get; set; }
    }
}
