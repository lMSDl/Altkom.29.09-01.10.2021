using Models;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IService<T> where T : Entity
    {
        int Create(T entity);
        T Read(int id);
        IEnumerable<T> Read();
        void Update(int id, T entity);
        void Delete(int id);
    }
}
