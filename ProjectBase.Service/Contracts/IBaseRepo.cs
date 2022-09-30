using ProjectBase.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBase.Service.Contracts
{
    public interface IBaseRepo<T> where T : class
    {
        Task<Response<ICollection<T>>> GetAll();
        Task<Response<T>> GetById(Guid id);
        Task<Response<T>> Create(T entity);
        Task<Response<T>> Update(T entity);
        Task<Response<T>> Delete(Guid id);
        Task<Response<T>> SoftDelete(Guid id);
        //void Save();

        //Task<int> SaveChangesAsync();
    }
}
