using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNorthWind.SampleDb.SampleEntities
{
    public partial class ProductDescription
    {
        public int ProductDescriptionId { get; set; }
        [Required]
        [MaxLength(400)]
        public string Description { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("ProductDescription")]
        public virtual Product Product { get; set; }
    }
}
