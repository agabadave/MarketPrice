using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPrice.Models;

namespace MarketPrice.Repositories
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : class;

        T Get<T>(int id) where T : class;

        bool Delete<T>(T entity) where T : class;
        
        bool SaveOrUpdate<T>(T entity, int id) where T : class;

        int Count<T>(int id) where T : BaseEntity;

        Vendor GetVendor(string username, string password);
    }
}
