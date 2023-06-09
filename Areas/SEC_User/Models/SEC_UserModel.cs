namespace OnlineAuction.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {

        public int? UserID { get; set; }

        public string? UserName { get; set; }

        public string? UserPassword { get; set; }

        public decimal? UserMobileNo { get; set; }

        public string? UserEmail { get; set; }

        public string? UserAddress { get; set; }

        public int? CountryID { get; set; }
        public int? StateID { get; set; }
        public int? CityID { get; set; }

        public int? UserTypeID { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

    }
}
