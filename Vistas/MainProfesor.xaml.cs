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
    /// Lógica de interacción para MainProfesor.xaml
    /// </summary>
    public partial class MainProfesor : Window
    {
        public MainProfesor()
        {
            InitializeComponent();
        }

        private void btnInfoPersonal_Click(object sender, RoutedEventArgs e)
        {
            Infoprofesor inf = new Infoprofesor();
            inf.ShowDialog();
        }

        private void btnAgregarPlan_Click(object sender, RoutedEventArgs e)
        {
            AgregarPlandeCurso ag = new AgregarPlandeCurso();
            ag.ShowDialog();
        }
    }
}
