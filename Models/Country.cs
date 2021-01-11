using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class Country
    {
        public Country()
        {
            Applicants = new HashSet<Applicant>();
        }

        public ushort Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
