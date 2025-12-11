using MyLibrary.Models;

namespace MyLibrary.Repo
{
    public interface IAddCategory
    {
        public void AddCategoryy(Category category);
        public List<Category>GetAllCategory();    
    }
}
