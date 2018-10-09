using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalori.Models
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

        public Food()
        {
            Alkohol = 0;
            Arakidinsyra = 0;
            Arakidonsyra = 0;
            Aska = 0;
            Avfall = 0;
            DHA = 0;
            Disackarider = 0;
            DPA = 0;
            EnergiKJ = 0;
            EnergiKcal = 0;
            EPA = 0;
            Fett = 0;
            Fettsyra = 0;
            Fibrer = 0;
            Folat = 0;
            FullkornTotalt = 0;
            Jod = 0;
            Jarn = 0;
            Kalcium = 0;
            Kalium = 0;
            Karoten = 0;
            Kolesterol = 0;
            Kolhydrater = 0;
            Koppar = 0;
            Laurinsyra = 0;
            Linolensyra = 0;
            Linolsyra = 0;
            Magnesium = 0;
            Monosackarider = 0;
            Myristinsyra = 0;
            Natrium = 0;
            Niacin = 0;
            Niacinekvivalenter = 0;
            Oljesyra = 0;
            Palmitinsyra = 0;
            Palmitoljesyra = 0;
            Protein = 0;
            Retinol = 0;
            Riboflavin = 0;
            Sackaros = 0;
            Salt = 0;
            Selen = 0;
            Sockerarter = 0;
            Stearinsyra = 0;
            Starkelse = 0;
            SummaEnkelOmattadeFettsyror = 0;
            SummaFleromattadeFettsyror = 0;
            SummaMattadeFettsyror = 0;
            Tiamin = 0;
            Vatten = 0;
            VitaminA = 0;
            VitaminB6 = 0;
            VitaminB12 = 0;
            VitaminC = 0;
            VitaminD = 0;
            VitaminE = 0;
            VitaminK = 0;
            Zink = 0;
        }
    }
}