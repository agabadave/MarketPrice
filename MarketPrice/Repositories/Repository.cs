using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MarketPrice.Models;
using DbContext = MarketPrice.Models.DbContext;

namespace MarketPrice.Repositories
{
    public class Repository : IRepository
    {
        private readonly DbContext _dbContext;

        public Repository()
        {
            _dbContext = new DbContext();
            
        }
        
        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Get<T>(int id) where T : class
        {
            return _dbContext.Set<T>().Find(id);
        }

        public bool Delete<T>(T entity) where T : class
        {
            var isSaved = true;
            using (var txn = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Set<T>().Remove(entity);
                    _dbContext.SaveChanges();

                    txn.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    txn.Rollback();
                    isSaved = false;
                }

            }
            return isSaved;
        }

        public bool SaveOrUpdate<T>(T entity, int id) where T : class 
        {

            try
            {
                if (id <= 0) //we are updating
                    _dbContext.Set<T>().Add(entity);
                else 
                    _dbContext.Entry(entity).State = EntityState.Modified;
                
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public int Count<T>(int id) where T : BaseEntity
        {
            return _dbContext.Set<T>().Count(x => x.Id == id);
        }

        public Vendor GetVendor(string username, string password)
        {
            return _dbContext.Vendors.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}