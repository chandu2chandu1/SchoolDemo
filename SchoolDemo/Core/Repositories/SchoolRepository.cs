﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolDemo.Models;
using SchoolDemo.Core.Domain;
using System.Data.Entity;

namespace SchoolDemo.Core.Repositories
{
    public interface ISchoolRepository:IRepository<School>
    {
        IEnumerable<School> GetSchoolsWithMostStudents();
        School GetSchoolByStudentId(Student student);
    }

    public class SchoolRepository:Repository<School>, ISchoolRepository
    {
        public SchoolRepository(DbContext dbContext) : base(dbContext)
        {}

        public IEnumerable<School> GetSchoolsWithMostStudents()
        {
            return Context.Set<School>().Take(5);
        }

        public School GetSchoolByStudentId(Student student)
        {
            return Context.Set<School>().Where(s => s.Students == student).FirstOrDefault();
        }
    }
}