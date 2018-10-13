// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-13-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-13-2018
// ***********************************************************************
// <copyright file="Service.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kalori.Interfaces;
using Kalori.Models;
using Kalori.UoW;

namespace Kalori.Services
{
    /// <summary>
    /// Service Layer is a design pattern, applied within the
    /// service-orientation design paradigm, which aims to organize
    /// the services, within a service inventory, into a set of logical layers. 
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public class Service<TEntity>
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        protected readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity}"/> class.
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public Service()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity}"/> class.
        /// Injects a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
        }
        /// <summary>
        /// Saves changes to the DbContext
        /// </summary>
        public void Complete()
        {
            _unitOfWork.Complete();
        }
    }
}