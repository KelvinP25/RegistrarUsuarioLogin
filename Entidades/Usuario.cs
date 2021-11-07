using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistrarUsuario.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}
