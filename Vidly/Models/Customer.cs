using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; } = "";

        [Required]
        [StringLength(255)]
        [Display(Name = "Surname")]
        public string SurName { get; set; } = "";

        public string Name => FirstName + " " + SurName;

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Dob { get; set; }
    }
}