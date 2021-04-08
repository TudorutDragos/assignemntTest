using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebApiHomework.DataAccessLayer.Models;

namespace WebApiHomework.DataAccessLayer.Repository
{
    public class Repository : IRepository
    {
        public List<BookEntity> GetAllBooks()
        {
            using (var context = new BookDbContext())
            {
                var books = context.BookEntities
                    .ToList();
                return books;
            }
        }

        public BookEntity GetBookById(int id)
        {
            using (var context = new BookDbContext())
            {
                var book = context.BookEntities
                    .Where(x => x.BookId == id)
                    .Single();
                return book;
            }
        }

        public void CreateBook(BookEntity bookEntity)
        {
            using (var context = new BookDbContext())
            {
                context.BookEntities.Add(bookEntity);
                context.SaveChanges();
            }
        }

        public void UpdateBookById(BookEntity bookEntity, int id)
        {
            using (var context = new BookDbContext())
            {
                var book = context.BookEntities
                    .Where(x => x.BookId == id)
                    .Single();
                if(book != null)
                {
                    book.Name = bookEntity.Name != null ? bookEntity.Name : book.Name;
                    book.Author = bookEntity.Author != null ? bookEntity.Author : book.Author;
                    book.Genre = bookEntity.Genre != null ? bookEntity.Genre : book.Genre;
                    book.Language = bookEntity.Language != null ? bookEntity.Language : book.Language;
                    book.PublishedYear = bookEntity.PublishedYear != 0 ? bookEntity.PublishedYear : book.PublishedYear;
                    book.RecommendedAge = bookEntity.RecommendedAge != 0 ? bookEntity.RecommendedAge : book.RecommendedAge;
                }
                context.SaveChanges();
            }
        }

        public void DeleteBookById(int id)
        {
            using (var context = new BookDbContext())
            {
                var book = context.BookEntities
                    .Where(x => x.BookId == id)
                    .Single();
                context.BookEntities.Remove(book);
                context.SaveChanges();
            }
        }

        public void UpdateStock(int stock, int id)
        {
            using (var context = new BookDbContext())
            {
                var book = context.BookEntities
                    .Where(x => x.BookId == id)
                    .Single();
                if (book != null)
                {
                    book.StockNumber = stock;
                }
                context.SaveChanges();
            }
        }

        public List<BookEntity> GetBooksByFilter(BookEntity bookEntity)
        {
            using (var context = new BookDbContext())
            {
                IEnumerable<BookEntity> newContext = context.BookEntities.ToList();
                if (!string.IsNullOrWhiteSpace(bookEntity.Name))
                    newContext = newContext.Where(x => x.Name == bookEntity.Name);
                if(!string.IsNullOrWhiteSpace(bookEntity.Author))
                    newContext = newContext.Where(x => x.Author == bookEntity.Author);
                if (!string.IsNullOrWhiteSpace(bookEntity.Language))
                    newContext = newContext.Where(x => x.Language == bookEntity.Language);
                if (!string.IsNullOrWhiteSpace(bookEntity.Genre))
                    newContext = newContext.Where(x => x.Genre == bookEntity.Genre);
                if (bookEntity.PublishedYear != 0)
                    newContext = newContext.Where(x => x.PublishedYear == bookEntity.PublishedYear);
                if (bookEntity.RecommendedAge != 0)
                    newContext = newContext.Where(x => x.RecommendedAge == bookEntity.RecommendedAge);

                return newContext.ToList();
            }
        }
    }
}
