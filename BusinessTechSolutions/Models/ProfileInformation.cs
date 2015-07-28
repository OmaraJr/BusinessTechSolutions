using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessTechSolutions.Models
{
    public class ProfileInformation
    {
        public int EntryId { get; set; }
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public bool Status { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime GraduationDate { get; set; }

    }
}