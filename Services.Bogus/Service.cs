using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Models;
using Services.Bogus.Fakers;
using Microsoft.Extensions.Logging;

namespace Services.Bogus
{
    public class Service<T> : IService<T> where T : Entity
    {
        private ICollection<T> _entities;
        private ILogger<Service<T>> _logger;

        public Service(EntityFaker<T> faker, ILogger<Service<T>> logger) : this(faker, logger, 10)
        {
        }
        public Service(EntityFaker<T> faker, ILogger<Service<T>> logger, int count)
        {
            _entities = faker.Generate(count);
            _logger = logger;
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
            _logger.LogInformation("Creating variable");
            IEnumerable<T> entities;
            using (_logger.BeginScope(nameof(Read)))
            {
                _logger.LogInformation("Entering scope");
                _logger.LogInformation("Reading all data..");
                entities = _entities.ToList();
                _logger.LogInformation("Exiting scope");
            }

            _logger.LogInformation("return result");
            return entities;
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
