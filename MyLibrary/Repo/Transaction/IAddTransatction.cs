using MyLibrary.Models;

namespace MyLibrary.Repo
{
    public interface IAddTransatction
    {
        public void AddTransatctionn(BorrowTransaction borrowTransaction);
        public List<BorrowTransaction> GetTransatctions();
        public BorrowTransaction BorrowTransactionDetailsByID(int id );
        public void UpdateTransactionLatefee(BorrowTransaction transaction, bool latefeee);
        public bool CalculateLatefee(BorrowTransaction borrowTransaction);


    }
}
