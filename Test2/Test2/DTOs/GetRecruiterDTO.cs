using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.DTOs
{
    public class GetRecruiterDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return "Id: " + id + " Name" + name;
        }
    }
}
