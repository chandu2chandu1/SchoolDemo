using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolDemo.Core.Repositories;
using SchoolDemo.Core.Domain;
using SchoolDemo.Core;

namespace SchoolDemo.api
{

    public class StudentController : ApiController
    {

        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //private readonly ITestClass _testClass;
        //public StudentController(ITestClass test)
        //{
        //    _testClass = test;
        //}

        public IHttpActionResult GetStudents()
        {
            IEnumerable<Student> allBoyStudents = _unitOfWork.Students.GetAllBoys();
            if (allBoyStudents != null && allBoyStudents.Count() >0)
                return Ok(allBoyStudents);
            return Ok("No students found.. I am sorry!!");
        }

    }
}
