using RestWithASP_NET5.Model;
using RestWithASP_NET5.Repository;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business.Implementations
{
    public class BookBusinessImplementation : IFilmeBusiness
    {
        private readonly IRepository<Filme> _repository;

        public BookBusinessImplementation(IRepository<Filme> repository)
        {
            _repository = repository;
        }

        public Filme Create(Filme book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Filme> FindAll()
        {
            return _repository.FindAll();
        }

        public Filme FindById(long id)
        {
            return _repository.FindById(id);

        }

        public Filme Update(Filme book)
        {
            return _repository.Update(book);
        }

    }
}
