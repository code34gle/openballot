using System;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class Candidate
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        public int OfficeId { get; set;}

        [Required,StringLength(32)]
        public string FirstName { get; set;}

        [StringLength(32)]
        public string MiddleName { get; set;}

        [Required,StringLength(32)]
        public string LastName { get; set;}

        [Required,StringLength(32)]
        public string Party { get; set;}

        public bool IsSelected { get; set;}

        public bool IsIncumbant { get; set;}

        [Required]
        public DateTime DateCreated { get; set;}

        public DateTime DateUpdated { get; set;}

        public string UpdatedBy { get; set;}

        //--------------------------------------------------------
    }
}