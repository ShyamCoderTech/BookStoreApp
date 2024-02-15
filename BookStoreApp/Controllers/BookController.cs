using BookStoreApp.Models;
using BookStoreApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly BookRepository _repository;

        public BookController(BookRepository repository)
        {
            _repository = repository;
        }
        public IActionResult GetAllBook(string search, int pageIndex = 1, int pageSize = 5)
        {
            var paginationModel = _repository.GetAllBook(search, pageIndex, pageSize);
            return View(paginationModel);
        }


        public IActionResult GetBookById(int id)
        {
            var data = _repository.GetBookById(id); 
            if(data !=null)
            {
                return View(data);
            }
            return View();
        }
        public IActionResult AddNewBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewBook(BookModel bookModel)
        {
            if(ModelState.IsValid)
            {
                var data = _repository.AddNewBook(bookModel);
                if (data > 0)
                {
                    return RedirectToAction("AddNewBook", "Book");
                }
            }
            return View();
        }

        public IActionResult DeleteBook(int id)
        {
             _repository.DeleteBook(id);

            return RedirectToAction("GetAllBook","Book");
        }

        public IActionResult UpdateBook(int id)
        {
           if(ModelState.IsValid)
            {
                var data = _repository.GetBookById(id);
                if (data != null)
                {
                    return View(data);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult UpdateBook(BookModel bookModel)
        {
           if(ModelState.IsValid)
            {
                var data = _repository.UpdateBook(bookModel);
                if (data > 0)
                {
                    return RedirectToAction("GetAllBook", "Book");
                }
            }
            return View();
        }
    }
}
