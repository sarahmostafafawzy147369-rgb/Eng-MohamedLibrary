using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.Repo
{
    public class AddCategory:IAddCategory
    {
        private readonly MyDbcontext _myDbcontex;
        public AddCategory(MyDbcontext myDbcontext)
        {
            _myDbcontex = myDbcontext;
        }
        public void AddCategoryy(Category category)
        {
            _myDbcontex.categories.Add(category);
            _myDbcontex.SaveChanges();
        }
        public List<Category> GetAllCategory()
        {
            return _myDbcontex.categories.ToList();
        }


    }
}
