using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class Applicant
    {
        public uint Id { get; set; }
        public string Number { get; set; }
        public byte? ApplicantStatusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public string Note { get; set; }
        public ushort? CountryId { get; set; }
        public byte? ReferralSourceId { get; set; }
        public string Attachment { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ApplicantStatus ApplicantStatus { get; set; }
        public virtual Country Country { get; set; }
        public virtual ReferralSource ReferralSource { get; set; }
    }
}
