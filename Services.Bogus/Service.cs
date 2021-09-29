using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Models;
using Services.Bogus.Fakers;

namespace Services.Bogus
{
    public class Service<T> : IService<T> where T : Entity
    {
        private ICollection<T> _entities;

        public Service(EntityFaker<T> faker, int count)
        {
            _entities = faker.Generate(count);
        }

        public int Create(T entity)
        {
            entity.Id = _entities.Max(x => x.Id) + 1;
            _entities.Add(entity);
            return entity.Id;
        }

        public void Delete(int id)
        {
            _entities.Remove(Read(id));
        }

        public IEnumerable<T> Read()
        {
            return _entities.ToList();
        }

        public T Read(int id)
        {
            return _entities.SingleOrDefault(x => x.Id == id);
        }

        public void Update(int id, T entity)
        {
            var dbEntity = Read(id);
            entity.Id = dbEntity.Id;
            _entities.Remove(dbEntity);
            _entities.Add(entity);
        }
    }
}
