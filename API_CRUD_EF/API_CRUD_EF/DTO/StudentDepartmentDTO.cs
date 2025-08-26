using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CRUD_EF.DTO
{
    public class StudentDepartmentDTO : StudentDTO
    {
        public DepartmentDTO Department { get; set; }
    }
}