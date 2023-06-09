using Microsoft.Build.Framework;

namespace OnlineAuction.Areas.MST_Category.Models
{
    public class MST_CategoryModel
    {
        public int? CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public IFormFile? File { get; set; }

        public string? CategoryImage { get; set; }

        public string CategoryDetails { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }
    }

    public class MST_Category_DropDownModel
    {
        public int? CategoryID { get; set; }

        public string? CategoryName { get; set; }
    }
}
