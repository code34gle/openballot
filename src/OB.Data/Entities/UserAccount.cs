using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class UserAccount
    {
        // ----------------------------------------------  
        [Key]
        public int Id { get; set; }

        [StringLength(32)]
        public string Username { get; set; }

        [StringLength(128)]
        public string Password { get; set; }

        [StringLength(128)]
        public string EmailAddress { get; set; }

        public int LoginCount { get; set; }

        [Required]
        public DateTime LastLogin { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required, StringLength(32)]
        public DateTime CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [StringLength(32)]
        public DateTime UpdatedBy { get; set; }
        // ----------------------------------------------  
        public virtual List<UserAccountRole> UserAccountRoles { get; set; }

    }
}
