namespace ProductInventoryManagementSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductInventory
    {
        [Key]
        [Column("pkProductID")]
        public int ProductID { get; set; }

        [Column("ProductName")]
        public string ProductName { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Type")]
        public string Type { get; set; }

        [Column("Price")]
        public float Price { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }
    }
}
