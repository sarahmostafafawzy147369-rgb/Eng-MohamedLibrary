using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.Repo
{
    public class AddBook: IAddBook
    {
        private readonly MyDbcontext _myDbcontex;
        public AddBook(MyDbcontext myDbcontext)
        {
            _myDbcontex = myDbcontext;  
        }
        public  async Task AddBookk(Book book)
        {
            _myDbcontex.Book.Add(book);
            _myDbcontex.SaveChanges();
        }
        public  async Task<List<Book>> ReturnBooksNotActive()
        { 
            return  await _myDbcontex.Book.Include(c=>c.Category).Where(s => s.IsActive==true ).ToListAsync();
        }
        public async  Task<List<Book>> AllBooks()
        {
            return await _myDbcontex.Book.Include(b=>b.Category).ToListAsync();
        }


    }
}
