using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inkopslista.Models
{
    public class MembershipType
    {

        [Key]
        public byte Id { get; set; }
        public string Name { get; set; }
        public int SignupFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }
    }
}