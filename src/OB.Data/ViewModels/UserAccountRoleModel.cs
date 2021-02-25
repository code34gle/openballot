using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Models
{
    public class UserAccountRoleModel
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        public int UserAccountId { get; set;}

        public int RoleId { get; set;}

        public UserAccountModel UserAccount { get; set;}

        public RoleModel Role { get; set;}

        //--------------------------------------------------------
    }
}