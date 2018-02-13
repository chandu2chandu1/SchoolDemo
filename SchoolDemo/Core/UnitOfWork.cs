﻿using System;
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

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
            Students = new StudentRepository(_context);
            Schools = new SchoolRepository(_context);
        }

        public IStudentRepository Students { get; private set; }

        public ISchoolRepository Schools { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}