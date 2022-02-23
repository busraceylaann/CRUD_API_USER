using EntityLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(); //liste döncek
        Task<T> GetId(int Id); //id göre bulacak
        Task AddAsync(T obj); //ekleme
        T UpdateAsync(T obj); //guncelleme
        void DeleteAsync(T Id); //silme
    }
}
