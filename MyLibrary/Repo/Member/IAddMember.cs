using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.Repo
{
    public interface IAddMember
    {
        public void AddMemberr(Member member);
        public Member GetMemberrById( int id); 
    }
}
