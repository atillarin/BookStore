using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model{get;set;}
        private readonly BookStoreDbContext _dbContext;

        public UpdateBookCommand(BookStoreDbContext context)
        {
            _dbContext = context;
        }

        public void Handle(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id ==id);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadi.");           
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.Title = Model.Title != default ? Model.Title : book.Title ;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate :book.PublishDate ;
            _dbContext.SaveChanges();
            
        }

    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}