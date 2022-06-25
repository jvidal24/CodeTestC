using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace zPrestman.Views
{
    public partial class viewsCliente : Form
    {
        public SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings[@"dataSourceConection"]);
        private vSolicitud oSolicitud;
        public viewsCliente(vSolicitud v)
        {
            InitializeComponent();
            oSolicitud = v;
        }
        private void BlankForm_Load(object sender, EventArgs e)
        {
            
        }
        private void dgvViewsContainer_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvViewsContainer.Columns[e.ColumnIndex].Name == "btnSeleccionar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvViewsContainer.Rows[e.RowIndex].Cells["btnSeleccionar"] as DataGridViewButtonCell;
                Icon icoLogo = new Icon(Environment.CurrentDirectory + @"/tick_box32px.ico");
                e.Graphics.DrawIcon(icoLogo, e.CellBounds.Left, e.CellBounds.Top);
                this.dgvViewsContainer.Rows[e.RowIndex].Height = icoLogo.Height;
                this.dgvViewsContainer.Columns[e.ColumnIndex].Width = icoLogo.Width;
                e.Handled = true;
            }
        }
        private void dgvViewsContainer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvViewsContainer.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                //Info-Personal
                oSolicitud.Label_idClienteValue.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["IdCliente"].Value.ToString();
                oSolicitud.StBoxNombre.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                oSolicitud.StBoxApellidos.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();
                oSolicitud.S_tBoxAlias.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Alias"].Value.ToString();
                oSolicitud.SmBoxCedula.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
                oSolicitud.SdtpFechaNacimiento.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["FechaNacimiento"].Value.ToString();
                oSolicitud.StboxEdad.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Edad"].Value.ToString();
                oSolicitud.S_cBoxSexo.SelectedItem = dgvViewsContainer.Rows[e.RowIndex].Cells["Sexo"].Value.ToString();
                oSolicitud.S_tBoxEstadoCivil.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["EstadoCivil"].Value.ToString();
                oSolicitud.S_tBoxProfesion.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Profesion"].Value.ToString();
                oSolicitud.S_tBoxCalle.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Calle"].Value.ToString();
                oSolicitud.S_tBoxNumeroCasaApto.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["NumeroCasaApto"].Value.ToString();
                oSolicitud.S_tBoxCorreoElectronico.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["CorreoElectronico"].Value.ToString();
                oSolicitud.S_mBoxTelefono.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                oSolicitud.S_mBoxCelular.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Celular"].Value.ToString();
                oSolicitud.S_tBoxSector.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Sector"].Value.ToString();
                oSolicitud.S_tBoxCiudad.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Ciudad"].Value.ToString();
                oSolicitud.S_tBoxProvincia.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Provincia"].Value.ToString();
                //Info-Laboral
                oSolicitud.S_tBoxLugarTrabajo.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["LugarTrabajo"].Value.ToString();
                oSolicitud.S_tBoxPuestoTrabajo.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Puesto"].Value.ToString();
                oSolicitud.S_mBoxTelefonoLaboral.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["TelefonoLaboral"].Value.ToString();
                oSolicitud.S_tBoxIngresoMensual.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["IngresosMensuales"].Value.ToString();
                oSolicitud.S_dTpFechaIngreso.Text =  dgvViewsContainer.Rows[e.RowIndex].Cells["FechaIngresoLabor"].Value.ToString();
                oSolicitud.S_txbTiempoLaborando.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["TiempoLaborando"].Value.ToString();
                //Info-RP
                oSolicitud.S_tBoxRP1_Nombre.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Rp1_Nombre"].Value.ToString();
                oSolicitud.S_mBoxRP1_Celular.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Rp1_Celular"].Value.ToString();
                oSolicitud.S_tBoxRP1_Parentezco.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Rp1_Parentezco"].Value.ToString();
                oSolicitud.S_tBoxRP2_Nombre.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Rp2_Nombre"].Value.ToString();
                oSolicitud.S_mBoxRP2_Celular.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Rp2_Celular"].Value.ToString();
                oSolicitud.S_tBoxRP2_Parentezco.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Rp2_Parentezco"].Value.ToString();
                oSolicitud.S_tBoxRP3_Nombre.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Rp3_Nombre"].Value.ToString();
                oSolicitud.S_mBoxRP3_Celular.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Rp3_Celular"].Value.ToString();
                oSolicitud.S_tBoxRP3_Parentezco.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Rp3_Parentezco"].Value.ToString();
                //Info-RedesSoc
                oSolicitud.S_tBoxFacebook.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["cFacebook"].Value.ToString();
                oSolicitud.S_mBoxInstagram.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["cInstagram"].Value.ToString();
                oSolicitud.S_mBoxTwitter.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["cTwitter"].Value.ToString();


                this.Close(); 
            }
        }
        private void tBoxBusquedaRapida_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sqlAdp = new SqlDataAdapter("SELECT * FROM Clientes WHERE Nombre '%"+tBoxBusquedaRapida.Text.Trim()+"'", sqlCon);
                DataTable sqlDt = new DataTable();
                sqlAdp.Fill(sqlDt);
                dgvViewsContainer.DataSource = sqlDt;
                dgvViewsContainer.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void viewsCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            oSolicitud.StBoxNombre.ReadOnly = false;
            oSolicitud.StBoxApellidos.ReadOnly = false;
            oSolicitud.S_tBoxAlias.ReadOnly = false;
        }
    }
}