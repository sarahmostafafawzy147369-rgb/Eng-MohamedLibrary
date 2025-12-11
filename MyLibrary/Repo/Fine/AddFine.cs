using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.Repo
{
    public class AddFine:IAddFine
    {
        private readonly MyDbcontext _myDbcontext;
        public AddFine(MyDbcontext myDbcontext)
        {
            _myDbcontext = myDbcontext; 
        }
       public void AddFinee(Fine fine)
        {
            _myDbcontext.Fine.Add(fine);
            _myDbcontext.SaveChanges(); 
        }
    }
}
