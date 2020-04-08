using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wimbee_Hiring.Persistence;
using Wimbee_Hiring.Service.Interfaces;

namespace Wimbee_Hiring.Service
{
    public class GenericRepository<T> :  IGenericRepository<T> where T : class
    {
        private CodingBlastDdContext context ;
        private DbSet<T> Table;

        public GenericRepository(CodingBlastDdContext _context)
        {
            context = _context;
            Table =context.Set<T>();
        }
        
        public void Delete(int objectId)
        {
            T exists = Table.Find(objectId);
            Table.Remove(exists);
             
        }

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(int objectId)
        {
            return Table.Find(objectId);
        }

        public void Insert(T Object)
        {
            Table.Add(Object);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T Object)
        {
            Table.Attach(Object);
            context.Entry(Object).State = EntityState.Modified;
        }
    }
}
