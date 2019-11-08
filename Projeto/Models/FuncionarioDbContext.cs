using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFuncionarios.Models
{
    public class FuncionarioDbContext : DbContext
    {

        public FuncionarioDbContext(DbContextOptions<FuncionarioDbContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }

    }
}
