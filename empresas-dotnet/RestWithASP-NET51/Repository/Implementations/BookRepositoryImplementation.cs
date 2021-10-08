using RestWithASP_NET5.Model;
using RestWithASP_NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASP_NET5.Repository;

namespace RestWithASP_NET5.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Filme Create(Filme book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Filmes.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Filmes.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public List<Filme> FindAll()
        {
            return _context.Filmes.ToList();
        }

        public Filme FindById(long id)
        {
            return _context.Filmes.SingleOrDefault(p => p.Id.Equals(id));

        }

        public Filme Update(Filme book)
        {
            if (!Exists(book.Id)) 
                return null;

            var result = _context.Filmes.SingleOrDefault(p => p.Id.Equals(book.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return book;
        }

        public bool Exists(long id)
        {
            return _context.Filmes.Any(p => p.Id.Equals(id));
        }
    }
}
