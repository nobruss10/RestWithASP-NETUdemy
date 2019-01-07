using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MySqlContext _context;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(MySqlContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public TEntity Create(TEntity model)
        {
            try
            {
                DbSet.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return model;
        }

        public void Delete(long id)
        {
            try
            {
                if (DbSet.Find(id) != null)
                {
                    DbSet.Remove(DbSet.Find(id));
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TEntity> FindAll()
        {
            return DbSet.ToList();
        }

        public TEntity FindById(long id)
        {
             return DbSet.Find(id);
        }

        public TEntity Update(TEntity model)
        {
            var entry = _context.Entry(model);
            DbSet.Attach(model);
            entry.State = EntityState.Modified;
            _context.SaveChanges();

            return model;
        }
    }
}
