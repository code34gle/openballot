using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Models
{
    public class RegistrantModel
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        [Required, StringLength(256)]
        public string EncKey { get; set;}

        [Required, StringLength(24)]
        public string Code { get; set;}

        [Required, StringLength(32)]
        public string FirstName { get; set;}

        [StringLength(32)]
        public string MiddleName { get; set;}

        [Required, StringLength(32)]
        public string LastName { get; set;}

        [StringLength(16)]
        public string Suffix { get; set;}

        [Required]
        public DateTime DOB { get; set;}

        [StringLength(16)]
        public string SSN { get; set;}

        [StringLength(16)]
        public string StateIdNumber { get; set;}

        [Required,StringLength(32)]
        public string Street1 { get; set;}

        [StringLength(32)]
        public string Street2 { get; set;}

        [Required,StringLength(32)]
        public string City { get; set;}

        [Required,StringLength(2)]
        public string StateCode { get; set;}

        [Required,StringLength(10)]
        public string PostalCode { get; set;}

        [Required]
        public DateTime DateCreated { get; set;}

        public DateTime DateUpdated { get; set;}

        public DateTime DateVerified { get; set;}

        //--------------------------------------------------------
    }
}