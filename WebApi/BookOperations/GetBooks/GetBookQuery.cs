using System;
using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBookQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId;
        public GetBookQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookModelView Handle()
        {
            var book = _dbContext.Books.Where(book=>book.Id == BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap Bulunamadi!");

            BookModelView Model = _mapper.Map<BookModelView>(book);
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