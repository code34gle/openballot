using System;
using System.ComponentModel.DataAnnotations;

namespace OB.Data.Entities
{
    public class ElectionState
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(16)]
        public string Mode { get; set; }




        public DateTime? ElectionStart { get; set; }

        public DateTime? ElectionEnd { get; set; }



        // ----------------------------------------------  audit
        public DateTime? DateUpdated { get; set; }


    }
}
