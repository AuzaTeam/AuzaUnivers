﻿using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Stud
{
    internal class StudentRepository(AppDbContext ctx) : IStudentRepository
    {

        public async Task AddAsync(Student student, CancellationToken cancellationToken = default)
        {
            await ctx.Students.AddAsync(student, cancellationToken);
            await ctx.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await ctx.Students.ToListAsync(cancellationToken);
        
        }

        public Task<Student> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Student student, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
