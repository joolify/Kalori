using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kalori.Dtos
{
    public class CategoryTypeDto
    {
        [Key]
        public int Id { get; set; }
        public byte Category { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }

}