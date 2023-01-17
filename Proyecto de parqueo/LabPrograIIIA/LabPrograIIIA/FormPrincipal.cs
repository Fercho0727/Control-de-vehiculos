using LabPrograIIIA.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabPrograIIIA
{
    public partial class FormPrincipal : Form
    {
        private Stack<Vehiculos> PilaVehiculos = new Stack<Vehiculos>();

        public FormPrincipal()
        {
            InitializeComponent();
        }

  
        public void AgregarVehiculo(Vehiculos vehiculos) 
        {
            PilaVehiculos.Push(vehiculos);
            BindingSource bs = new BindingSource
            {
                DataSource = PilaVehiculos
            };
            dgPrincipal.DataSource = bs;
            dgPrincipal.Refresh();
            AgregarVehiculoDB(vehiculos);
        }

        private void AgregarVehiculoDB(Vehiculos vehiculos) 
        {
            try
            {
                using (SqlConnection conn = new SqlConnection()) 
                {
                    conn.ConnectionString = @"Server=DESKTOP-BDRJS3S\SQLEXPRESS;Database = ProyectoParqueo;Trusted_Connection=true";
                    conn.Open();
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO ParqueoDatos VALUES(@PlacaVehiculo," +
                        "@MarcaVehiculo,@ModeloVehiculo,@NombrePropietario,@ApellidoPropietario,@DpiPropietario," +
                        "@CelularPropietario,@HoraEntrada,@HoraSalida,@TipoPago)", conn);
                    //Agregar parametros
                    insertCommand.Parameters.Add(new SqlParameter("PlacaVehiculo", vehiculos.Placa));
                    insertCommand.Parameters.Add(new SqlParameter("MarcaVehiculo", vehiculos.Marca));
                    insertCommand.Parameters.Add(new SqlParameter("ModeloVehiculo", vehiculos.Modelo));
                    insertCommand.Parameters.Add(new SqlParameter("NombrePropietario", vehiculos.Nombre));
                    insertCommand.Parameters.Add(new SqlParameter("ApellidoPropietario", vehiculos.Apellido));
                    insertCommand.Parameters.Add(new SqlParameter("DpiPropietario", vehiculos.Dpi));
                    insertCommand.Parameters.Add(new SqlParameter("CelularPropietario", vehiculos.Celular));
                    insertCommand.Parameters.Add(new SqlParameter("HoraEntrada", vehiculos.Entrada));
                    insertCommand.Parameters.Add(new SqlParameter("HoraSalida", vehiculos.Salida));
                    insertCommand.Parameters.Add(new SqlParameter("TipoPago", vehiculos.Pago));

                    insertCommand.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void agregarAutomóvilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var agregar = new Form1(this))
            {
                agregar.ShowDialog();
            }
        }

        private void buscarYEliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var agregar = new BuscarVehiculo())
            {
                agregar.ShowDialog();
            }
        }
    }
}
