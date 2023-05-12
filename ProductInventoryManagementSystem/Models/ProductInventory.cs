namespace ProductInventoryManagementSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductInventory
    {
        [Key]
        [Column("pkProductID")]
        public int ProductID { get; set; }

        [Column("Make")]
        public string Make { get; set; }

        [Column("Model")]
        public string Model { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Type")]
        public string Type { get; set; }

        [Column("Price")]
        public double? Price { get; set; }

        [Column("Quantity")]
        public int? Quantity { get; set; }
    }
}
