using Microsoft.EntityFrameworkCore;
using RegistrarUsuario.DAL;
using RegistrarUsuario.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace RegistrarUsuario.BLL
{
    public class UsuarioBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Usuario.Any(u => u.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static bool Guardar(Usuario usuario)
        {
            if (!Existe(usuario.UsuarioId))
            {
                return Insertar(usuario);
            }
            else
            {
                return Modificar(usuario);
            }
        }

        public static bool Insertar(Usuario usuario)
        {
            Contexto contexto = new Contexto();
            bool guardado = false;

            try
            {
                usuario.Contrasena = GetSHA256(usuario.Contrasena);
                if (contexto.Usuario.Add(usuario) != null)
                {
                    guardado = (contexto.SaveChanges() > 0);
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
            return guardado;
        }

        private static bool Modificar(Usuario usuario)
        {
            Contexto contexto = new Contexto();
            bool modificado = false;
            usuario.Contrasena = GetSHA256(usuario.Contrasena);
            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                modificado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var usuario = contexto.Usuario.Find(id);

                if (usuario != null)
                {
                    contexto.Usuario.Remove(usuario);
                    eliminado = (contexto.SaveChanges() > 0);
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
            return eliminado;
        }
        public static Usuario Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuario usuario = new Usuario();

            try
            {
                usuario = contexto.Usuario.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuario;
        }
        public static List<Usuario> GetList(Expression<Func<Usuario, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Usuario> Lista = new List<Usuario>();

            try
            {
                Lista = contexto.Usuario.Where(criterio).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
        public static List<Usuario> GetUsuarios()
        {
            Contexto contexto = new Contexto();
            List<Usuario> Lista = new List<Usuario>();

            try
            {
                Lista = contexto.Usuario.ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
        public static bool Validar(string nombre, string contrasena)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Usuario
                    .Any(u => u.Nombres.Equals(nombre)
                    && u.Contrasena.Equals(GetSHA256(contrasena)));
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
        private static string GetSHA256(string contrasena)
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
