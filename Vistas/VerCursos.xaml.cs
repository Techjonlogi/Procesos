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
using ProyectoCursos.Pojos;
using ProyectoCursos.Controllers;

namespace ProyectoCursos.Vistas
{
    /// <summary>
    /// Lógica de interacción para VerCursos.xaml
    /// </summary>
    public partial class VerCursos : Window
    {
        public VerCursos()
        {
            InitializeComponent();
            UpdateGrid();
        }




        private void UpdateGrid()
        {
            ControllerCurso coordiandorController = new ControllerCurso();
            dataCursos.ItemsSource = null;
            if (coordiandorController.Getcurso().Any())
            {
                dataCursos.ItemsSource = coordiandorController.Getcurso();
            }
            else
            {
                MessageBox.Show("aun no hay nada en la bd");
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
