using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class UserAccountRoleModel
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        public int UserAccountId { get; set;}

        public int RoleId { get; set;}

        public UserAccount UserAccount { get; set;}

        public Role Role { get; set;}

        //--------------------------------------------------------
    }
}