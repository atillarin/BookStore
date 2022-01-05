using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBookQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBookQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookModelView Handle(int id)
        {
            var book = _dbContext.Books.Where(book=>book.Id == id).SingleOrDefault();
            
            BookModelView Model = new BookModelView();
            Model.Title = book.Title;
            Model.PageCount = book.PageCount;
            Model.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            Model.Genre=((GenreEnum)book.GenreId).ToString();

            return Model;
                
        }
    }

    public class BookModelView
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}