using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Code Is Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50, ErrorMessage= "Max Length Of Name is 50 chars")]
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
