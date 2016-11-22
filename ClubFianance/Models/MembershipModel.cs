using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubFinance.Models
{
    public class Membership3
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ClubId { get; set; }

        [Required]
        [Display(Name = "Membership Option")]
        [EnumDataType(typeof(EnumOption))]
        [Column(TypeName = "int")]
        public EnumOption Option { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public bool IsMember { get; set; }

        [DataType(DataType.Date)]
        public DateTime UnregistrationDate { get; set; }
 }

    public class Membership3DbContext : DbContext
    {
        public Membership3DbContext()
            : base("InternetProjectDatabaseConnection")

        {
        }

        public DbSet<Membership3> Memberships { get; set; }
   
    }
}
