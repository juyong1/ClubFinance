using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClubFinance.Models
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        public int ClubId { get; set; }

        [Required]
        [Display(Name = "Membership Option")]
        [EnumDataType(typeof(EnumOption2))]
        public EnumOption2 Option { get; set; }

        [Display(Name = "Specify Option Name")]
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

        public bool IsActive { get; set; }
    }

    public enum EnumOption2
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
    public class TestDbContext : DbContext
    {
        public TestDbContext()
            //: base("DefaultConnection")
            : base("InternetProjectDatabaseConnection")

        {
        }

        public DbSet<Test> Tests { get; set; }

    }
}