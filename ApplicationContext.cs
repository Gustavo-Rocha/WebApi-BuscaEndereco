using BuscaEndereco.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaEndereco
{
    public class ApplicationContext : DbContext
    {


        public DbSet<Endereco> Enderecos { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public ApplicationContext()
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Endereco>().HasKey(e => e.Cep);
            
        }

       

    }

}

