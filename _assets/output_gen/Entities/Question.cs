using System;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class Question
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