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

namespace zPrestman
{
    public partial class Menu : Form
    {
        public Menu oMenu;
        public SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings[@"dataSourceConection"]);
        
        public Menu()
        {
            InitializeComponent();
            oMenu = this;
        }
        public void VistaAdministrativa()
        {
            //Ocultar y poner visible cada opción del Menu/Submenu
        }
        public void GetSolicitudes()
        {
            SqlDataAdapter sqlAdp = new SqlDataAdapter("Select * From Solicitudes", sqlCon);
            DataTable sqlDt = new DataTable();
            sqlAdp.Fill(sqlDt);
            dgvSolicitudes.DataSource = sqlDt;
            //MessageBox.Show(dgvSolicitudes.Columns.Count.ToString());
            dgvSolicitudes.Columns[2].DefaultCellStyle.BackColor = Color.Yellow;
            dgvSolicitudes.Columns[2].DefaultCellStyle.ForeColor = Color.White;

            dgvSolicitudes.Columns[0].HeaderText = "Nº SOLICITUD";
            dgvSolicitudes.Columns[1].HeaderText = "Nº CLIENTE";
        }
        public void getSolicitudsWithDgv(DataGridView dgv)
        {
            SqlDataAdapter sqlAdp = new SqlDataAdapter("SELECT * FROM Clientes", sqlCon);
            DataTable sqlDt = new DataTable();
            sqlAdp.Fill(sqlDt);
            dgv.DataSource = sqlDt;
        }
        public void GetClientes()
        {
            SqlDataAdapter sqlAdp = new SqlDataAdapter("Select * From Clientes", sqlCon);
            DataTable sqlDset = new DataTable();
            sqlAdp.Fill(sqlDset);
            dgvClientes.DataSource = sqlDset;
            dgvClientes.Columns[0].Width = 50;
            dgvClientes.Columns[1].Width = 50;
            dgvClientes.Columns[2].HeaderText = "Nº CLIENTE";
            dgvClientes.Columns[3].HeaderText = "NOMBRE";
            dgvClientes.Columns[4].HeaderText = "APELLIDOS";
            dgvClientes.Columns[5].HeaderText = "ALIAS";
            dgvClientes.Columns[6].HeaderText = "CEDULA";
            dgvClientes.Columns[7].HeaderText = "FECHA DE NACIMIENTO";
            dgvClientes.Columns[8].HeaderText = "EDAD";
            dgvClientes.Columns[9].HeaderText = "SEXO";
            dgvClientes.Columns[10].HeaderText = "ESTADO CIVIL";
            dgvClientes.Columns[11].HeaderText = "PROFESIÓN";
            dgvClientes.Columns[12].HeaderText = "CALLE";
            dgvClientes.Columns[13].HeaderText = "Nº CASA/APTO";
            dgvClientes.Columns[14].HeaderText = "CORREO ELECTRÓNICO";
            dgvClientes.Columns[15].HeaderText = "TELEFONO";
            dgvClientes.Columns[16].HeaderText = "CELULAR";
            dgvClientes.Columns[17].HeaderText = "SECTOR";
            dgvClientes.Columns[18].HeaderText = "CIUDAD";
            dgvClientes.Columns[19].HeaderText = "PROVINCIA";
            dgvClientes.Columns[20].HeaderText = "LUGAR DE TRABAJO";
            dgvClientes.Columns[21].HeaderText = "PUESTO";
            dgvClientes.Columns[22].HeaderText = "TELÉFONO LABORAL";
            dgvClientes.Columns[23].HeaderText = "INGRESOS MENSUALES";
            dgvClientes.Columns[24].HeaderText = "FECHA INGRESO LABORAL";
            dgvClientes.Columns[25].HeaderText = "TIEMPO LABORANDO";
            dgvClientes.Columns[26].HeaderText = "FACEBOOK";
            dgvClientes.Columns[27].HeaderText = "INSTAGRAM";
            dgvClientes.Columns[28].HeaderText = "TWITTER";
            dgvClientes.Columns[29].HeaderText = "NOMBRE : 1º REFERENCIA PERSONAL";
            dgvClientes.Columns[30].HeaderText = "CELULAR : 1º REFERENCIA PERSONAL";
            dgvClientes.Columns[31].HeaderText = "PARENTEZCO : 1º REFERENCIA PERSONAL";
            dgvClientes.Columns[32].HeaderText = "NOMBRE : 2º REFERENCIA PERSONAL";
            dgvClientes.Columns[33].HeaderText = "CELULAR : 2º REFERENCIA PERSONAL";
            dgvClientes.Columns[34].HeaderText = "PARENTEZCO : 2º REFERENCIA PERSONAL";
            dgvClientes.Columns[35].HeaderText = "NOMBRE : 3º REFERENCIA PERSONAL";
            dgvClientes.Columns[36].HeaderText = "CELULAR : 3º REFERENCIA PERSONAL";
            dgvClientes.Columns[37].HeaderText = "PARENTEZCO : 3º REFERENCIA PERSONAL";
            dgvClientes.Columns[38].HeaderText = "FECHA REGISTRO";
            dgvClientes.Columns[39].HeaderText = "USUARIO";
        }
        private void timerzPrestman_Tick(object sender, EventArgs e)
        {
            //progressBar1.Maximum = 100;
            //progressBar1.Minimum = 0;
            //progressBar1.Increment(2);
            //if (progressBar1.Value == 100)
            //{
            //    progressBar1.Value = 0;
            //}
            labelFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy") + "  " + DateTime.Now.ToLongTimeString();
        }
        public Int32 ObtenerSecuenciaOfCliente()
        {
            int contador;
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Count(*) as Cnt from Clientes";
            cmd.Connection = sqlCon;
            object obj = cmd.ExecuteScalar();
            contador = Convert.ToInt32(obj) + 1;
            sqlCon.Close();
            return contador;
        }
        public Int32 ObtenerSecuenciaOfSolicitud()
        {
            int contador;
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Count(*) as Cnt from Solicitudes"; //CambiarTabla
            cmd.Connection = sqlCon;
            object obj = cmd.ExecuteScalar();
            contador = Convert.ToInt32(obj) + 1;
            sqlCon.Close();
            return contador;
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            tabContainer.Appearance = TabAppearance.FlatButtons; tabContainer.ItemSize = new Size(0, 1); tabContainer.SizeMode = TabSizeMode.Fixed;
            LabelTotalClientes.Text = "Total Clientes : " + ObtenerSecuenciaOfCliente().ToString();
            LabelTotalSolicitudes.Text = "Total Solicitudes : " + ObtenerSecuenciaOfSolicitud().ToString();

        }
        private void InicioToolMenuItem_Click(object sender, EventArgs e)
        {
            tabContainer.SelectedTab = tabMenuInicio;
            LabelTotalClientes.Text = "Total Clientes : " + ObtenerSecuenciaOfCliente().ToString();
            LabelTotalSolicitudes.Text = "Total Solicitudes : " + ObtenerSecuenciaOfSolicitud().ToString();
        }
        private void SolicitudesToolMenuItem_Click(object sender, EventArgs e)
        {
            tabContainer.SelectedTab = tabMenuSolicitudes;

            //DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
            //btnModificar.HeaderText = "";
            //btnModificar.Name = "btnModificar";
            //dgvSolicitudes.Columns.Add(btnModificar);
            //btnModificar.Visible = true;

            //DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            //btnEliminar.HeaderText = "";
            //btnEliminar.Name = "btnEliminar";
            //dgvSolicitudes.Columns.Add(btnModificar);
            //btnEliminar.Visible = true;

            GetSolicitudes();
            dgvSolicitudes.Refresh();
        }
        private void PrestamosToolMenuItem_Click(object sender, EventArgs e)
        {
            tabContainer.SelectedTab = tabMenuPrestamos;
        }
        private void CobrosToolMenuItem_Click(object sender, EventArgs e)
        {
            tabContainer.SelectedTab = tabMenuCobros;
        }
        private void FeriadosToolMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void BtnNuevaSolicitudes_Click(object sender, EventArgs e)
        {
            Views.vSolicitud newSolicitud = new Views.vSolicitud();
            newSolicitud.ShowDialog();
        }
        private void ClientesToolMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tabContainer.SelectedTab = tabMenuClientes;

                DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                btnModificar.HeaderText = "EDITAR";
                btnModificar.Name = "btnModificar";

                if (dgvClientes.Columns.Contains("btnModificar"))
                {
                    btnModificar.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    dgvClientes.Columns.Add(btnModificar);
                }
                btnModificar.Visible = true;

                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "ELIMINAR";
                btnEliminar.Name = "btnEliminar";
                if (dgvClientes.Columns.Contains("btnEliminar"))
                {
                    btnEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    dgvClientes.Columns.Add(btnEliminar);
                }
                //dgvClientes.Columns.Add(btnEliminar);
                btnEliminar.Visible = true;

                GetClientes();
                dgvClientes.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SalirToolMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿ Desea cerrar sesión en el Sistema zPrestman ?",
                       "Salir de zPrestman", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.Yes)
            {
                Login f = new Login();
                f.Visible = true;
                this.Dispose(false);
            }
            else { e.Cancel = true; }
        }
        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            Views.vCliente newCliente = new Views.vCliente();
            newCliente.ShowDialog();
        }
        private void toolMenuItemClausula_Click(object sender, EventArgs e)
        {
            Views.addClausula addClausula = new Views.addClausula(oMenu);
            addClausula.richTboxClausula.ReadOnly = false;
            DialogResult res = addClausula.ShowDialog();
            if (res == DialogResult.OK)
            {
                P_richTboxClausula.Text = addClausula.varClausula;
            }
        }

        private void toolMenuItemBuscarSolicitud_Click(object sender, EventArgs e)
        {
            Views.viewsSolicitud blankFormTemplate = new Views.viewsSolicitud(oMenu);
            DataGridViewButtonColumn btnSeleccionar = new DataGridViewButtonColumn();
            btnSeleccionar.HeaderText = "";
            btnSeleccionar.Name = "btnSeleccionar";
            blankFormTemplate.dgvViewsContainer.Columns.Add(btnSeleccionar);
            btnSeleccionar.Visible = true;
            getSolicitudsWithDgv(blankFormTemplate.dgvViewsContainer);
            blankFormTemplate.ShowDialog();
        }

        private void checkBoxEditarPrestamo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEditarPrestamo.Checked == true)
            {
                P_tBoxIDcliente.ReadOnly = false;
                P_tBoxNombreCompletoCliente.ReadOnly = false;
            }
            else
            {
                P_tBoxIDcliente.ReadOnly = true;
                P_tBoxNombreCompletoCliente.ReadOnly = true;
            }
        }

        private void BtnBuscarSolicitudes_Click(object sender, EventArgs e)
        {
            GetSolicitudes();
        }

        private void dgvSolicitudes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvSolicitudes.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null)
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        if (e.Value.ToString() == "Pendiente")
                        {
                            e.CellStyle.ForeColor = Color.Black;
                            e.CellStyle.BackColor = Color.Yellow;
                        }
                        if (e.Value.ToString() == "Aprobada")
                        {
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.BackColor = Color.Green;
                        }
                        if (e.Value.ToString() == "Rechazada")
                        {
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvClientes.Columns[e.ColumnIndex].Name == "btnModificar")
                {
                    Views.vCliente editCliente = new Views.vCliente();
                    editCliente.c_tBoxNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    //editCliente.Label_idClienteValue.Text = dgvViewsContainer.Rows[e.RowIndex].Cells["IdCliente"].Value.ToString();
                    editCliente.c_tBoxApellidos.Text = dgvClientes.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();
                    editCliente.c_tBoxAlias.Text = dgvClientes.Rows[e.RowIndex].Cells["Alias"].Value.ToString();
                    editCliente.c_mktBoxCedula.Text = dgvClientes.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
                    editCliente.c_dtpFechaNacimiento.Text = dgvClientes.Rows[e.RowIndex].Cells["FechaNacimiento"].Value.ToString();
                    editCliente.c_numericBoxEdad.Text = dgvClientes.Rows[e.RowIndex].Cells["Edad"].Value.ToString();
                    editCliente.c_cBoxSexo.SelectedItem = dgvClientes.Rows[e.RowIndex].Cells["Sexo"].Value.ToString();
                    editCliente.c_tBoxEstadoCivil.Text = dgvClientes.Rows[e.RowIndex].Cells["EstadoCivil"].Value.ToString();
                    editCliente.c_tBoxProfesion.Text = dgvClientes.Rows[e.RowIndex].Cells["Profesion"].Value.ToString();
                    editCliente.c_tBoxCalle.Text = dgvClientes.Rows[e.RowIndex].Cells["Calle"].Value.ToString();
                    editCliente.c_tBoxNumeroCasaApto.Text = dgvClientes.Rows[e.RowIndex].Cells["NumeroCasaApto"].Value.ToString();
                    editCliente.c_tBoxCorreo.Text = dgvClientes.Rows[e.RowIndex].Cells["CorreoElectronico"].Value.ToString();
                    editCliente.c_mktBoxTelefono.Text = dgvClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                    editCliente.c_mktBoxCelular.Text = dgvClientes.Rows[e.RowIndex].Cells["Celular"].Value.ToString();
                    editCliente.c_tBoxSector.Text = dgvClientes.Rows[e.RowIndex].Cells["Sector"].Value.ToString();
                    editCliente.c_tBoxCiudad.Text = dgvClientes.Rows[e.RowIndex].Cells["Ciudad"].Value.ToString();
                    editCliente.c_tBoxProvincia.Text = dgvClientes.Rows[e.RowIndex].Cells["Provincia"].Value.ToString();
                    editCliente.c_tBoxLugarTrabajo.Text = dgvClientes.Rows[e.RowIndex].Cells["LugarTrabajo"].Value.ToString();
                    editCliente.c_tBoxPuesto.Text = dgvClientes.Rows[e.RowIndex].Cells["Puesto"].Value.ToString();
                    editCliente.c_mktTelefonoLaboral.Text = dgvClientes.Rows[e.RowIndex].Cells["TelefonoLaboral"].Value.ToString();
                    editCliente.c_tBoxIngresosMensuales.Text = dgvClientes.Rows[e.RowIndex].Cells["IngresosMensuales"].Value.ToString();
                    editCliente.C_dTpFechaIngreso.Text = dgvClientes.Rows[e.RowIndex].Cells["FechaIngresoLabor"].Value.ToString();
                    editCliente.C_txbTiempoLaborando.Text = dgvClientes.Rows[e.RowIndex].Cells["TiempoLaborando"].Value.ToString();
                    editCliente.cRp1_tBoxNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["Rp1_Nombre"].Value.ToString();
                    editCliente.cRp1_mtBoxCelular.Text = dgvClientes.Rows[e.RowIndex].Cells["Rp1_Celular"].Value.ToString();
                    editCliente.cRp1_tBoxParentezco.Text = dgvClientes.Rows[e.RowIndex].Cells["Rp1_Parentezco"].Value.ToString();
                    editCliente.cRp2_tBoxNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["Rp2_Nombre"].Value.ToString();
                    editCliente.cRp2_mtBoxCelular.Text = dgvClientes.Rows[e.RowIndex].Cells["Rp2_Celular"].Value.ToString();
                    editCliente.cRp2_tBoxParentezco.Text = dgvClientes.Rows[e.RowIndex].Cells["Rp2_Parentezco"].Value.ToString();
                    editCliente.cRp3_tBoxNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["Rp3_Nombre"].Value.ToString();
                    editCliente.cRp3_mtBoxCelular.Text = dgvClientes.Rows[e.RowIndex].Cells["Rp3_Celular"].Value.ToString();
                    editCliente.cRp3_tBoxParentezco.Text = dgvClientes.Rows[e.RowIndex].Cells["Rp3_Parentezco"].Value.ToString();
                    editCliente.c_tBoxFacebook.Text = dgvClientes.Rows[e.RowIndex].Cells["cFacebook"].Value.ToString();
                    editCliente.c_tBoxInstagram.Text = dgvClientes.Rows[e.RowIndex].Cells["cInstagram"].Value.ToString();
                    editCliente.c_tBoxTwitter.Text = dgvClientes.Rows[e.RowIndex].Cells["cTwitter"].Value.ToString();

                    editCliente.ShowDialog();
                }
                if (this.dgvClientes.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    if (MessageBox.Show("Está seguro que desea eliminar éste Cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var idCl = dgvClientes.Rows[e.RowIndex].Cells["IdCliente"].Value;
                        
                        sqlCon.Close();
                        sqlCon.Open();
                        //MessageBox.Show(idCl.ToString());
                        SqlCommand sqlCmd = new SqlCommand("DELETE FROM Clientes WHERE IdCliente = '" + idCl + "'", sqlCon);
                        
                        MessageBox.Show("Cliente [" + dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString() + "] Ha sido Eliminado Correctamente!");
                        sqlCmd.ExecuteNonQuery();
                        dgvClientes.Rows.Remove(dgvClientes.CurrentRow);
                        dgvClientes.Refresh();
                        sqlCon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void dgvClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvClientes.Columns[e.ColumnIndex].Name == "btnModificar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvClientes.Rows[e.RowIndex].Cells["btnModificar"] as DataGridViewButtonCell;
                Icon icoLogo = new Icon(Environment.CurrentDirectory + @"/edit32px.ico");
                e.Graphics.DrawIcon(icoLogo, e.CellBounds.Left, e.CellBounds.Top);
                this.dgvClientes.Rows[e.RowIndex].Height = icoLogo.Height;
                this.dgvClientes.Columns[e.ColumnIndex].Width = icoLogo.Width;
                e.Handled = true;
            }
             if (e.ColumnIndex >= 0 && this.dgvClientes.Columns[e.ColumnIndex].Name == "btnEliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvClientes.Rows[e.RowIndex].Cells["btnEliminar"] as DataGridViewButtonCell;
                Icon icoLogo = new Icon(Environment.CurrentDirectory + @"/delete32px.ico");
                e.Graphics.DrawIcon(icoLogo, e.CellBounds.Left, e.CellBounds.Top);
                this.dgvClientes.Rows[e.RowIndex].Height = icoLogo.Height;
                this.dgvClientes.Columns[e.ColumnIndex].Width = icoLogo.Width;
                e.Handled = true;
            }
        }

        private void BtnBuscarClientes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(C_tBoxBusquedaRapida.Text) && string.IsNullOrEmpty(Cliente_tBoxBusquedaAvanzada.Text))
            {
                GetClientes();
                dgvClientes.Refresh();
            }
            
        }
    }
}