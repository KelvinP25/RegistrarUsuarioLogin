using RegistrarUsuario.DAL;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace RegistrarUsuario.BLL
{
    public class LoginBLL
    {
        public static bool Validar(string NombreUsuario, string Contrasena)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var validar = from usuario in contexto.Usuario
                              where usuario.NombreUsuario == NombreUsuario
                              && usuario.Contrasena == GetSHA256(Contrasena)
                              select usuario;

                if (validar.Count() > 0)
                {
                    paso = true;
                }
                else
                {
                    paso = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static string GetSHA256(string contrasena)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();

            stream = sha256.ComputeHash(encoding.GetBytes(contrasena));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }
    }
}
