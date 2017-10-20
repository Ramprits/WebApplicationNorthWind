using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNorthWind.SampleDb.SampleEntities
{
    public partial class Fruits
    {
        [Key]
        public Guid FruitId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }
        [MaxLength(500)]
        public string ImgPath { get; set; }
        [Column("CreatedDT", TypeName = "date")]
        public DateTime CreatedDt { get; set; }
    }
}
