using System.ComponentModel.DataAnnotations;

namespace ProfessorApp.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorId { get; set; }

        public int? ManagerId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int DeptNo { get; set; }

        [Display(Name = "Department Name")]
        public string DeptName { get; set; } 

        [Range(10000, 200000, ErrorMessage = "Salary must be between 10,000 and 2,00,000")]
        public decimal Salary { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
    }
}
