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
    /// Lógica de interacción para VerMaestros.xaml
    /// </summary>
    public partial class VerMaestros : Window
    {
        public VerMaestros()
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
            MaestroController Controller = new MaestroController();
            DataMaestros.ItemsSource = null;
            if (Controller.GetProfesor().Any())
            {
                DataMaestros.ItemsSource = Controller.GetProfesor();
            }
            else
            {
                MessageBox.Show("aun no hay nada en la bd");
            }
        }



    }
}
