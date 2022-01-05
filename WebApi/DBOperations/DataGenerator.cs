using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations  
{
    public class DataGenerator 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                    return;
                
                context.AddRange(            
                    new Book {
                        
                        Title = "Lean Startup",
                        GenreId = 1, //Personal Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,12)
                    },
                    new Book {
                        
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2005,02,12)
                    },
                    new Book {
                        
                        Title="Dune",
                        GenreId=2,
                        PageCount=400,
                        PublishDate=new DateTime(2001,02,15)
                    },
                    new Book {
                        
                        Title = "Harry Potter",
                        GenreId = 3,
                        PageCount = 600,
                        PublishDate = new DateTime(2002,01,23)
                    }
                );
                context.SaveChanges();

            }
        }


    }

}