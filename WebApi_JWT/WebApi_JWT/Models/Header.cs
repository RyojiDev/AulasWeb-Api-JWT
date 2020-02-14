using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_JWT.Models
{
    public class Header
    {
        public string alg { get; set; } = "RS256";
        public string typ { get; set; } = "JWT";
        public string partner { get; set; } = "1010";
        public int versionKey { get; set; } = 1;
    }
}
