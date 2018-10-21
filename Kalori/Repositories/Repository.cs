// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-11-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-14-2018
// ***********************************************************************
// <copyright file="Repository.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AutoMapper.Internal;
using Kalori.Interfaces;

namespace Kalori.Repositories
{
    /// <summary>
    /// Class Repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Kalori.Interfaces.IRepository{TEntity}" />
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The context
        /// </summary>
        protected readonly DbContext _context;
        /// <summary>
        /// The entities
        /// </summary>
        private DbSet<TEntity> _entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        /// <summary>
        /// Returns a TE
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        /// <summary>
        /// Gets all TEs
        /// </summary>
        /// <returns>IEnumerable&lt;TEntity&gt;.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IEnumerable&lt;TEntity&gt;.</returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        /// <summary>
        /// Checks if the entity exists.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        public bool Exists<TEntity>(TEntity entity) where TEntity : class
        {
            return _entities.Local.Any(e => e == entity);
        }

        /// <summary>
        /// Single or default.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>TEntity.</returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        /// <summary>
        /// Adds or updates the entity
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if added, <c>false</c> otherwise.</returns>
        public bool AddOrUpdate(TEntity entity)
        {
            _entities.AddOrUpdate(entity);
            return Exists(entity);
        }

        /// <summary>
        /// Adds a list of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if removed, <c>false</c> otherwise.</returns>
        public bool Remove(TEntity entity)
        {
            _entities.Remove(entity);
            return !Exists(entity);
        }

        /// <summary>
        /// Removes a list of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if removed, <c>false</c> otherwise.</returns>
        public bool RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
            foreach (var entity in entities)
            {
                if (Exists(entity))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Attach(TEntity entity)
        {
            if (!_entities.Local.Contains(entity))
                _entities.Attach(entity);
        }
        /// <summary>
        /// Attaches a list of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void AttachRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (!_entities.Local.Contains(entity))
                    _context.Set<TEntity>().Attach(entity);
            }
        }

        /// <summary>
        /// Sets the temporary object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetCache(String key, object value)
        {
            System.Web.Helpers.WebCache.Set(key, value);
        }
        /// <summary>
        /// Gets the temporary object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>object.</returns>
        public object GetCache(String key)
        {
            return System.Web.Helpers.WebCache.Get(key);
        }
    }
}