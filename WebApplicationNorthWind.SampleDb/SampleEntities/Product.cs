using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNorthWind.SampleDb.SampleEntities
{
    public partial class Product
    {
        public Product()
        {
            ProductDescription = new HashSet<ProductDescription>();
        }

        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        public string ProductNumber { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<ProductDescription> ProductDescription { get; set; }
    }
}
