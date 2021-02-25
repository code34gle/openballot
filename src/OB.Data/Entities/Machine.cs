using System;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class Machine
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(64)]
        public int MAC_Address { get; set; }

        [Required, StringLength(32)]
        public int IP_Address { get; set; }

        [Required, StringLength(16)]
        public string District { get; set; }

        [Required, StringLength(16)]
        public string Precinct { get; set; }

        [Required, StringLength(16)]
        public string Status { get; set; }


        public bool IsActive { get; set; }


        // ----------------------------------------------  audit

        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public DateTime DateValidated { get; set; }

    }
}
