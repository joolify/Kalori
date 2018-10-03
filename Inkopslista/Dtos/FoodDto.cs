using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inkopslista.Models
{
    public class FoodDto

    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Category1 { get; set; }
    }
}