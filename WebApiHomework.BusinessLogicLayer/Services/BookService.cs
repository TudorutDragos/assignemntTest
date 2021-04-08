using System.Collections.Generic;
using WebApiHomework.DataAccessLayer.Models;
using WebApiHomework.DataAccessLayer.Repository;

namespace WebApiHomework.BusinessLogicLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository _repository;
        public BookService(IRepository repository)
        {
            _repository = repository;
        }
        public List<BookEntity> GetAllBooks()
        {
            return _repository.GetAllBooks();
        }

        public BookEntity GetBookById(int id)
        {
            return _repository.GetBookById(id);
        }

        public void CreateBook(BookEntity bookEntity)
        {
            _repository.CreateBook(bookEntity);
        }

        public void UpdateBook(BookEntity bookEntity, int id)
        {
            _repository.UpdateBookById(bookEntity, id);
        }

        public void DeleteBookById(int id)
        {
            _repository.DeleteBookById(id);
        }

        public void UpdateStock(int stock, int id)
        {
            _repository.UpdateStock(stock, id);
        }

        public List<BookEntity> GetBooksByFilter(BookEntity bookEntity)
        {
            return _repository.GetBooksByFilter(bookEntity);
        }
    }
}
