using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiHomework.DataAccessLayer.Models;
using WebApiHomework.Models.BookViewModels;

namespace WebApiHomework.Mapper
{
    public interface IMap
    {
        public BookViewModel ToDTO(BookEntity bookEntity);
        public BookEntity ToEntity(BookViewModel bookViewModel);
    }
}
