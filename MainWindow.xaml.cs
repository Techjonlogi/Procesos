using ProyectoCursos.Vistas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Logica;
using ProyectoCursos.Controllers;



namespace ProyectoCursos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
            NullOrganization,
            InvalidOrganization,
            UnknowFail,
            SQLFail,
            ExistingRecord
        }

        private ChecResults CheckEmptyFields()
        {
            ChecResults check = ChecResults.Failed;
            if (textboxUsuario.Text == String.Empty || passwordboxccontraseña.Password == String.Empty)
            {
                check = ChecResults.Failed;
            }
            else
            {
                check = ChecResults.Passed;
            }
            return check;
        }

        private ChecResults CheckField()
        {
            ChecResults check = ChecResults.Failed;
            CheckFields validarCampos = new CheckFields();
            if (CheckEmptyFields() == ChecResults.Failed)
            {
                MessageBox.Show("Existen campos sin llenar");
                check = ChecResults.Failed;
            }

            else if (validarCampos.ValidarContraseña(passwordboxccontraseña.Password) == CheckFields.ResultadosValidación.ContraseñaInvalida)
            {
                MessageBox.Show("La contraseña es muy débil \n Intenta combinar letras mayúsculas, minúsculas y números");
            }
            else if (validarCampos.ValidaEspacios(textboxUsuario.Text) == CheckFields.ResultadosValidación.UsuarioInvalido)
            {
                MessageBox.Show("No puede haber espacios en blanco");
            }
            else
            {
                check = ChecResults.Passed;
            }
            return check;
        }

        private void btnIniciarSecion_Click(object sender, RoutedEventArgs e)
        {

            if (CheckField() == ChecResults.Passed)
            {
                UsuarioController controller = new UsuarioController();
                MessageBox.Show(controller.doLoging(textboxUsuario.Text, passwordboxccontraseña.Password).ToString());
                if (controller.doLoging(textboxUsuario.Text, passwordboxccontraseña.Password) == AddResult.Success)
                {

                    AbrirVentana();





                }
            }


        }

        private void AbrirVentana()
        {

            switch (ProyectoCursos.Properties.Settings.Default.tipoUsuario)
            {

                case ("Directivo"):
                    MainDirectivo ventanaDirectivo = new MainDirectivo();
                    ventanaDirectivo.Show();
                    this.Close();

                    break;
                case ("Profesor"):
                    MainProfesor ventanaProfesor = new MainProfesor();
                    ventanaProfesor.Show();
                    this.Close();

                    break;

                case ("Secretario"):
                    MainSecretario ventanasecretario = new MainSecretario();
                    ventanasecretario.Show();
                    this.Close();

                    break;

            }


        }





    }
}
