using OB.Data.Entities;
using System.Collections.Generic;

namespace OB.Data.Models
{
    public class Ballot
    {
        public List<Office> Offices { get; set; }
        public List<Question> Questions { get; set; }

        public Ballot()
        {
            Offices = new List<Office>();
            Questions = new List<Question>();
        }
    }
}
