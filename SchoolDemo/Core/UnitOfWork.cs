﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolDemo.Models;
using System.Data.Entity;
using SchoolDemo.Core.Repositories;

namespace SchoolDemo.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
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