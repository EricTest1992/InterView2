using System.ComponentModel.DataAnnotations;

namespace InterView.Models.ViewModels
{
    public class EmployeeViewModel
    {
        [Required]
        [Display(Name = "員工ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "員工名稱")]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "員工電話")]
        public string Phone { get; set; } = null!;

        [Required]
        [Display(Name = "員工地址")]
        public string Address { get; set; } = null!;
    }
}
