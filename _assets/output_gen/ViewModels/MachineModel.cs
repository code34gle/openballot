using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class MachineModel
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        [Required, StringLength(64)]
        public string MAC_Address { get; set;}

        [Required, StringLength(32)]
        public string IP_Address { get; set;}

        [Required, StringLength(16)]
        public string District { get; set;}

        [Required, StringLength(16)]
        public string Precinct { get; set;}

        [Required, StringLength(16)]
        public string Status { get; set;}

        [Required, StringLength(16)]
        public string IsActive { get; set;}

        public DateTime DateUpdated { get; set;}

        public string UpdatedBy { get; set;}

        //--------------------------------------------------------
    }
}