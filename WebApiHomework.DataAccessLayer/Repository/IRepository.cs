using System.Collections.Generic;
using WebApiHomework.DataAccessLayer.Models;

namespace WebApiHomework.DataAccessLayer.Repository
{
    public interface IRepository
    {
        public List<BookEntity> GetAllBooks();
        public BookEntity GetBookById(int id);
        public void CreateBook(BookEntity bookEntity);
        public void UpdateBookById(BookEntity bookEntity, int id);
        public void DeleteBookById(int id);
        public void UpdateStock(int stock, int id);
        public List<BookEntity> GetBooksByFilter(BookEntity bookEntity);
    }
}
