using Microsoft.EntityFrameworkCore;
using RegistrarUsuario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;


namespace RegistrarUsuario.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().UseSqlite(@"Data Source = DATA\Usuarios.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                UsuarioId = 1,
                Nombres = "Kelvin Peña",
                NombreUsuario = "KelvinP",
                Contrasena = "d7678f190ca1811f2d340c7aa1bf1822e6acaac89ffd8ea5c2f731efd3e10e4a" //Contrasena: 20180193
            });
        }
    }
}
