using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inkopslista.Models
{
    public class Instruction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int RecipeId { get; set; }
    }
}