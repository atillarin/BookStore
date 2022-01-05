using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public List<BooksModelView> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x=> x.Id).ToList<Book>();
            List<BooksModelView> vm = new List<BooksModelView>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksModelView
                {
                    Title = book.Title,
                    PageCount = book.PageCount,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy")

                });  
            }

            return vm;
        }

    }

    public class BooksModelView
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }


}