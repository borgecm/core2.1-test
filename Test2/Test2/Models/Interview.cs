using System;
using System.Collections.Generic;

namespace Test2.Models
{
    public partial class Interview
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int IdRecruiter { get; set; }

        public Recruiter IdRecruiterNavigation { get; set; }
    }
}
