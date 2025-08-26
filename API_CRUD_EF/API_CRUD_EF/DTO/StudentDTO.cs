using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CRUD_EF.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cgpa { get; set; }
        public int DepartmentId { get; set; }
    }
}