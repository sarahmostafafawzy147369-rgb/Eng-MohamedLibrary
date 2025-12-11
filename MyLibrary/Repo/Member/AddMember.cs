using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.Repo
{
    public class AddMember:IAddMember
    {
        private readonly MyDbcontext _myDbcontex;
        public AddMember(MyDbcontext myDbcontext)
        {
            _myDbcontex = myDbcontext;
        }
        public void AddMemberr(Member member)
        {
            _myDbcontex.Member.Add(member);
            _myDbcontex.SaveChanges();
        }
        public Member GetMemberrById(int id)
        {
            return _myDbcontex.Member.FirstOrDefault(m => m.Id==id);
        }


    }
}
