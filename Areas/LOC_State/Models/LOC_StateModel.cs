using System.ComponentModel.DataAnnotations;

namespace OnlineAuction.Areas.LOC_State.Models
{
    public class LOC_StateModel
    {
        public int? StateID { get; set; }

        [Required(ErrorMessage = "Please Enter State Name")]
        [StringLength(50, MinimumLength = 2)]
        public string? StateName { get; set; }

        [Required(ErrorMessage = "Please Select Any Country")]
        public int? CountryID { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }

    public class LOC_StateDropDownModel
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
    }
}
