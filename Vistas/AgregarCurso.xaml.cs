﻿using System;
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
using ProyectoCursos.Logica;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Pojos;

namespace ProyectoCursos.Vistas
{
    /// <summary>
    /// Lógica de interacción para AgregarCurso.xaml
    /// </summary>
    public partial class AgregarCurso : Window
    {
        public AgregarCurso()
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
            if (txtbCupo.Text == String.Empty || comboPeriodo.Text == String.Empty || txtNombre.Text == String.Empty || txtNRC.Text == String.Empty )           {
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
            else if (validarCampos.ValidarNRC(txtNRC.Text) == Logica.CheckFields.ResultadosValidación.NRCInvalido)
            {
                MessageBox.Show("El NRC que ingresó no es correcto");
            }
            else if (validarCampos.ValidarNombres(txtNombre.Text) == Logica.CheckFields.ResultadosValidación.NombresInvalidos)
            {
                MessageBox.Show("El Nombre que ingresó no es correcto");
            } 
             else if (validarCampos.ValidarNumeropersonal(txtbCupo.Text) == Logica.CheckFields.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("El Cupo que ingresó no es correcto");
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
                MessageBox.Show("No se puede agregar el curso con un nrc registrado");
            }
            else if (result == OperationResult.SQLFail)
            {
                MessageBox.Show("Error de la base de datos, intente mas tarde");
            }
            else if (result == OperationResult.ExistingRecord)
            {
                MessageBox.Show("El plan de curos ya existe en el sistema");
            }
        }

        

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields() == ChecResults.Passed)
            {
                ControllerCurso controller = new ControllerCurso();
                DateTime fecharegistro = DateTime.Today;
                ComprobarResultado((OperationResult)controller.AñadirCurso(txtbCupo.Text, txtNRC.Text, txtNombre.Text,comboPeriodo.Text,comboSeccion.Text));
            }

        }
    }
}
