using System;
using System.Collections.Generic;
using DFO.Entities;
using System.Linq;
namespace DFO.Repository
{
    public class MemoryRepository<T> : IRepository<T> where T : Entity
    {
        private IList<T> EntitySet { get; set; }
        public MemoryRepository()
        {
            EntitySet = new List<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return EntitySet;
        }
        public bool Add(T entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
                return false;
            if (entity.Id == 0)
            {
                if (EntitySet.Count == 0)
                    entity.Id = 1;
                else
                    entity.Id = EntitySet.Max(e => e.Id) + 1;
            }
            EntitySet.Add(entity);
            return true;
        }
        public bool Update(T entity)
        {
            var item = GetById(entity.Id);
            if (item == null)
                return false;
            var index = EntitySet.IndexOf(item);
            EntitySet.RemoveAt(index);
            EntitySet.Insert(index, entity);
            return true;
        }
        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null)
                return false;
            EntitySet.Remove(item);
            return true;
        }
        public T GetById(int id)
        {
            return EntitySet.FirstOrDefault(e => e.Id == id);
        }
    }
}
