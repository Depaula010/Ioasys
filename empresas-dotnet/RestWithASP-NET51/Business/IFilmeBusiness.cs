using RestWithASP_NET5.Model;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business
{
    public interface IFilmeBusiness
    {
        Filme Create(Filme book);
        Filme FindById(long id);
        List<Filme> FindAll();
        Filme Update(Filme book);
        void Delete(long id);
    }
}
