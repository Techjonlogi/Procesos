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
using ProyectoCursos.Controllers;

namespace ProyectoCursos.Vistas
{
    /// <summary>
    /// Lógica de interacción para VerReportes.xaml
    /// </summary>
    public partial class VerReportes : Window
    {
        public VerReportes()
        {
            InitializeComponent();
            UpdateGrid();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateGrid()
        {
            RegistroController Controller = new RegistroController();
            dataReporte.ItemsSource = null;
            if (Controller.GetReporte().Any())
            {
                dataReporte.ItemsSource = Controller.GetReporte();
            }
            else
            {
                MessageBox.Show("aun no hay nada en la bd");
            }
        }


    }
}
