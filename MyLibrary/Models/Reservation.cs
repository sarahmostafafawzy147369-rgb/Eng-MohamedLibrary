using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public int MemberId {  get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }
        public int BookId {  get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book {  get; set; }
        public DateTime ReservationDate { get; set; }   
        public DateTime ExpiryDate { get; set; }
        public  bool NotificationSent {  get; set; }   
        public Status Status { get; set; }  

    }
    public enum Status
    {
        Active,
        Fulfilled,
        Cancelled,
        Expired,
    }
}
