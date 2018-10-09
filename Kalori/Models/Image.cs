using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kalori.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }

    }
}