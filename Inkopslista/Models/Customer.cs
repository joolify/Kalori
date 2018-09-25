using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inkopslista.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [ForeignKey("MembershipType")]
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }


        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}