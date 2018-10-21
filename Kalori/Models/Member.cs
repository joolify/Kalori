// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-08-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-08-2018
// ***********************************************************************
// <copyright file="Member.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kalori.Models
{
    /// <summary>
    /// Class Member.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        [StringLength(255)]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is subscribed to news letter.
        /// </summary>
        /// <value><c>true</c> if this instance is subscribed to news letter; otherwise, <c>false</c>.</value>
        [Display(Name = "Med i nyhetsbrevet?")]
        public bool IsSubscribedToNewsLetter { get; set; }

        /// <summary>
        /// Gets or sets the membership type identifier.
        /// </summary>
        /// <value>The membership type identifier.</value>
        [ForeignKey("MembershipType")]
        [Display(Name = "Medlemstyp")]
        public byte MembershipTypeId { get; set; }
        /// <summary>
        /// Gets or sets the type of the membership.
        /// </summary>
        /// <value>The type of the membership.</value>
        [Display(Name = "Medlemstyp")]
        public MembershipType MembershipType { get; set; }


        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        [Display(Name = "Födelsedatum")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}