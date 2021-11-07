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

namespace RegistrarUsuario.UI.Consulta
{
    /// <summary>
    /// Interaction logic for cUsuario.xaml
    /// </summary>
    public partial class cUsuario : Window
    {
        public cUsuario()
        {
            InitializeComponent();
        }
        private void BuscarCButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuario>();

            switch (FiltroComboBox.SelectedIndex)
            {
                case 0: //Listado
                    listado = UsuarioBLL.GetUsuarios();
                    break;
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
