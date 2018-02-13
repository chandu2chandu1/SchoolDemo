using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchoolDemo.Core.Repositories;
using System.Threading.Tasks;

namespace SchoolDemo.Core
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        ISchoolRepository Schools { get; }
        int Complete();
    }
}
