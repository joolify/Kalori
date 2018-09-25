﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inkopslista.Models
{
    public class GenreType
    {
        [Key]
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}