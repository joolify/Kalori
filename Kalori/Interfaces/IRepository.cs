// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-11-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="IRepository.cs" company="joolify">
//     Copyright © joolify. 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Kalori.Interfaces
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Returns a TE
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        TEntity Get(int id);
        /// <summary>
        /// Gets all TEs
        /// </summary>
        /// <returns>IEnumerable&lt;TEntity&gt;.</returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IEnumerable&lt;TEntity&gt;.</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Checks if the entity exists.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        bool Exists<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Single or default.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>TEntity.</returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adds or updates the entity
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if added, <c>false</c> otherwise.</returns>
        bool AddOrUpdate(TEntity entity);
        /// <summary>
        /// Adds a list of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AddRange(IEnumerable<TEntity> entities);


        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if removed, <c>false</c> otherwise.</returns>
        bool Remove(TEntity entity);

        /// <summary>
        /// Removes a list of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        bool RemoveRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Attach(TEntity entity);
        /// <summary>
        /// Attaches a list of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AttachRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// Sets the temporary object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void SetTempObj(String key, object value);
        /// <summary>
        /// Gets the temporary object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>object.</returns>
        object GetTempObj(String key);

    }
}