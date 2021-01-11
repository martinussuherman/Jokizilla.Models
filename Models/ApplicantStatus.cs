using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class ApplicantStatus
    {
        public ApplicantStatus()
        {
            Applicants = new HashSet<Applicant>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
