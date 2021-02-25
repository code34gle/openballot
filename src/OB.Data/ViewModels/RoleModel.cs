using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Models
{
    public class RoleModel
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        [Required, StringLength(32)]
        public string RoleName { get; set;}

        public List<UserAccountRoleModel> UserAccountRoles { get; set;}

        //--------------------------------------------------------
    }
}