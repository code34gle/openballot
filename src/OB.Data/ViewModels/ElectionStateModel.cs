using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Models
{
    public class ElectionStateModel
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        [Required,StringLength(16)]
        public int Mode { get; set;}

        public DateTime ElectionStart { get; set;}

        public DateTime ElectionEnd { get; set;}

        public DateTime DateUpdated { get; set;}

        public string UpdatedBy { get; set;}

        //--------------------------------------------------------
    }
}