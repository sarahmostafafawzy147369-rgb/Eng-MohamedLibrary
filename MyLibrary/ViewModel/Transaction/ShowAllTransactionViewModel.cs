using MyLibrary.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.ViewModel
{
    public class ShowAllTransactionViewModel
    {
        public int TransactionId { get; set; }
        public string MemberName { get; set; }
        public string BookTitle { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RenewalCount { get; set; }
        public bool LateFee { get; set; }
        public statusBorrowTransaction StatusTransaction { get; set; }
    }
}
