using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Inkopslista.Models;

namespace Inkopslista.Dtos
{
    public class MovieDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int GenreTypeId { get; set; }
        public GenreType GenreType { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }
    }
}