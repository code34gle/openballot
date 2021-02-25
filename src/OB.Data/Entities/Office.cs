using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class Office
    {
        // ----------------------------------------------  
        [Key]
        public int Id { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }


        // ----------------------------------------------  audit
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }


        // ----------------------------------------------  nav
        public List<Candidate> Candidates { get; set; }


        // ---------------------------------------------- 
        // ---------------------------------------------- 
        public Office() {
            this.Candidates = new List<Candidate>();
        }

    }
}
