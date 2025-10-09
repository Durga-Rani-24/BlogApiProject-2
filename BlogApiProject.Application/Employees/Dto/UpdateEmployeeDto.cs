using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApiProject.Application.Employees.Dto
{
    public class UpdateEmployeeDto
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime? UpdatedAt { get; set; }
    }
}
