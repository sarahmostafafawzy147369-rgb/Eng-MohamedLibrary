using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string MembershipNumber { get; set; }
        [MaxLength(100)]
        [MinLength(2,ErrorMessage ="First Name Must Be Have More Litters")]
        public string  FirstName { get; set; }  
        public string LastName{ get; set; }
        public string Email {  get; set; }
        [DataType(DataType.PhoneNumber)]   
        public  string PhoneNumber { get; set; }
       
        public string Address { get; set; } 
        public DateTime MembershipDate {get; set; } 
        public DateTime MembershipExpiryDate { get; set; }
        public bool IsActive { get; set; }  
        public  int MaxBooksAllowed { get; set; }   
        public  decimal OutstandingFees { get; set; }
        public ICollection<BorrowTransaction> BorrowTransactions { get; set; }  
        public ICollection<Reservation> reservations { get; set; }
        public Role role { get; set; }

    }
    public enum Role
    {
        Admin,
        AnyUser

    }
}
