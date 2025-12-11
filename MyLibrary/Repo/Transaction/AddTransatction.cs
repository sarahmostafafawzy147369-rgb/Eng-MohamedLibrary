using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.Repo
{
    public class AddTransatction: IAddTransatction
    {
        private readonly MyDbcontext _myDbcontext;
        public AddTransatction(MyDbcontext myDbcontext)
        {
            _myDbcontext = myDbcontext;
        }
        public void AddTransatctionn(BorrowTransaction borrowTransaction)
        {
            _myDbcontext.BorrowTransaction.Add(borrowTransaction);
            _myDbcontext.SaveChanges();
        }
        public List<BorrowTransaction> GetTransatctions()
        {
            return _myDbcontext.BorrowTransaction
                .Include(m=>m.Member)
                .Include(b=>b.Book).ToList();
        }
        public BorrowTransaction BorrowTransactionDetailsByID(int id)
        {
            return _myDbcontext.BorrowTransaction.Include(m=>m.Member).FirstOrDefault(t => t.TransactionId==id);
        }
        public void  UpdateTransactionLatefee(BorrowTransaction transaction,bool latefeee )
        {
            transaction.LateFee = latefeee;  
            _myDbcontext.SaveChanges();
        }
        public bool CalculateLatefee(BorrowTransaction borrowTransaction)
        {
           if(borrowTransaction.StatusstatusBorrowTransaction==0&&DateTime.Now>borrowTransaction.ReturnDate)
            {
                borrowTransaction.LateFee=true;
                var newfine = new Fine
                {
                TransactionId=borrowTransaction.TransactionId,
                Amount=1000,
                finestatus=0,
                IssueDate=DateTime.Now,
                PaymentDate=DateTime.Now,
                Reason="Late",             
                };
                 _myDbcontext.Fine.Add(newfine);
                _myDbcontext.SaveChanges();
                return true;
            }
           return false;
        }
    }
}
