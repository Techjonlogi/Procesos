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
    /// Lógica de interacción para MainDirectivo.xaml
    /// </summary>
    public partial class MainDirectivo : Window
    {
        public MainDirectivo()
        {
            InitializeComponent();
        }

        private void btnConsultarMaestros_Click(object sender, RoutedEventArgs e)
        {
            VerMaestros vm = new VerMaestros();
            vm.ShowDialog();
        }

        private void btnconsultarReportes_Click(object sender, RoutedEventArgs e)
        {
            VerReportes vr = new VerReportes();
            vr.ShowDialog();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }
    }
}
