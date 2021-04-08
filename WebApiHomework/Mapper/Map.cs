using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiHomework.DataAccessLayer.Models;
using WebApiHomework.Models.BookViewModels;

namespace WebApiHomework.Mapper
{
    public class Map : IMap
    {
        public BookViewModel ToDTO(BookEntity bookEntity)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BookEntity, BookViewModel>();
            });
            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<BookEntity, BookViewModel>(bookEntity);
        }

        public BookEntity ToEntity(BookViewModel bookViewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BookViewModel, BookEntity>();
            });
            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<BookViewModel, BookEntity>(bookViewModel);
        }
    }
}
