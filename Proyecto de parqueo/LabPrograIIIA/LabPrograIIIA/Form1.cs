using LabPrograIIIA.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabPrograIIIA
{
    public partial class Form1 : Form
    {
        private FormPrincipal FormPrincipal;

        public Form1()
        {
        
        }
        public Form1(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            this.FormPrincipal = formPrincipal;
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            AgregarNuevoVehiculo();
        }
        private void AgregarNuevoVehiculo() 
        {
            Vehiculos nuevoVehiculos = new Vehiculos
            {
                Placa = Convert.ToInt32(txtPlaca.Text),
                Marca = txtMarca.Text,
                Modelo = Convert.ToInt32(txtModelo.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Entrada = Convert.ToInt32(txtEntrada.Text),
                Salida = Convert.ToInt32(txtSalida.Text),
                Celular = Convert.ToInt32(txtCelular.Text),
                Dpi = Convert.ToInt32(txtDPI.Text),
                Pago = txtPago.Text,
            };

            FormPrincipal.AgregarVehiculo(nuevoVehiculos);
            this.Close();
        }
    }
}
