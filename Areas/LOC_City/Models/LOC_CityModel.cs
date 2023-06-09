using System.ComponentModel.DataAnnotations;

namespace OnlineAuction.Areas.LOC_City.Models
{
    public class LOC_CityModel
    {
        public int? CityID { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        [StringLength(50, MinimumLength = 3)]
        public string? CityName { get; set; }

        [Required(ErrorMessage = "Please Select Any Country")]
        public int? CountryID { get; set; }

        [Required(ErrorMessage = "Please Select Any State")]
        public int? StateID { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
