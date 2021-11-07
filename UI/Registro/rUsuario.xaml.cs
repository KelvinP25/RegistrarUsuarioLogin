using RegistrarUsuario.BLL;
using RegistrarUsuario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistrarUsuario.UI.Registro
{
    /// <summary>
    /// Interaction logic for rUsuario.xaml
    /// </summary>
    public partial class rUsuario : Window
    {
        private Usuario usuario = new Usuario();
        public rUsuario()
        {
            InitializeComponent();
            this.DataContext = usuario;
        }
        private void Limpiar()
        {
            usuario = new Usuario();
            ContrasenaPasswordBox.Password = string.Empty;
            ConfirmarContrasenaPasswordBox.Password = string.Empty;
            this.DataContext = usuario;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0 || NombreUsuarioTextBox.Text.Length == 0 ||
                ContrasenaPasswordBox.Password.Length == 0 || ConfirmarContrasenaPasswordBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Completa el campo que está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarContrasenaPasswordBox.Password != ContrasenaPasswordBox.Password)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Las contraseñas no coiciden", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarContrasenaPasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var estudiante = UsuarioBLL.Buscar(Utilidades.ToInt(UsuarioIdTextBox.Text));

            if (usuario != null)
                this.usuario = estudiante;
            else
                Limpiar();

            this.DataContext = this.usuario;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = UsuarioBLL.Guardar(usuario);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuarioBLL.Eliminar(Utilidades.ToInt(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
