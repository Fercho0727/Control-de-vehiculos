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
    public partial class BuscarVehiculo : Form
    {
        private int idVehiculo = 0;

        public BuscarVehiculo()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var dsVehiculo = new DataSet();
            dsVehiculo = BuscarVehiculoPorPlaca(Convert.ToInt32(txtPlacaVehiculo.Text));
            dgVehiculos.ReadOnly = true;
            dgVehiculos.DataSource = dsVehiculo.Tables[0];
            idVehiculo = Convert.ToInt32(dsVehiculo.Tables[0].Rows[0]["id"]);
        }

        public DataSet BuscarVehiculoPorPlaca(int placaVehiculo) 
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = @"Server=DESKTOP-BDRJS3S\SQLEXPRESS;Database = ProyectoParqueo;Trusted_Connection=true";
                    conn.Open();
                    var select = "select * from ParqueoDatos where PlacaVehiculo = " + placaVehiculo;
                    var dataAdapter = new SqlDataAdapter(select, conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("¿Desea eliminar el vehiculo?", "Eliminacion", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) 
                {
                    using (SqlConnection conn = new SqlConnection()) 
                    {
                        conn.ConnectionString = @"Server=DESKTOP-BDRJS3S\SQLEXPRESS;Database = ProyectoParqueo;Trusted_Connection=true";
                        conn.Open();
                        SqlCommand updateCommand = new SqlCommand("DELETE FROM ParqueoDatos WHERE id = " + idVehiculo, conn);
                        updateCommand.ExecuteScalar();
                        MessageBox.Show("El vehiculo a sido eliminado");
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
