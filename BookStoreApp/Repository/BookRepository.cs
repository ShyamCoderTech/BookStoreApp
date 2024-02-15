
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp.Repository
{
    public class BookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public PaginationModel<BookModel> GetAllBook(string search, int pageIndex, int pageSize)
        {
            IEnumerable<BookData> bookData;
            if (string.IsNullOrEmpty(search))
            {
                bookData = _context.BookData.ToList();
            }
            else
            {
                bookData = _context.BookData.Where(findData =>
                    findData.Author.Contains(search) ||
                    findData.AuthorUrl.Contains(search) ||
                    findData.Title.Contains(search) ||
                    findData.TitleUrl.Contains(search) ||
                    findData.Description.Contains(search) ||
                    findData.DescriptionUrl.Contains(search));
            }

            var totalCount = bookData.Count();

            var paginatedData = bookData.Skip((pageIndex - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToList();

            var bookModelList = paginatedData.Select(book => new BookModel
            {
                Author = book.Author,
                AuthorUrl = book.AuthorUrl,
                Description = book.Description,
                DescriptionUrl = book.DescriptionUrl,
                Id = book.Id,
                Title = book.Title,
                TitleUrl = book.TitleUrl
            }).ToList();

            var paginationModel = new PaginationModel<BookModel>(bookModelList, totalCount, pageIndex, pageSize);

            return paginationModel;
        }

        public BookModel GetBookById(int id)
        {
            var data = _context.BookData.Find(id);
            if(data != null) {
                var bookModel = new BookModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    TitleUrl = data.TitleUrl,
                    Author = data.Author,
                    AuthorUrl = data.AuthorUrl,
                    Description = data.Description,
                    DescriptionUrl = data.DescriptionUrl
                };
                return bookModel;
            }
            return null;
        }
        public int AddNewBook(BookModel bookModel)
        {
            var bookData = new BookData()
            {
                Author = bookModel.Author,
                AuthorUrl = bookModel.AuthorUrl,
                Description = bookModel.Description,
                DescriptionUrl = bookModel.DescriptionUrl,
                Id = bookModel.Id,
                TimeStampData = DateTime.Now,
                Title = bookModel.Title,
                TitleUrl = bookModel.TitleUrl
            };
            _context.Add(bookData);
            _context.SaveChanges();
            return bookData.Id;
        }
        public void DeleteBook(int id)
        {
            var data = _context.BookData.Find(id);
            if(data != null) { 
            
            _context.BookData.Remove(data);
            _context.SaveChanges();
            }
        }
        public int UpdateBook(BookModel bookModel)
        {
            var bookData = _context.BookData.Find(bookModel.Id);
            if(bookData != null) {
            bookData.Author=bookModel.Author;
            bookData.AuthorUrl=bookModel.AuthorUrl;
            bookData.Description=bookModel.Description; 
            bookData.DescriptionUrl=bookModel.DescriptionUrl;
            bookData.Title=bookModel.Title;
            bookData.TitleUrl=bookModel.TitleUrl;
            bookData.Id=bookModel.Id;
                _context.SaveChanges();
                return bookData.Id;
            }
            return -1;
        }
    }
}
