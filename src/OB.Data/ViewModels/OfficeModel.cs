using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Models
{
    public class OfficeModel
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        [Required, StringLength(64)]
        public string Name { get; set;}

        [StringLength(2000)]
        public string Description { get; set;}

        public DateTime DateCreated { get; set;}

        public DateTime DateUpdated { get; set;}

        [StringLength(32)]
        public string UpdatedBy { get; set;}

        public List<CandidateModel> Candidates { get; set;}

        //--------------------------------------------------------
    }
}