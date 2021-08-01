using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Covid.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace Covid.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public IList<ApplicationUsercity> ApplicationUsercity { get; set; }
        public IList<ApplicationUsersymptom> ApplicationUsersymptom { get; set; }
        public virtual ICollection<avilable_leds> avilable_leds { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string cityname { get; set; }
        [Required]
        public string UserType { get; set; }
        public bool IsEmailVerified { get; set; }
        public string ResetPasswordCode { get; set; }
        public System.Guid? ActivationCode { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<city> city { get; set; }
        public System.Data.Entity.DbSet<ApplicationUsercity> ApplicationUsercity { get; set; }
        public System.Data.Entity.DbSet<ApplicationUsersymptom> ApplicationUsersymptom { get; set; }
        public System.Data.Entity.DbSet<symptom> symptom { get; set; }
        public System.Data.Entity.DbSet<advice> advice { get; set; }
        public System.Data.Entity.DbSet<result> result { get; set; }
        public System.Data.Entity.DbSet<avilable_leds> avilable_leds { get; set; }
        public System.Data.Entity.DbSet<item> item { get; set; }

    }
}