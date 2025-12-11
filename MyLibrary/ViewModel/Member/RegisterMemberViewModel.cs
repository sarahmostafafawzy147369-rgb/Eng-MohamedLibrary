namespace MyLibrary.ViewModel
{
    public class RegisterMemberViewModel
    {
        public string MembershipNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime MembershipDate { get; set; }
        public DateTime MembershipExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public int MaxBooksAllowed { get; set; }
        public decimal OutstandingFees { get; set; }
    }
}
