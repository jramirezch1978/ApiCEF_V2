using System;
using System.Collections.Generic;
using System.Text;

namespace Intercorp.CEFReports.Domain.Entity
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
