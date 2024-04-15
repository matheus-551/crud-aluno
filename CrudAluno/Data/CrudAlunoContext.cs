using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudAluno.Models;

namespace CrudAluno.Data
{
    public class CrudAlunoContext : DbContext
    {
        public CrudAlunoContext (DbContextOptions<CrudAlunoContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Aluno { get; set; } = default!;
    }
}
