using System;
using System.Collections.Generic;
using System.Text;

namespace Intercorp.CEFReports.Domain.Entity
{
    public class ClientFamilyMember
    {
        public string ClientFamilyMemberId { get; set; }
        public int MemberType { get; set; }
        public string Name { get; set; }
        public string LasName { get; set; }
    }
}
