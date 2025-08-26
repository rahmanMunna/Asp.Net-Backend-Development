using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CRUD_EF.DTO
{
    public class DepartmentStudentDTO : DepartmentDTO
    {
        public List<StudentDTO> Students { get; set; }  
    }
}