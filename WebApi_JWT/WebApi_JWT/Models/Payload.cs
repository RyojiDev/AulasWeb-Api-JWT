using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_JWT.Models
{
    public class Payload
    {
        public string uuid { get; set; } 
        public string srcDateTime { get; set; }
        public int srcId { get; set; }
        public string srcAgencyNumber { get; set; }
        public string srcAccountNumber { get; set; }
        public string srcClientName { get; set; }

        public string srcCpfCnpj { get; set; }

        public int amount { get; set; }
        public string urlConfirm { get; set; }

        public string withdrawStatus { get; set; }

        public Payload()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

       
    }
}
