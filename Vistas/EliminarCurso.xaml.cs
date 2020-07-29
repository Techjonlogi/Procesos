using ProyectoCursos.Controllers;
using ProyectoCursos.Pojos;
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
using static ProyectoCursos.Logica.AddEnum;

namespace ProyectoCursos.Vistas
{
    /// <summary>
    /// Lógica de interacción para EliminarCurso.xaml
    /// </summary>
    public partial class EliminarCurso : Window
    {
        public EliminarCurso()
        {
            InitializeComponent();
            UpdateGrid();
        }



        public enum OperationResult
        {
            Success,
            NullCoordinador,
            InvaliCoordinador,
            UnknowFail,
            SQLFail,
            ExistingRecord

        }


        private void ComprobarResultado(OperationResult result)
        {
            if (result == OperationResult.Success)
            {
                MessageBox.Show("eliminado con exito");
                this.Close();
            }
            else if (result == OperationResult.UnknowFail)
            {
                MessageBox.Show("Error desconocido, no se puedo eliminar");
            }
            else if (result == OperationResult.SQLFail)
            {
                MessageBox.Show("Error de la base de datos, intente mas tarde");
            }

        }




        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dataCurso.SelectedIndex>-1)
            {
                ControllerCurso controller = new ControllerCurso();
                ComprobarResultado((OperationResult)controller.DeleteCurso(((Curso)dataCurso.SelectedValue).NRC));
                UpdateGrid();
            }
            else MessageBox.Show("Debe seleccionar un celda valida para eliminar");
        }


        private void UpdateGrid()
        {
            ControllerCurso coordiandorController = new ControllerCurso();
            dataCurso.ItemsSource = null;
            if (coordiandorController.Getcurso().Any())
            {
                dataCurso.ItemsSource = coordiandorController.Getcurso();
            }
            else
            {
                MessageBox.Show("aun no hay nada en la bd");
            }
        }




    }
}
