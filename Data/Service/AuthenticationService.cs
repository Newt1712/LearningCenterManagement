using Data.Context.MSSQLContext;
using Data.Entities;
using Data.Models.Common;
using Data.Models.RequestModel;
using Data.Models.ResponseModel;
using Data.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service
{
    public class AuthenticationService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<Student> _students;
        private readonly DbSet<Parent> _parents;
        private readonly DbSet<Teacher> _teachers;
        private readonly DbSet<User> _users;
        public AuthenticationService(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
            _students = dbContext.Students;
            _parents = dbContext.Parents;
            _teachers = dbContext.Teachers;
            _users = dbContext.Users;
        }

  
    }
}
