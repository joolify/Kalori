// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-08-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="Food.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalori.Models
{
    /// <summary>
    /// Class Food.
    /// </summary>
    public class Food
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Display(Name = "Name:")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the category1.
        /// </summary>
        /// <value>The category1.</value>
        public int? Category1 { get; set; }
        /// <summary>
        /// Gets or sets the category2.
        /// </summary>
        /// <value>The category2.</value>
        public int? Category2 { get; set; }
        /// <summary>
        /// Gets or sets the category3.
        /// </summary>
        /// <value>The category3.</value>
        public int? Category3 { get; set; }
        /// <summary>
        /// Gets or sets the alkohol.
        /// </summary>
        /// <value>The alkohol.</value>
        [Display(Name = "Alkohol (g):")]
        public float? Alkohol { get; set; }
        /// <summary>
        /// Gets or sets the arakidinsyra.
        /// </summary>
        /// <value>The arakidinsyra.</value>
        [Display(Name = "Arakidinsyra C20:0 (g):")]
        public float? Arakidinsyra { get; set; }
        /// <summary>
        /// Gets or sets the arakidonsyra.
        /// </summary>
        /// <value>The arakidonsyra.</value>
        [Display(Name = "")]
        public float? Arakidonsyra { get; set; }
        /// <summary>
        /// Gets or sets the aska.
        /// </summary>
        /// <value>The aska.</value>
        [Display(Name = "")]
        public float? Aska { get; set; }
        /// <summary>
        /// Gets or sets the avfall.
        /// </summary>
        /// <value>The avfall.</value>
        [Display(Name = "")]
        public float? Avfall { get; set; }
        /// <summary>
        /// Gets or sets the dha.
        /// </summary>
        /// <value>The dha.</value>
        [Display(Name = "")]
        public float? DHA { get; set; }
        /// <summary>
        /// Gets or sets the disackarider.
        /// </summary>
        /// <value>The disackarider.</value>
        [Display(Name = "")]
        public float? Disackarider { get; set; }
        /// <summary>
        /// Gets or sets the dpa.
        /// </summary>
        /// <value>The dpa.</value>
        [Display(Name = "")]
        public float? DPA { get; set; }
        /// <summary>
        /// Gets or sets the energi kj.
        /// </summary>
        /// <value>The energi kj.</value>
        [Display(Name = "")]
        public float? EnergiKJ { get; set; }
        /// <summary>
        /// Gets or sets the energi kcal.
        /// </summary>
        /// <value>The energi kcal.</value>
        [Display(Name = "")]
        public float? EnergiKcal { get; set; }
        /// <summary>
        /// Gets or sets the epa.
        /// </summary>
        /// <value>The epa.</value>
        [Display(Name = "")]
        public float? EPA { get; set; }
        /// <summary>
        /// Gets or sets the fett.
        /// </summary>
        /// <value>The fett.</value>
        [Display(Name = "")]
        public float? Fett { get; set; }
        /// <summary>
        /// Gets or sets the fettsyra.
        /// </summary>
        /// <value>The fettsyra.</value>
        [Display(Name = "")]
        public float? Fettsyra { get; set; }
        /// <summary>
        /// Gets or sets the fibrer.
        /// </summary>
        /// <value>The fibrer.</value>
        [Display(Name = "")]
        public float? Fibrer { get; set; }
        /// <summary>
        /// Gets or sets the folat.
        /// </summary>
        /// <value>The folat.</value>
        [Display(Name = "")]
        public float? Folat { get; set; }
        /// <summary>
        /// Gets or sets the fosfor.
        /// </summary>
        /// <value>The fosfor.</value>
        [Display(Name = "")]
        public float? Fosfor { get; set; }
        /// <summary>
        /// Gets or sets the fullkorn totalt.
        /// </summary>
        /// <value>The fullkorn totalt.</value>
        [Display(Name = "")]
        public float? FullkornTotalt { get; set; }
        /// <summary>
        /// Gets or sets the jod.
        /// </summary>
        /// <value>The jod.</value>
        [Display(Name = "")]
        public float? Jod { get; set; }
        /// <summary>
        /// Gets or sets the jarn.
        /// </summary>
        /// <value>The jarn.</value>
        [Display(Name = "")]
        public float? Jarn { get; set; }
        /// <summary>
        /// Gets or sets the kalcium.
        /// </summary>
        /// <value>The kalcium.</value>
        [Display(Name = "")]
        public float? Kalcium { get; set; }
        /// <summary>
        /// Gets or sets the kalium.
        /// </summary>
        /// <value>The kalium.</value>
        [Display(Name = "")]
        public float? Kalium { get; set; }
        /// <summary>
        /// Gets or sets the karoten.
        /// </summary>
        /// <value>The karoten.</value>
        [Display(Name = "")]
        public float? Karoten { get; set; }
        /// <summary>
        /// Gets or sets the kolesterol.
        /// </summary>
        /// <value>The kolesterol.</value>
        [Display(Name = "")]
        public float? Kolesterol { get; set; }
        /// <summary>
        /// Gets or sets the kolhydrater.
        /// </summary>
        /// <value>The kolhydrater.</value>
        [Display(Name = "")]
        public float? Kolhydrater { get; set; }
        /// <summary>
        /// Gets or sets the koppar.
        /// </summary>
        /// <value>The koppar.</value>
        [Display(Name = "")]
        public float? Koppar { get; set; }
        /// <summary>
        /// Gets or sets the laurinsyra.
        /// </summary>
        /// <value>The laurinsyra.</value>
        [Display(Name = "")]
        public float? Laurinsyra { get; set; }
        /// <summary>
        /// Gets or sets the linolensyra.
        /// </summary>
        /// <value>The linolensyra.</value>
        [Display(Name = "")]
        public float? Linolensyra { get; set; }
        /// <summary>
        /// Gets or sets the linolsyra.
        /// </summary>
        /// <value>The linolsyra.</value>
        [Display(Name = "")]
        public float? Linolsyra { get; set; }
        /// <summary>
        /// Gets or sets the magnesium.
        /// </summary>
        /// <value>The magnesium.</value>
        [Display(Name = "")]
        public float? Magnesium { get; set; }
        /// <summary>
        /// Gets or sets the monosackarider.
        /// </summary>
        /// <value>The monosackarider.</value>
        [Display(Name = "")]
        public float? Monosackarider { get; set; }
        /// <summary>
        /// Gets or sets the myristinsyra.
        /// </summary>
        /// <value>The myristinsyra.</value>
        [Display(Name = "")]
        public float? Myristinsyra { get; set; }
        /// <summary>
        /// Gets or sets the natrium.
        /// </summary>
        /// <value>The natrium.</value>
        [Display(Name = "")]
        public float? Natrium { get; set; }
        /// <summary>
        /// Gets or sets the niacin.
        /// </summary>
        /// <value>The niacin.</value>
        [Display(Name = "")]
        public float? Niacin { get; set; }
        /// <summary>
        /// Gets or sets the niacinekvivalenter.
        /// </summary>
        /// <value>The niacinekvivalenter.</value>
        [Display(Name = "")]
        public float? Niacinekvivalenter { get; set; }
        /// <summary>
        /// Gets or sets the oljesyra.
        /// </summary>
        /// <value>The oljesyra.</value>
        [Display(Name = "")]
        public float? Oljesyra { get; set; }
        /// <summary>
        /// Gets or sets the palmitinsyra.
        /// </summary>
        /// <value>The palmitinsyra.</value>
        [Display(Name = "")]
        public float? Palmitinsyra { get; set; }
        /// <summary>
        /// Gets or sets the palmitoljesyra.
        /// </summary>
        /// <value>The palmitoljesyra.</value>
        [Display(Name = "")]
        public float? Palmitoljesyra { get; set; }
        /// <summary>
        /// Gets or sets the protein.
        /// </summary>
        /// <value>The protein.</value>
        [Display(Name = "")]
        public float? Protein { get; set; }
        /// <summary>
        /// Gets or sets the retinol.
        /// </summary>
        /// <value>The retinol.</value>
        [Display(Name = "")]
        public float? Retinol { get; set; }
        /// <summary>
        /// Gets or sets the riboflavin.
        /// </summary>
        /// <value>The riboflavin.</value>
        [Display(Name = "")]
        public float? Riboflavin { get; set; }
        /// <summary>
        /// Gets or sets the sackaros.
        /// </summary>
        /// <value>The sackaros.</value>
        [Display(Name = "")]
        public float? Sackaros { get; set; }
        /// <summary>
        /// Gets or sets the salt.
        /// </summary>
        /// <value>The salt.</value>
        [Display(Name = "")]
        public float? Salt { get; set; }
        /// <summary>
        /// Gets or sets the selen.
        /// </summary>
        /// <value>The selen.</value>
        [Display(Name = "")]
        public float? Selen { get; set; }
        /// <summary>
        /// Gets or sets the sockerarter.
        /// </summary>
        /// <value>The sockerarter.</value>
        [Display(Name = "")]
        public float? Sockerarter { get; set; }
        /// <summary>
        /// Gets or sets the stearinsyra.
        /// </summary>
        /// <value>The stearinsyra.</value>
        [Display(Name = "")]
        public float? Stearinsyra { get; set; }
        /// <summary>
        /// Gets or sets the starkelse.
        /// </summary>
        /// <value>The starkelse.</value>
        [Display(Name = "")]
        public float? Starkelse { get; set; }
        /// <summary>
        /// Gets or sets the summa enkel omattade fettsyror.
        /// </summary>
        /// <value>The summa enkel omattade fettsyror.</value>
        [Display(Name = "")]
        public float? SummaEnkelOmattadeFettsyror { get; set; }
        /// <summary>
        /// Gets or sets the summa fleromattade fettsyror.
        /// </summary>
        /// <value>The summa fleromattade fettsyror.</value>
        [Display(Name = "")]
        public float? SummaFleromattadeFettsyror { get; set; }
        /// <summary>
        /// Gets or sets the summa mattade fettsyror.
        /// </summary>
        /// <value>The summa mattade fettsyror.</value>
        [Display(Name = "")]
        public float? SummaMattadeFettsyror { get; set; }
        /// <summary>
        /// Gets or sets the tiamin.
        /// </summary>
        /// <value>The tiamin.</value>
        [Display(Name = "")]
        public float? Tiamin { get; set; }
        /// <summary>
        /// Gets or sets the vatten.
        /// </summary>
        /// <value>The vatten.</value>
        [Display(Name = "")]
        public float? Vatten { get; set; }
        /// <summary>
        /// Gets or sets the vitamin a.
        /// </summary>
        /// <value>The vitamin a.</value>
        [Display(Name = "")]
        public float? VitaminA { get; set; }
        /// <summary>
        /// Gets or sets the vitamin b6.
        /// </summary>
        /// <value>The vitamin b6.</value>
        [Display(Name = "")]
        public float? VitaminB6 { get; set; }
        /// <summary>
        /// Gets or sets the vitamin B12.
        /// </summary>
        /// <value>The vitamin B12.</value>
        [Display(Name = "")]
        public float? VitaminB12 { get; set; }
        /// <summary>
        /// Gets or sets the vitamin c.
        /// </summary>
        /// <value>The vitamin c.</value>
        [Display(Name = "")]
        public float? VitaminC { get; set; }
        /// <summary>
        /// Gets or sets the vitamin d.
        /// </summary>
        /// <value>The vitamin d.</value>
        [Display(Name = "")]
        public float? VitaminD { get; set; }
        /// <summary>
        /// Gets or sets the vitamin e.
        /// </summary>
        /// <value>The vitamin e.</value>
        [Display(Name = "")]
        public float? VitaminE { get; set; }
        /// <summary>
        /// Gets or sets the vitamin k.
        /// </summary>
        /// <value>The vitamin k.</value>
        [Display(Name = "")]
        public float? VitaminK { get; set; }
        /// <summary>
        /// Gets or sets the zink.
        /// </summary>
        /// <value>The zink.</value>
        [Display(Name = "")]
        public float? Zink { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Food"/> class.
        /// </summary>
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