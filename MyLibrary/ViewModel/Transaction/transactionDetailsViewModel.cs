using MyLibrary.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.ViewModel
{
    public class transactionDetailsViewModel
    {
        public int TransactionId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RenewalCount { get; set; }
        public bool LateFee { get; set; }
        public string MemberName { get; set; }
        public statusBorrowTransaction StatusstatusBorrowTransaction { get; set; }
    }
}
