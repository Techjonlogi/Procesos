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
    /// Lógica de interacción para MainSecretario.xaml
    /// </summary>
    public partial class MainSecretario : Window
    {
        public MainSecretario()
        {
            InitializeComponent();
        }

        private void btnRegistrarMaestro_Click(object sender, RoutedEventArgs e)
        {
            AgregarMaestro ag=new AgregarMaestro();
            ag.ShowDialog();
        }

        private void btnAgregarCursos_Click(object sender, RoutedEventArgs e)
        {
            AgregarCurso ac = new AgregarCurso();
            ac.ShowDialog();
        }

        private void btnConsultarCursos_Click(object sender, RoutedEventArgs e)
        {
            VerCursos vc = new VerCursos();
            vc.ShowDialog();
        }

        private void btnEliminarCursos_Click(object sender, RoutedEventArgs e)
        {
            EliminarCurso ec = new EliminarCurso();
            ec.ShowDialog();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
             MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
