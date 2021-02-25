using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Models
{
    public class QuestionModel
    {
        //--------------------------------------------------------
        [Key]
        public int Id { get; set;}

        [Required, StringLength(2000)]
        public string Text { get; set;}

        public bool Yes { get; set;}

        public bool No { get; set;}

        //--------------------------------------------------------
    }
}