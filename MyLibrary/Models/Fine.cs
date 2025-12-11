using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Models
{
    public class Fine
    {
        public int FineId { get; set; }      
        public int TransactionId { get; set; }
        [ForeignKey(nameof(TransactionId))]
        public BorrowTransaction BorrowTransaction { get; set; }
        public  decimal Amount { get; set; }    
        public  string Reason { get; set; } 
        public  DateTime IssueDate { get; set; } 
        public DateTime PaymentDate { get; set; }
        public finestatus finestatus { get; set; }

    }
    public enum finestatus
    {
        Pending,
        Paid,
        Waived
    }

}
