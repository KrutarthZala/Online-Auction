namespace OnlineAuction.Areas.PRO_Product.Models
{
    public class PRO_ProductModel
    {
        public int? ProductID { get; set; }

        public string? ProductName { get; set; }

        public IFormFile? File { get; set; }

        public string? ProductImage { get; set; }

        public string? ProductDetails { get; set; }

        public decimal? ProductPrice { get; set; }

        public string ProductStatus { get; set; }   

        public int CategoryID { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }
    }
}
