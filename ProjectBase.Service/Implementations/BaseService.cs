using Microsoft.EntityFrameworkCore;
using ProjectBase.Domain.Common;
using ProjectBase.Persistence;
using ProjectBase.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBase.Service.Implementations
{
    public class BaseService<T> : IBaseRepo<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public BaseService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Response<T>> Create(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
                return new Response<T>(entity, "Record created successfully.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<T>> Delete(Guid id)
        {
            try
            {
                var entity = await GetById(id);
                entity.Message = "Record deleted successfully.";
                if (entity == null) throw new Exception("The entity is null");
                context.Set<T>().Remove(entity.Data);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<ICollection<T>>> GetAll()
        {
            try
            {
                var records = await context.Set<T>().ToListAsync();
                return new Response<ICollection<T>>(records, "Record list requested successfully.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<T>> GetById(Guid id)
        {
            try
            {
                var record = await context.Set<T>().SingleOrDefault(id);
                if (record is null) throw new Exception("Record does not exist.");
                return new Response<T>(record, "Record requested successfully.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<T>> SoftDelete(Guid id)
        {
            try
            {
                var entity = await GetById(id);
                entity.Message = "Record soft deleted successfully.";
                if (entity == null) throw new Exception("The entity is null");
                var isActiveProp = entity.GetType().GetProperty("IsActive");
                var isActivePropWithRightType = Convert.ChangeType(false, isActiveProp.PropertyType);
                isActiveProp.SetValue(entity, isActivePropWithRightType);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<T>> Update(T entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return new Response<T>(entity, "Record updated successfully.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public void Save()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<int> SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
