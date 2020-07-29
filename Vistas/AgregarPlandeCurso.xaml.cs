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
    /// Lógica de interacción para AgregarPlandeCurso.xaml
    /// </summary>
    public partial class AgregarPlandeCurso : Window
    {
        public AgregarPlandeCurso()
        {
            InitializeComponent();
        }


        private enum ChecResults
        {
            Passed, Failed
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

        private ChecResults CheckEmptyFields()
        {
            ChecResults check = ChecResults.Failed;
            if (txtActividades.Text == String.Empty || txtDescripcion.Text == String.Empty || txtIdentificador.Text == String.Empty || txtPeriodo.Text == String.Empty || txtTema.Text == String.Empty)
            {
                check = ChecResults.Failed;
            }
            else
            {
                check = ChecResults.Passed;
            }
            return check;
        }


        private ChecResults CheckFields()
        {
            ChecResults check = ChecResults.Failed;
            Logica.CheckFields validarCampos = new Logica.CheckFields();
            if (CheckEmptyFields() == ChecResults.Failed)
            {
                MessageBox.Show("Existen campos sin llenar");
                check = ChecResults.Failed;
            }
            else  if (validarCampos.ValidarNRC(txtIdentificador.Text) == Logica.CheckFields.ResultadosValidación.NRCInvalido)
            {
                MessageBox.Show("El NRC es invalido");
            }else
            {
                check = ChecResults.Passed;
            }
            return check;
        }



        private void ComprobarResultado(OperationResult result)
        {
            if (result == OperationResult.Success)
            {
                MessageBox.Show("Añadido con exito");
                this.Close();
            }
            else if (result == OperationResult.UnknowFail)
            {
                MessageBox.Show("Error desconocido");
            }
            else if (result == OperationResult.SQLFail)
            {
                MessageBox.Show("Error de la base de datos, intente mas tarde");
            }
            else if (result == OperationResult.ExistingRecord)
            {
                MessageBox.Show("El Coordiandor ya existe en el sistema");
            }

        }

   



        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

            if (CheckFields() == ChecResults.Passed)
            {
                ControllerPlan controller = new ControllerPlan();

                ComprobarResultado((OperationResult)controller.añadirPlan(txtActividades.Text, txtDescripcion.Text, txtPeriodo.Text, txtTema.Text, txtIdentificador.Text));
            }
        }
    }
}
