using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RestWithASPNETUdemy.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
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

        protected IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where);
        }


        public TEntity FindById(long id)
        {
             return DbSet.Find(id);
        }

        public TEntity Update(TEntity model)
        {
            if(FindById((long)model.Id) == null) return null; 
            var entry = _context.Entry(model);
            DbSet.Attach(model);
            entry.State = EntityState.Modified;
            _context.SaveChanges();

            return model;
        }

        protected List<TEntity> ExecuteQuery(string query)
        {
            return DbSet.FromSql<TEntity>(query).ToList();
        }
    }
}
