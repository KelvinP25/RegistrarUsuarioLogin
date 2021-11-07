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

namespace RegistrarUsuario.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        Usuario usuario = new Usuario();

        MainWindow Principal = new MainWindow();
        public Login()
        {
            InitializeComponent();
        }
        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = LoginBLL.Validar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

            if (paso)
            {
                this.Close();
                Principal.Show();
            }
            else
            {
                MessageBox.Show("Nombre Usuario o Contraseña incorrecta!", "Error!");
                ContrasenaPasswordBox.Clear();
                NombreUsuarioTextBox.Focus();
            }
        }
        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
