using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class UserAccountModel
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        [Required, StringLength(32)]
        public string Username { get; set;}

        [Required, StringLength(128)]
        public string Password { get; set;}

        [Required, StringLength(128)]
        public string EmailAddress { get; set;}

        public int LoginCount { get; set;}

        public DateTime LastLogin { get; set;}

        [Required]
        public DateTime DateCreated { get; set;}

        public DateTime DateUpdated { get; set;}

        [StringLength(32)]
        public string UpdatedBy { get; set;}

        public List<UserAccountRole> UserAccountRoles { get; set;}

        //--------------------------------------------------------
    }
}