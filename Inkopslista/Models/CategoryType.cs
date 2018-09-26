using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inkopslista.Models
{
    public class CategoryType
    {
        [Key]
        public int Id { get; set; }
        public byte Category { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
