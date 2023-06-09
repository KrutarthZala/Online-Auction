using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineAuction.Areas.LOC_Country.Models
{
    public class LOC_CountryModel
    {
        public int? CountryID { get; set; }

        [Required]
        [DisplayName("Country Name")]
        [StringLength(50, MinimumLength = 3)]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Please Enter Country Code")]
        [StringLength(10, MinimumLength = 2)]
        public string CountryCode { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }
    }

    public class LOC_CountryDropDownModel
    {
        public int? CountryID { get; set; }

        [Required(ErrorMessage = "Please select country name.")]
        public string? CountryName { get; set; }
    }
}
