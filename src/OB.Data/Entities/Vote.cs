using System;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(24)]
        public string Code { get; set; }                       // private identifier

        public int RegistrantId { get; set; }

        public byte[] Ballot { get; set; }

        public bool BallotCast { get; set; }

        // ----------------------------------------------  audit
        public DateTime DateCreated { get; set; }
    }
}
