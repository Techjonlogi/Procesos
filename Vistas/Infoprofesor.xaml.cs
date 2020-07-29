using ProyectoCursos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoCursos.Vistas
{
    /// <summary>
    /// Lógica de interacción para Infoprofesor.xaml
    /// </summary>
    public partial class Infoprofesor : Window
    {
        public Infoprofesor()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid(txtID.Text);
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateGrid(String id)
        {
            MaestroController Controller = new MaestroController();
            dataMaestro.ItemsSource = null;
            if (Controller.GetMensajeid(id).Any())
            {
                dataMaestro.ItemsSource = Controller.GetMensajeid(id);
            }
            else
            {
                MessageBox.Show("aun no hay nada en la bd");
            }
        }



    }
}
