using System;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class Registrant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EncKey { get; set; }                     // private "salt" for encrypting the signals

        [Required, StringLength(24)]
        public string Code { get; set; }                       // private identifier


        //  demographic

        [Required, StringLength(32)]
        public string FirstName { get; set; }

        [Required, StringLength(32)]
        public string LastName { get; set; }

        [StringLength(32)]
        public string MiddleName { get; set; }

        [StringLength(32)]
        public string Suffix { get; set; }


        //  validation

        [Required]
        public DateTime DOB { get; set; }

        [StringLength(16)]
        public string SSN { get; set; }

        [Required, StringLength(16)]
        public string StateIdNumber { get; set; }


        //  residency

        [Required, StringLength(32)]
        public string Street1 { get; set; }

        [StringLength(32)]
        public string Street2 { get; set; }

        [Required, StringLength(32)]
        public string City { get; set; }

        [Required, StringLength(2)]
        public string StateCode { get; set; }

        [Required, StringLength(10)]
        public string PostalCode { get; set; }

        // ----------------------------------------------  audit
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public DateTime? DateVerified { get; set; }
    }
}
