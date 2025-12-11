using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibrary.Models;
using MyLibrary.Repo;
using MyLibrary.ViewModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace MyLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAddCategory _AddCategory;
        private readonly IWebHostEnvironment _env;
        private readonly IAddBook _addBook;
        private readonly IAddMember _addMember;
        private readonly IAddTransatction _addTransatction;
        private readonly IAddFine _addFine;
        public HomeController(IAddCategory addCategory, IWebHostEnvironment env, IAddBook addBook, IAddMember addMember, IAddTransatction addTransatction, IAddFine addFine)
        {
            _AddCategory = addCategory;
            _env = env;
            _addBook = addBook;
            _addMember = addMember;
            _addTransatction = addTransatction;
            _addFine = addFine;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegisterMember()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterMember(RegisterMemberViewModel model)
        {
            var newmember = new Member
            {
                MembershipNumber = model.MembershipNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                MembershipDate = DateTime.Now,
                MembershipExpiryDate = DateTime.Now.AddYears(1),
                IsActive = model.IsActive,
                MaxBooksAllowed = model.MaxBooksAllowed,
                OutstandingFees = model.OutstandingFees,
            };
            _addMember.AddMemberr(newmember);

            return RedirectToAction("AddBorrowTransaction", new { MemberID = newmember.Id });
        }
        [HttpPost]
        public IActionResult AddCategory(AddCotegoryViewModel model)
        {
            var newCategory = new Category
            {
                Name = model.Name,
                Description = model.Description,
            };
            _AddCategory.AddCategoryy(newCategory);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> AddBook()
        {
            var allcategories = _AddCategory.GetAllCategory();
            var CategoryList = allcategories.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.CategoryId.ToString(),
            }).ToList();
            var List = new AddBookViewModel
            {
                AllCategory = CategoryList,
            };
            return View(List);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookViewModel model)
        {
            var ImageName = Guid.NewGuid() + Path.GetExtension(model.CoverImageUrl.FileName);
            var ImagePath = Path.Combine(_env.WebRootPath, "Images", ImageName);
            using (var newstream = new FileStream(ImagePath, FileMode.Create))
            {
                await model.CoverImageUrl.CopyToAsync(newstream);
            }
            var newbook = new Book
            {
                ISBN = model.ISBN,
                Author = model.Author,
                Title = model.Title,
                Publisher = model.Publisher,
                PublicationYear = model.PublicationYear,
                CategoryId = model.CategoryId,
                Description = model.Description,
                CoverImageUrl = ImageName,
                TotalCopies = model.TotalCopies,
                AvailableCopies = model.AvailableCopies,
                ShelfLocation = model.ShelfLocation,
                IsActive = model.IsActive,
                CreatedDate = model.CreatedDate,
            };
            await _addBook.AddBookk(newbook);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddBorrowTransaction(int MemberID)
        {
            var allValidBookes = await _addBook.ReturnBooksNotActive();
            var AllBooksSelectList = allValidBookes.Select(l => new SelectListItem
            {
                Text=l.Title,
                Value = l.BookId.ToString(),
            }).ToList();
            var List = new BorrowTransactionViewModel
            {
                AllBooks = AllBooksSelectList,
                MemberId = MemberID
            };

            return View(List);
        }

        [HttpPost]
        public async Task<IActionResult> AddBorrowTransaction(BorrowTransactionViewModel model)
        {
            var newTransaction = new BorrowTransaction
            {
                BookId=model.BookId,
                MemberId=model.MemberId,
                BorrowDate=DateTime.Now,
                ReturnDate=DateTime.Now.AddMinutes(1),
                RenewalCount=0,
                LateFee=false,
                DueDate=DateTime.Now.AddMinutes(1),
                StatusstatusBorrowTransaction=0
            };
            _addTransatction.AddTransatctionn(newTransaction);
            return RedirectToAction("ShowAllTransactions");
        }
        public IActionResult ShowAllTransactions()
        {
            var alltran = _addTransatction.GetTransatctions().Select(t =>
            {
                bool check = _addTransatction.CalculateLatefee(t);
                return new ShowAllTransactionViewModel
                {
                    TransactionId =t.TransactionId,
                    MemberName=t.Member.FirstName+" "+t.Member.LastName,
                    BookTitle =t.Book.Title,
                    BorrowDate =t.BorrowDate,
                    DueDate =t.DueDate,
                    ReturnDate =t.ReturnDate,
                    RenewalCount =t.RenewalCount,
                    //LateFee =check,
                    LateFee =check||t.LateFee,//  دى الطريقه الصح عشان ال
                                              //  boll 
                                              //بتعمل check على انه هل هو لحد دلوقتى لسه مارجعش الكاتب ولا لا وهلى الوقت عدى عليه ولالا لاكن انا عايزه اعرف حتى لو هو رجع هو عليه غرامه ولالا
                    //هنا هو هياخد ال value اللى ب true هياخدها ويحطها لو الاتني ب true يبقا ال Transaction عليها fine ولو واده بس معنا كده 
                    StatusTransaction=t.StatusstatusBorrowTransaction,
                };           
            }).ToList();
            return View(alltran);
        }

        public IActionResult Details(int id)
        {
            var transaction = _addTransatction.BorrowTransactionDetailsByID(id);

            var newtransactionDetailsViewModel = new transactionDetailsViewModel
            {
                TransactionId=transaction.TransactionId,
                MemberId=transaction.MemberId,
                MemberName=transaction.Member.FirstName+" "+transaction.Member.LastName,
                BookId=transaction.BookId,
                BorrowDate=transaction.BorrowDate,
                DueDate=transaction.DueDate,
                ReturnDate=transaction.ReturnDate,
                RenewalCount =transaction.RenewalCount,
                LateFee=transaction.LateFee,
                StatusstatusBorrowTransaction=transaction.StatusstatusBorrowTransaction,
            };
            return View(newtransactionDetailsViewModel);
        }

            //if(transaction.StatusstatusBorrowTransaction==0&&DateTime.Now> transaction.ReturnDate)
            //{
            //    _addTransatction.UpdateTransactionLatefee(transaction, true);
            //var newfine = new Fine
            //{
            //    TransactionId=transaction.TransactionId,
            //    Amount=1000,
            //    finestatus=0,
            //    IssueDate=DateTime.Now,
            //    Reason="Late",
            //    PaymentDate=DateTime.Now.AddDays(1),
            //    BorrowTransaction=transaction,
            //};
            //_addFine.AddFinee(newfine);
            //return View(newfine);
            //}
      //       // return RedirectToAction("ShowAllTransactions");
      //  }

        public  async Task<IActionResult> ShowAllBooks()
        {
            var AllBooks =  await _addBook.AllBooks();
            var list = AllBooks.Select(b => new ShowAllBooksViewModel
            {
                ISBN=b.ISBN,
                Author=b.Author,
                Title=b.Title,
                Category=b.Category.Name,
                ImagUrl=b.CoverImageUrl

            }).ToList();

            return View(list);
        }

    }

}


