using System;
using System.Collections.Generic;

namespace Test2.Models
{
    public partial class Recruiter
    {
        public Recruiter()
        {
            Interview = new HashSet<Interview>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Interview> Interview { get; set; }
    }
}
