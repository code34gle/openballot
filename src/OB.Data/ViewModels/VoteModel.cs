using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Models
{
    public class VoteModel
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        [Required, StringLength(24)]
        public string Code { get; set;}

        public int RegistrantId { get; set;}

        public string Ballot { get; set;}

        public bool BallotCast { get; set;}

        [Required]
        public DateTime DateCreated { get; set;}

        //--------------------------------------------------------
    }
}