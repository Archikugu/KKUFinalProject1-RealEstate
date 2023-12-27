using E_State.Business.Abstract;
using E_State.DataAccess.Abstract;
using E_State.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_State.Business.Concrete
{
    public class ImagesManager : IImagesService
    {
        IImagesRepository _imagesRepository;

        public ImagesManager(IImagesRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }

        public void Add(Images item)
        {
            _imagesRepository.Add(item);
        }

        public void Delete(Images item)
        {
            _imagesRepository.Delete(item);
        }

        public Images GetById(int id)
        {
            return _imagesRepository.GetById(id);
        }

        public List<Images> List()
        {
            return _imagesRepository.List();
        }

        public List<Images> List(Expression<Func<Images, bool>> filter)
        {
            return _imagesRepository.List(filter);
        }

        public void Update(Images item)
        {
            _imagesRepository.Update(item);
        }
    }
}
