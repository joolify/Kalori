// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-08-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-08-2018
// ***********************************************************************
// <copyright file="MembershipType.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kalori.Models
{
    /// <summary>
    /// Class MembershipType.
    /// </summary>
    public class MembershipType
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public byte Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the signup fee.
        /// </summary>
        /// <value>The signup fee.</value>
        public int SignupFee { get; set; }
        /// <summary>
        /// Gets or sets the duration in months.
        /// </summary>
        /// <value>The duration in months.</value>
        public int DurationInMonths { get; set; }
        /// <summary>
        /// Gets or sets the discount rate.
        /// </summary>
        /// <value>The discount rate.</value>
        public int DiscountRate { get; set; }

        /// <summary>
        /// The unknown
        /// </summary>
        public static readonly byte Unknown = 0;
        /// <summary>
        /// The pay as you go
        /// </summary>
        public static readonly byte PayAsYouGo = 1;

    }
}