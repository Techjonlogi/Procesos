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
    /// Lógica de interacción para AgregarMaestro.xaml
    /// </summary>
    public partial class AgregarMaestro : Window
    {
        public AgregarMaestro()
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
            if (TBNumeroPersonal.Text == String.Empty || TBRFC.Text == String.Empty || TBCurp.Text == String.Empty ||TBApellidoPaterno.Text == String.Empty || TBApellidoPaterno1.Text == String.Empty || TBNombre.Text == String.Empty || CBGenero.Text == String.Empty || TBPrefilPRofecional.Text == String.Empty || TBAñosExperiencia.Text==String.Empty || TBCorreo.Text == String.Empty)
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
            else if (validarCampos.ValidarNumeropersonal(TBNumeroPersonal.Text) == Logica.CheckFields.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("numero de personal incorrecto");
            }
            else if (validarCampos.ValidarRFC(TBRFC.Text) == Logica.CheckFields.ResultadosValidación.RfcInvalido)
            {
                MessageBox.Show("El RFC Ingresado no es valido");
            }
            else if (validarCampos.ValidaCurp(TBCurp.Text) == Logica.CheckFields.ResultadosValidación.CurpInvalida)
            {
                MessageBox.Show("La Curp ingresada no es valida");
            }
            else if (validarCampos.ValidarNombres(TBNombre.Text) == Logica.CheckFields.ResultadosValidación.NombresInvalidos)
            {
                MessageBox.Show("El Nombre ingresado no es valido");
            }
            else if (validarCampos.ValidarNombres(TBApellidoPaterno.Text) == Logica.CheckFields.ResultadosValidación.NombresInvalidos)
            {
                MessageBox.Show("El Apellido ingresado no es valido");
            }
            else if (validarCampos.ValidarNombres(TBApellidoPaterno1.Text) == Logica.CheckFields.ResultadosValidación.NombresInvalidos)
            {
                MessageBox.Show("El Apellido ingresado no es valido");
            }
            else if (validarCampos.ValidarCorreo(TBCorreo.Text) == Logica.CheckFields.ResultadosValidación.Correoinválido)
            {
                MessageBox.Show("El Correo que ingresó no es correcto");
            }
            else if (validarCampos.ValidarNumeropersonal(TBAñosExperiencia.Text) == Logica.CheckFields.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("Los años ingresados no son correctos, el campo solo acepta numeros");
            }

            else 
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
                MessageBox.Show("El curso ya está registrado");
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

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
                if (CheckFields() == ChecResults.Passed)
                {
                    MaestroController coordiandorcontroller = new MaestroController();
                    DateTime fecharegistro = DateTime.Today;
                    ComprobarResultado((OperationResult)coordiandorcontroller.AñadirMaestro(TBAñosExperiencia.Text,TBApellidoPaterno1.Text,TBApellidoPaterno.Text,TBCorreo.Text,TBCurp.Text,calFechaNacimiento.SelectedDates.ToString(),CBGenero.Text,TBNumeroPersonal.Text,TBNombre.Text,TBPrefilPRofecional.Text,TBRFC.Text));
                }
            
        }
    }
}
