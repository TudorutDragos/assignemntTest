using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApiHomework.BusinessLogicLayer.Services;
using WebApiHomework.DataAccessLayer.Models;
using WebApiHomework.Error;
using WebApiHomework.Mapper;
using WebApiHomework.Models;
using WebApiHomework.Models.BookViewModels;

namespace WebApiHomework.Controllers
{
    /// <summary>
    /// Web Api Homework 
    /// Implement a full CRUD Web API, that stores data in a DB of your choice (MS Sql preferably).
    /// Use EF Core as an ORM. You will have to use the Code First approach.
    /// The architecture is comprised of 3 Layers. Use each layer appropriately for services, data access, utils, etc.
    ///
    /// The application should be fully functional and must have a basic error handling mechanism with the corresponding
    /// Http Error Code shown when errors occur.
    ///
    /// Optional BONUS POINTS:
    /// - Write the afferent code the Search with filter method.
    /// - Add Swagger for API discoverability.
    /// </summary>

    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMap _map;
        public BookController(IBookService bookService, IMap map)
        {
            _bookService = bookService;
            _map = map;
        }

        [HttpGet]
        [Route("api/[controller]/all")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks();
                List<BookViewModel> bookViewModels = new List<BookViewModel>();
                foreach (var book in books)
                {
                    bookViewModels.Add(_map.ToDTO(book));
                }
                return Ok(bookViewModels);
            }
            catch(Exception e)
            {
                var errorMessage = new ErrorResponse()
                {
                    ErrorMessage = "Some error occure. Please try again"
                };
                return NotFound(errorMessage);
            }
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetBookById([FromRoute] int id)
        {
            try
            {
                var book = _map.ToDTO(_bookService.GetBookById(id));
                return Ok(book);
            }
            catch(Exception e)
            {
                var errorMessage = new ErrorResponse()
                {
                    ErrorMessage = "Some error occure. Please try again"
                };
                return NotFound(errorMessage);
            }
        }

        [HttpPut]
        [Route("api/[controller]/create")]
        public IActionResult CreateBook([FromBody] BookViewModel bookEntry)
        {
            try
            {
                _bookService.CreateBook(_map.ToEntity(bookEntry));
                var uri = "api/[controller]/{id}";

                return Created(uri, bookEntry);
            }
            catch (Exception e)
            {
                var errorMessage = new ErrorResponse()
                {
                    ErrorMessage = "Some error occure. Please try again"
                };
                return NotFound(errorMessage);
            }
        }

        [HttpPost]
        [Route("api/[controller]/update/{id}")]
        public IActionResult UpdateBook([FromBody] BookViewModel bookEntry, [FromRoute] int id)
        {
            try
            {
                _bookService.UpdateBook(_map.ToEntity(bookEntry), id);
                return Created("URI", bookEntry);
            }
            catch (Exception e)
            {
                var errorMessage = new ErrorResponse()
                {
                    ErrorMessage = "Some error occure. Please try again"
                };
                return NotFound(errorMessage);
            }
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            try
            {
                _bookService.DeleteBookById(id);
                return Ok("Book deleted");
            }
            catch (Exception e)
            {
                var errorMessage = new ErrorResponse()
                {
                    ErrorMessage = "Some error occure. Please try again"
                };
                return NotFound(errorMessage);
            }
        }

        [HttpPost]
        [Route("api/[controller]/{id}/stock/update")]
        public IActionResult UpdateBookStock([FromBody] int stock, [FromRoute] int id)
        {
            try
            {
                _bookService.UpdateStock(stock, id);
                return Ok("Stock updated");
            }
            catch (Exception e)
            {
                var errorMessage = new ErrorResponse()
                {
                    ErrorMessage = "Some error occure. Please try again"
                };
                return NotFound(errorMessage);
            }
        }

        /// <summary>
        /// BONUS points for implementing this get method.
        /// </summary>
        /// <param name="bookFilter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/search")]
        public IActionResult GetBooksByFilter([FromBody] BooksFilter bookFilter)
        {
            var bookEntity = new BookEntity()
            {
                Name = bookFilter.Name,
                Author = bookFilter.Author,
                Genre = bookFilter.Genre,
                Language = bookFilter.Language,
                PublishedYear = bookFilter.PublishedYear,
                RecommendedAge = bookFilter.RecommendedAge
            };
            var books = _bookService.GetBooksByFilter(bookEntity);
            List<BookViewModel> bookViewModels = new List<BookViewModel>();
            foreach (var book in books)
            {
                bookViewModels.Add(_map.ToDTO(book));
            }
            return Ok(bookViewModels);
        }
    }
}
