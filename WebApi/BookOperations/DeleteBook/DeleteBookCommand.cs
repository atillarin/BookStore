using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;
        public int BookId;

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x=> x.Id ==BookId);
            if (book is null)
                throw new InvalidOperationException("Silinecek kitap bulunamadi!");  
            _context.Books.Remove(book);
            _context.SaveChanges();
        }



    }
    
}