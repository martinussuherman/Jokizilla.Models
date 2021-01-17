namespace Jokizilla.Models.ViewModels
{
    public class ApplicantUpdateDto
    {
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public string Note { get; set; }
        public byte ApplicantStatusId { get; set; }
        public ushort CountryId { get; set; }
        public byte ReferralSourceId { get; set; }
        public string Attachment { get; set; }
    }
}
