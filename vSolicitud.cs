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
    public partial class vSolicitud : Form
    {
        public Menu oMenu;
        public vSolicitud oSolicitud;
        public SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings[@"dataSourceConection"]);
        public vSolicitud()
        {
            InitializeComponent();
            oSolicitud = this;
            oMenu = new Menu();
        }
        public Int32 ObtenerSecuenciaOfSolicitud()
        {
            int contador;
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Count(*) as Cnt from Solicitudes"; //CambiarTabla
            cmd.Connection = sqlCon;
            object obj = cmd.ExecuteScalar();
            contador = Convert.ToInt32(obj)+1;
            sqlCon.Close();
            return contador;
        }
        public void getClientesWithDgv(DataGridView dgv)
        {
            SqlDataAdapter sqlAdp = new SqlDataAdapter("SELECT * FROM Clientes",sqlCon);
            DataTable sqlDt = new DataTable();
            sqlAdp.Fill(sqlDt);
            dgv.DataSource = sqlDt;
        }
        private void vSolicitud_Load(object sender, EventArgs e)
        {
            try
            {
                //Header-out_Tabpage
                tabControlSolicitud.Appearance = TabAppearance.FlatButtons; tabControlSolicitud.ItemSize = new Size(0, 1); tabControlSolicitud.SizeMode = TabSizeMode.Fixed;
                //Nº Solicitud
                labelNumeracionSolicitudValue.Text = ObtenerSecuenciaOfSolicitud().ToString();
                //TiempoLaborando
                S_dTpFechaIngreso.MaxDate = DateTime.Now;
                S_txbTiempoLaborando.Text = DiferenciaFechas(DateTime.Now, S_dTpFechaIngreso.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
        public String DiferenciaFechas(DateTime newdt, DateTime olddt)
        {
            int anos;
            int meses;
            int dias;
            string str = "";

            anos = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);

            if (meses <= 0)
            {
                anos -= 1;
                meses += 12;
            }

            if (dias < 0)
            {
                meses -= 1;
                int DiasAno = newdt.Year;
                int DiasMes = newdt.Month;

                if ((newdt.Month - 1) == 0)
                {
                    DiasAno = DiasAno - 1;
                    DiasMes = 12;
                }
                else
                {
                    DiasMes = DiasMes - 1;
                }

                dias += DateTime.DaysInMonth(DiasAno, DiasMes);
            }

            if (meses == 12)
            {
                anos++;
                meses = 0;
            }

            if (anos < 0)
            {
                return "La fecha inicial es mayor a la fecha final";
            }

            if (anos > 0)
            {
                if (anos == 1)
                    str = str + anos.ToString() + " año ";
                else
                    str = str + anos.ToString() + " años ";
            }

            if (meses > 0)
            {
                if (meses == 1)
                    str = str + meses.ToString() + " mes y ";
                else
                    str = str + meses.ToString() + " meses y ";
            }

            if (dias > 0)
            {
                if (dias == 1)
                    str = str + dias.ToString() + " día ";
                else
                    str = str + dias.ToString() + " días ";
            }
            if (dias == 0)
            {
               str = "0 días ";
            }

            return str;
        }
        private void S_dTpFechaIngreso_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                S_txbTiempoLaborando.Text = DiferenciaFechas(DateTime.Now, S_dTpFechaIngreso.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(S_mBoxInstagram.Text);
        }

        private void BtnSiguientePagina_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(checkTarjetaCredito.Checked.ToString());
            tabControlSolicitud.SelectedTab = tabPag2Solicitud;
        }
        private void BtnAnteriorPagina_Click(object sender, EventArgs e)
        {
            tabControlSolicitud.SelectedTab = tabPag1Solicitud;
        }
        private void BtnAdjuntarCliente_Click(object sender, EventArgs e)
        {
            Views.viewsCliente vistazoCliente = new Views.viewsCliente(oSolicitud);
            DataGridViewButtonColumn btnSeleccionar = new DataGridViewButtonColumn();
            btnSeleccionar.HeaderText = "";
            btnSeleccionar.Name = "btnSeleccionar";
            vistazoCliente.dgvViewsContainer.Columns.Add(btnSeleccionar);
            btnSeleccionar.Visible = true;

            getClientesWithDgv(vistazoCliente.dgvViewsContainer);
            vistazoCliente.ShowDialog();
            //DialogResult res = addClausula.ShowDialog();
            //if (res == DialogResult.OK)
            //{
            //    P_richTboxClausula.Text = addClausula.varClausula;
            //}
        }
        private void BtnRegistrarSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(StBoxNombre.Text))
                {
                    MessageBox.Show("Introduzca Nombre");
                    return;
                }
                if (string.IsNullOrEmpty(S_tBoxDestinoPrestamo.Text))
                {
                    MessageBox.Show("Introduzca Destino Préstamo");
                    return;
                }
                sqlCon.Close();
                sqlCon.Open();
                SqlCommand InsertSolicitud = new SqlCommand("SpNewSolicitud", sqlCon);
                InsertSolicitud.CommandType = CommandType.StoredProcedure;
                InsertSolicitud.Parameters.AddWithValue("@IdCliente", Label_idClienteValue.Text);
                InsertSolicitud.Parameters.AddWithValue("@Estado", "Pendiente");
                InsertSolicitud.Parameters.AddWithValue("@DestinoPrestamo", S_tBoxDestinoPrestamo.Text);
                InsertSolicitud.Parameters.AddWithValue("@Referencia", S_tBoxReferencia.Text);
                InsertSolicitud.Parameters.AddWithValue("@NombreInstitucionFinanciera", S_tBoxInstitucionFinancieraBanco.Text);
                InsertSolicitud.Parameters.AddWithValue("@NumeroCuenta", S_tBoxNumeroCuenta.Text);
                InsertSolicitud.Parameters.AddWithValue("@MontoSolicitado", S_tBoxMontoSolicitado.Text);
                InsertSolicitud.Parameters.AddWithValue("@D1_NombreBanco", S_tBoxD1NombreBanco.Text);
                InsertSolicitud.Parameters.AddWithValue("@D1_CantidadDeudora", S_tBoxD1CantidadDeudora.Text);
                InsertSolicitud.Parameters.AddWithValue("@D1_FechaInicio", S_dtpD1FechaInicio.Value.ToShortDateString());
                InsertSolicitud.Parameters.AddWithValue("@D1_FechaFin", S_dtpD1FechaFin.Value.ToShortDateString());
                InsertSolicitud.Parameters.AddWithValue("@D2_NombreBanco", S_tBoxD2NombreBanco.Text);
                InsertSolicitud.Parameters.AddWithValue("@D2_CantidadDeudora", S_tBoxD2CantidadDeudora.Text);
                InsertSolicitud.Parameters.AddWithValue("@D2_FechaInicio", S_dtpD2FechaInicio.Value.ToShortDateString());
                InsertSolicitud.Parameters.AddWithValue("@D2_FechaFin", S_dtpD2FechaFin.Value.ToShortDateString());
                InsertSolicitud.Parameters.AddWithValue("@checkTarjetaCredito", checkTarjetaCredito.Checked);
                InsertSolicitud.Parameters.AddWithValue("@checkGaranteDeudaActiva", checkGaranteDeudaActiva.Checked);
                InsertSolicitud.Parameters.AddWithValue("@checkPrestamoHipotecario", checkPrestamoHipotecario.Checked);
                InsertSolicitud.Parameters.AddWithValue("@checkPrestamoEstudiantil", checkPrestamoEstudiantil.Checked);
                InsertSolicitud.Parameters.AddWithValue("@checkFinanciamientoVehiculo", checkFinancVehiculo.Checked);
                InsertSolicitud.Parameters.AddWithValue("@checkFinanciamientoElectrodomestico", checkFinancElectrodomestico.Checked);
                InsertSolicitud.Parameters.AddWithValue("@RC1_Nombre", S_tBoxRC1_Nombre.Text);
                InsertSolicitud.Parameters.AddWithValue("@RC1_Celular", S_mBoxRC1_Celular.Text);
                InsertSolicitud.Parameters.AddWithValue("@RC1_Institucion", S_tBoxRC1_Institucion.Text);
                InsertSolicitud.Parameters.AddWithValue("@RC2_Nombre", S_tBoxRC2_Nombre.Text);
                InsertSolicitud.Parameters.AddWithValue("@RC2_Celular", S_mBoxRC2_Celular.Text);
                InsertSolicitud.Parameters.AddWithValue("@RC2_Institucion", S_tBoxRC2_Institucion.Text);
                InsertSolicitud.Parameters.AddWithValue("@RC3_Nombre", S_tBoxRC3_Nombre.Text);
                InsertSolicitud.Parameters.AddWithValue("@RC3_Celular", S_mBoxRC3_Celular.Text);
                InsertSolicitud.Parameters.AddWithValue("@RC3_Institucion", S_tBoxRC3_Institucion.Text);
                InsertSolicitud.Parameters.AddWithValue("@RL1_Nombre", S_tBoxRL1_Nombre.Text);
                InsertSolicitud.Parameters.AddWithValue("@RL1_Celular", S_mBoxRL1_Celular.Text);
                InsertSolicitud.Parameters.AddWithValue("@RL1_Empresa", S_tBoxRL1_Empresa.Text);
                InsertSolicitud.Parameters.AddWithValue("@RL2_Nombre", S_tBoxRL2_Nombre.Text);
                InsertSolicitud.Parameters.AddWithValue("@RL2_Celular", S_mBoxRL2_Celular.Text);
                InsertSolicitud.Parameters.AddWithValue("@RL2_Empresa", S_tBoxRL2_Empresa.Text);
                InsertSolicitud.Parameters.AddWithValue("@RL3_Nombre", S_tBoxRL3_Nombre.Text);
                InsertSolicitud.Parameters.AddWithValue("@RL3_Celular", S_mBoxRL3_Celular.Text);
                InsertSolicitud.Parameters.AddWithValue("@RL3_Empresa", S_tBoxRL3_Empresa.Text);
                InsertSolicitud.Parameters.AddWithValue("@FechaRegistro", DateTime.Now.ToString());
                InsertSolicitud.Parameters.AddWithValue("@esUsuario", oMenu.LabelUsuarioValue.Text);
                InsertSolicitud.ExecuteNonQuery();

                MessageBox.Show("Solicitud de [" + StBoxNombre.Text + "] Registrada Exitosamente");
                sqlCon.Close();

                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
