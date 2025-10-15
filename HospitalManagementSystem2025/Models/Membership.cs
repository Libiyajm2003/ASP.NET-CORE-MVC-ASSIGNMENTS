using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem2025.Models
{
    public class Membership
    {
        // MembershipId
        [Key]
        public int MembershipId { get; set; }

        // MemberDescription
        [Required]
        [StringLength(100)]
        [Display(Name = "Member Description")]
        public string MemberDescription { get; set; }

        // InsuredAmount
        [Display(Name = "Insured Amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be positive")]
        public decimal? InsuredAmount { get; set; }
    }
}

