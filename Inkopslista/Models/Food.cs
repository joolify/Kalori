using System.ComponentModel.DataAnnotations;

namespace Inkopslista.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Category1 { get; set; }
        public int? Category2 { get; set; }
        public int? Category3 { get; set; }
        public float Alkohol { get; set; } //(g) 
        public float ArakidinsyraC20 { get; set; } //(g) 
        public float ArakidonsyraC20 { get; set; } //(g) 
        public float Aska { get; set; } //(g)    
        public float Avfall { get; set; } //(%)    
        public float DHA { get; set; } //  //(g) 
        public float Disackarider { get; set; } //(g)    
        public float DPA { get; set; } //(g) 
        public float EnergiKJ { get; set; } //(kJ) 
        public float EnergiKcal { get; set; } //kcal
        public float EPA { get; set; }  //g) 
        public float Fett { get; set; } //(g)    
        public float Fettsyra4_10 { get; set; } //(g) 
        public float Fibrer { get; set; } //(g)  
        public float Folat { get; set; } //µg)  
        public float Fosfor { get; set; } //mg)
        public float FullkornTotalt { get; set; } //(g) 
        public float Jod { get; set; } //µg)    
        public float Jarn { get; set; } //mg)   
        public float Kalcium { get; set; } //mg)    
        public float Kalium { get; set; } //mg) 
        public float Karoten { get; set; } //µg)  
        public float Kolesterol { get; set; } //mg) 
        public float Kolhydrater { get; set; } //(g) 
        public float Koppar { get; set; } //mg) 
        public float LaurinsyraC12 { get; set; } //(g) 
        public float LinolensyraC18 { get; set; } //(g) 
        public float LinolsyraC18 { get; set; } //(g) 
        public float Magnesium { get; set; } //mg)  
        public float Monosackarider { get; set; } //(g)  
        public float Myristinsyra { get; set; } //(g)  
        public float Natrium { get; set; } //mg)    
        public float Niacin { get; set; } //mg) 
        public float Niacinekvivalenter { get; set; } //mg) 
        public float OljesyraC18 { get; set; } //(g) 
        public float PalmitinsyraC16 { get; set; } //(g) 
        public float Palmitoljesyra_C16 { get; set; } //(g) 
        public float Protein { get; set; } //(g) 
        public float Retinol { get; set; } //µg)    
        public float Riboflavin { get; set; } //mg) 
        public float Sackaros { get; set; } //(g)    
        public float Salt { get; set; } //(g)    
        public float Selen { get; set; } //µg)  
        public float Sockerarter { get; set; } //(g) 
        public float StearinsyraC18 { get; set; } //(g) 
        public float Starkelse { get; set; } //(g)
        public float SummaEnkelOmattadeFettsyror { get; set; } //(g)   
        public float SummaFleromattadeFettsyror { get; set; } //(g)    
        public float SummaMattadeFettsyror { get; set; } //(g) 
        public float Tiamin { get; set; } //mg) 
        public float Vatten { get; set; } //(g)  
        public float VitaminA { get; set; } //µg)  
        public float VitaminB6 { get; set; } //mg) 
        public float VitaminB12 { get; set; } //µg)    
        public float VitaminC { get; set; } //mg)  
        public float VitaminD { get; set; } //µg)  
        public float VitaminE { get; set; } //mg)  
        public float VitaminK { get; set; } //µg)  
        public float Zink { get; set; } //µg)  
    }
}