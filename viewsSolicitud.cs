using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zPrestman.Views
{
    public partial class viewsSolicitud : Form
    {
        public SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings[@"dataSourceConection"]);
        private Menu oMenu;
        public viewsSolicitud(Menu v)
        {
            InitializeComponent();
            oMenu = v;
        }

        private void viewsSolicitud_Load(object sender, EventArgs e)
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
                oMenu.P_tBoxIDcliente.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["IdCliente"].Value.ToString();
                oMenu.P_tBoxIDsolicitud.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["IdCliente"].Value.ToString();
                oMenu.P_tBoxNombreCompletoCliente.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["Nombre"].Value.ToString() + " "+ dgvViewsContainer.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();

                this.Close();
            }
        }

        private void tBoxBusquedaRapida_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sqlAdp = new SqlDataAdapter("SELECT * FROM Clientes WHERE Nombre,Apellidos,Alias LIKE '%" + tBoxBusquedaRapida.Text.Trim() + "%'", sqlCon);
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
    }
}
