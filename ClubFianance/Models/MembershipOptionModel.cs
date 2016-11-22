using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ClubFinance.Models
{
    public class MembershipOption2
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ClubId { get; set; }

        [Required]
        [Display(Name = "Membership Option")]
        [EnumDataType(typeof(EnumOption))]
        [Column(TypeName = "int")]
        public EnumOption Option { get; set; }

        [Display(Name = "Option Name")]
        public string OtherName { get; set; }

        [Required]
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime Expiration { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public Decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }

    public enum EnumOption
    {
        [Display(Name = "1-year Membership")]
        OneYear = 1,

        [Display(Name = "2-year Membership")]
        TwoYear = 2,

        [Display(Name = "3-year Membership")]
        ThreeYear = 3,

        [Display(Name = "Other Membership")]
        Other = 4,
    }

    public class MembershipOption2DbContext : DbContext
    {
        public MembershipOption2DbContext()
            //: base("DefaultConnection")
            : base("InternetProjectDatabaseConnection")

        {
        }

        public DbSet<MembershipOption2> MembershipOptions { get; set; }

    }

    public class MembershipOption2WithClub2
    {
        public MembershipOption2 MembershipOption2 { get; set; }
        public Club2 Club2 { get; set; }
    }
}
    