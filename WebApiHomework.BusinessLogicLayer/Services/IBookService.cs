using System;
using System.Collections.Generic;
using System.Text;
using WebApiHomework.DataAccessLayer.Models;

namespace WebApiHomework.BusinessLogicLayer.Services
{
    public interface IBookService
    {
        public List<BookEntity> GetAllBooks();
        public BookEntity GetBookById(int id);
        public void CreateBook(BookEntity bookEntity);
        public void UpdateBook(BookEntity bookEntity, int id);
        public void DeleteBookById(int id);
        public void UpdateStock(int stock, int id);
        public List<BookEntity> GetBooksByFilter(BookEntity bookEntity);
    }
}
