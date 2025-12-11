using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required(ErrorMessage ="ISBN Required")]
        [MaxLength(13)]
        public string ISBN {  get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }     
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category {  get; set; } 
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public string ShelfLocation { get; set; }
        public bool IsActive { get; set; }  
        public DateTime CreatedDate { get; set; }  
        public ICollection<BorrowTransaction> BorrowTransactions { get; set; }  
        public ICollection<Reservation> reservations {  get; set; }
    }
}
