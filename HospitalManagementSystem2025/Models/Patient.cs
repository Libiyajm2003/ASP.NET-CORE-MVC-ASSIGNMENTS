using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem2025.Models
{
    public class Patient
    {
        // PatientId
        [Key]
        public int PatientId { get; set; }

        // RegistrationNo
        [Required]
        [StringLength(20)]
        [Display(Name = "Registration No")]
        public string RegistrationNo { get; set; }

        // PatientName
        [Required(ErrorMessage = "Patient Name is required")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        [RegularExpression(@"[A-Za-z][A-Za-z\s]*$", ErrorMessage = "Name can contain only letters and space and should not start with small letters")]
        public string PatientName { get; set; }

        // Dob
        [BindProperty, DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime? Dob { get; set; }

        // Gender
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be male, female or other")]
        public string? Gender { get; set; }

        // Address
        [StringLength(500)]
        public string? Address { get; set; }

        // PhoneNo
        [Phone]
        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string? PhoneNo { get; set; }

        // Membership details
        public string MemberDescription { get; set; }
        public decimal? InsuredAmount { get; set; }

        // Foreign key to Membership
        [Display(Name = "Membership")]
        public int? MembershipId { get; set; }

        [ForeignKey("MembershipId")]
        public Membership? Membership { get; set; }
    }
}