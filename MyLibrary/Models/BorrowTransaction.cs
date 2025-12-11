using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Models
{
    public class BorrowTransaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RenewalCount { get; set; }
        public bool LateFee { get; set; }
        public statusBorrowTransaction StatusstatusBorrowTransaction { get; set; } 
    }
    public  enum statusBorrowTransaction
    {
        Active,
        Returned,
        Overdue
    }
}
