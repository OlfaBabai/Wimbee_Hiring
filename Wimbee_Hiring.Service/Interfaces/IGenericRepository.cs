using System;
using System.Collections.Generic;
using System.Text;

namespace Wimbee_Hiring.Service.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int objectId);
        void Insert(T Object);
        void Delete(int objectId);
        void Update(T Object);
        

    }
}
