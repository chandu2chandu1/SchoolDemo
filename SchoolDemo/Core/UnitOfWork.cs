using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolDemo.Models;
using SchoolDemo.Core.Repositories;

namespace SchoolDemo.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IStudentRepository Students { get; private set; }

        public ISchoolRepository Schools { get; private set; }
    }
}