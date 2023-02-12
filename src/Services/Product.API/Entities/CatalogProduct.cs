using Contracts.Domains.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.API.Entities
{
    public class CatalogProduct : EntityAuditBase<long>
    {
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string No { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Summary { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }
        // Số lượng tồn kho của sản phẩm
        // Bản thân Product ko tính tồn kho mà do Inventory service sẽ làm rồi tự động update cho Product
        //public int StockQuantity { get; set; }
    }
}
