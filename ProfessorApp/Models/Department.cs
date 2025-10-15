using System.ComponentModel.DataAnnotations;

namespace ProfessorApp.Models
{
    public class Department
    {
        [Key]
        public int DeptNo { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(100)]
        public string DeptName { get; set; }

        [Display(Name = "Head of Department")]
        [StringLength(100)]
        public string HOD { get; set; }
    }
}
