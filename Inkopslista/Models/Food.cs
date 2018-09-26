using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inkopslista.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name:")]
        public string Name { get; set; }
        public int? Category1 { get; set; }
        public int? Category2 { get; set; }
        public int? Category3 { get; set; }
        [Display(Name = "Alkohol (g):")]
        public float? Alkohol { get; set; } //(g) 
        [Display(Name = "Arakidinsyra C20:0 (g):")]
        public float? Arakidinsyra { get; set; } //(g) 
        [Display(Name = "")]
        public float? Arakidonsyra { get; set; } //(g) 
        [Display(Name = "")]
        public float? Aska { get; set; } //(g)    
        [Display(Name = "")]
        public float? Avfall { get; set; } //(%)    
        [Display(Name = "")]
        public float? DHA { get; set; } //  //(g) 
        [Display(Name = "")]
        public float? Disackarider { get; set; } //(g)    
        [Display(Name = "")]
        public float? DPA { get; set; } //(g) 
        [Display(Name = "")]
        public float? EnergiKJ { get; set; } //(kJ) 
        [Display(Name = "")]
        public float? EnergiKcal { get; set; } //kcal
        [Display(Name = "")]
        public float? EPA { get; set; }  //g) 
        [Display(Name = "")]
        public float? Fett { get; set; } //(g)    
        [Display(Name = "")]
        public float? Fettsyra { get; set; } //(g) 
        [Display(Name = "")]
        public float? Fibrer { get; set; } //(g)  
        [Display(Name = "")]
        public float? Folat { get; set; } //µg)  
        [Display(Name = "")]
        public float? Fosfor { get; set; } //mg)
        [Display(Name = "")]
        public float? FullkornTotalt { get; set; } //(g) 
        [Display(Name = "")]
        public float? Jod { get; set; } //µg)    
        [Display(Name = "")]
        public float? Jarn { get; set; } //mg)   
        [Display(Name = "")]
        public float? Kalcium { get; set; } //mg)    
        [Display(Name = "")]
        public float? Kalium { get; set; } //mg) 
        [Display(Name = "")]
        public float? Karoten { get; set; } //µg)  
        [Display(Name = "")]
        public float? Kolesterol { get; set; } //mg) 
        [Display(Name = "")]
        public float? Kolhydrater { get; set; } //(g) 
        [Display(Name = "")]
        public float? Koppar { get; set; } //mg) 
        [Display(Name = "")]
        public float? Laurinsyra { get; set; } //(g) 
        [Display(Name = "")]
        public float? Linolensyra { get; set; } //(g) 
        [Display(Name = "")]
        public float? Linolsyra { get; set; } //(g) 
        [Display(Name = "")]
        public float? Magnesium { get; set; } //mg)  
        [Display(Name = "")]
        public float? Monosackarider { get; set; } //(g)  
        [Display(Name = "")]
        public float? Myristinsyra { get; set; } //(g)  
        [Display(Name = "")]
        public float? Natrium { get; set; } //mg)    
        [Display(Name = "")]
        public float? Niacin { get; set; } //mg) 
        [Display(Name = "")]
        public float? Niacinekvivalenter { get; set; } //mg) 
        [Display(Name = "")]
        public float? Oljesyra { get; set; } //(g) 
        [Display(Name = "")]
        public float? Palmitinsyra { get; set; } //(g) 
        [Display(Name = "")]
        public float? Palmitoljesyra { get; set; } //(g) 
        [Display(Name = "")]
        public float? Protein { get; set; } //(g) 
        [Display(Name = "")]
        public float? Retinol { get; set; } //µg)    
        [Display(Name = "")]
        public float? Riboflavin { get; set; } //mg) 
        [Display(Name = "")]
        public float? Sackaros { get; set; } //(g)    
        [Display(Name = "")]
        public float? Salt { get; set; } //(g)    
        [Display(Name = "")]
        public float? Selen { get; set; } //µg)  
        [Display(Name = "")]
        public float? Sockerarter { get; set; } //(g) 
        [Display(Name = "")]
        public float? Stearinsyra { get; set; } //(g) 
        [Display(Name = "")]
        public float? Starkelse { get; set; } //(g)
        [Display(Name = "")]
        public float? SummaEnkelOmattadeFettsyror { get; set; } //(g)   
        [Display(Name = "")]
        public float? SummaFleromattadeFettsyror { get; set; } //(g)    
        [Display(Name = "")]
        public float? SummaMattadeFettsyror { get; set; } //(g) 
        [Display(Name = "")]
        public float? Tiamin { get; set; } //mg) 
        [Display(Name = "")]
        public float? Vatten { get; set; } //(g)  
        [Display(Name = "")]
        public float? VitaminA { get; set; } //µg)  
        [Display(Name = "")]
        public float? VitaminB6 { get; set; } //mg) 
        [Display(Name = "")]
        public float? VitaminB12 { get; set; } //µg)    
        [Display(Name = "")]
        public float? VitaminC { get; set; } //mg)  
        [Display(Name = "")]
        public float? VitaminD { get; set; } //µg)  
        [Display(Name = "")]
        public float? VitaminE { get; set; } //mg)  
        [Display(Name = "")]
        public float? VitaminK { get; set; } //µg)  
        [Display(Name = "")]
        public float? Zink { get; set; } //µg)  
    }
}