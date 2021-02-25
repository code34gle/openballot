using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class Role
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        [Required, StringLength(32)]
        public string RoleName { get; set;}

        public List<UserAccountRole> UserAccountRoles { get; set;}

        //--------------------------------------------------------
    }
}