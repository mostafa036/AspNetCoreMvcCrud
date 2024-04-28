using DemoDAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Http;

namespace DemoPL.ViewModels
{
    //ViewModel
    public class EmployeeViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is required")]
        [MaxLength(50, ErrorMessage = "max Length Is 50")]
        [MinLength(5, ErrorMessage = "Min Length Is 5")]
        public string Name { get; set; }
        [Range(22, 30, ErrorMessage = "Age Should Be Between 22 & 30")]
        public int Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Address Must Be Like 123-Street-City-Country")]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        [Range(4000, 5000)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
    }
}
