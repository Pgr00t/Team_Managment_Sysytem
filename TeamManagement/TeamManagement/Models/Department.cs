using System.ComponentModel.DataAnnotations;

namespace TeamManagement.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}