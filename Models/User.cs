using System;
using System.Collections.Generic;

#nullable disable

namespace Jokizilla.Models.Models
{
    public partial class User
    {
        public User()
        {
            Attachments = new HashSet<Attachment>();
            Comments = new HashSet<Comment>();
            OrderCustomers = new HashSet<Order>();
            OrderWriters = new HashSet<Order>();
            Ratings = new HashSet<Rating>();
            SubmittedWorks = new HashSet<SubmittedWork>();
        }

        public uint Id { get; set; }
        public string NetAuthUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string Timezone { get; set; }
        public bool Inactive { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public string LastLoginIp { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Order> OrderCustomers { get; set; }
        public virtual ICollection<Order> OrderWriters { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<SubmittedWork> SubmittedWorks { get; set; }
    }
}
