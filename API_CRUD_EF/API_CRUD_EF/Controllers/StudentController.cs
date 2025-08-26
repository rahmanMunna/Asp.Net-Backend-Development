using API_CRUD_EF.DTO;
using API_CRUD_EF.EF;
using API_CRUD_EF.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_CRUD_EF.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        UniversityMSEntities db = new UniversityMSEntities();

        [HttpGet]
        [Route("all")]

        public HttpResponseMessage Get()
        {
            try
            {
                var students = MapperHelper.GetMapper().Map<List<StudentDTO>>(db.Students.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, students);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var student = MapperHelper.GetMapper().Map<StudentDTO>(db.Students.Find(id));
                if (student != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, student);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student Not Found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("edit/{id}")]

        public HttpResponseMessage Edit(int id,StudentDTO stdDTO)
        {
            try
            {
                var student = db.Students.Find(id); 
              
                if (student != null)
                {                   
                    student.Name = stdDTO.Name;
                    student.Cgpa = stdDTO.Cgpa;
                    student.DepartmentId = stdDTO.DepartmentId;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, stdDTO);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student Not Found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("delete/{id}")]

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var student = db.Students.Find(id);
                
                if (student != null)
                {
                   
                    db.Students.Remove(student);    
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK,student.Name+" :has been deleted ");
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student Not Found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("department/{sId}")]

        public HttpResponseMessage Department(int sId)
        {
            try
            {
                var student = db.Students.Find(sId);            
                if (student != null)
                {
                    var studentDept = MapperHelper.GetMapper().Map<StudentDepartmentDTO>(student);

                   
                    return Request.CreateResponse(HttpStatusCode.OK, studentDept);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student Not Found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }




    }
}
