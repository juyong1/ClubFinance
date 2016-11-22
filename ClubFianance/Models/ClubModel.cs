using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubFinance.Models
{
    public class Club2
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Club Official Name")]
        public string Name { get; set; } 

        [Required]
        [Display(Name = "Club Nick Name")]
        public string NickName { get; set; }
        
    }

    public class Club2DbContext : DbContext
    {
        public Club2DbContext()
            : base("InternetProjectDatabaseConnection")
        {
        }

        public DbSet<Club2> Clubs { get; set; }

    }
}

