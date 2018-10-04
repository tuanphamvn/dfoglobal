using System;
using System.Collections.Generic;
using System.Text;
using DFO.Entities;
namespace DFO.Repository
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        T GetById(int id);
    }
}
