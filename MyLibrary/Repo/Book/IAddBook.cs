using MyLibrary.Models;

namespace MyLibrary.Repo
{
    public interface IAddBook
    {
        public Task AddBookk(Book book);
        public Task<List<Book>> ReturnBooksNotActive();
        public  Task<List<Book>> AllBooks();

    }
}
