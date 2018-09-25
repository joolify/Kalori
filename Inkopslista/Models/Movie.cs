using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inkopslista.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("GenreType")]
        public int GenreTypeId { get; set; }
        public GenreType GenreType { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }
    }
}