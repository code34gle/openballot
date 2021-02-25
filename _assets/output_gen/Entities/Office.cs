using System;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class Office
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

        public List<Candidate> Candidates { get; set;}

        //--------------------------------------------------------
    }
}