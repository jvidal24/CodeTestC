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
    public partial class vCliente : Form
    {
        Menu menu = new Menu();
        public SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings[@"dataSourceConection"]);
        public vCliente()
        {
            InitializeComponent();
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
        private void vCliente_Load(object sender, EventArgs e)
        {
            //Nº Solicitud cambiar encabezado col dataGridView1.Columns[0].HeaderText = "CODIGO ART";
            labelNumeracionClienteValue.Text = ObtenerSecuenciaOfCliente().ToString();


            C_dTpFechaIngreso.MaxDate = DateTime.Now;
            C_txbTiempoLaborando.Text = DiferenciaFechas(DateTime.Now, C_dTpFechaIngreso.Value);
        }

        private void BtnCancelarC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRegistrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(c_tBoxNombre.Text))
                {
                    MessageBox.Show("Introduzca Nombre");
                    return;
                }
                sqlCon.Open();
                SqlCommand InsertCliente = new SqlCommand("SpNewClient",sqlCon);
                InsertCliente.CommandType = CommandType.StoredProcedure;
                InsertCliente.Parameters.AddWithValue("@Nombre", c_tBoxNombre.Text);
                InsertCliente.Parameters.AddWithValue("@Apellidos", c_tBoxApellidos.Text);
                InsertCliente.Parameters.AddWithValue("@Alias", c_tBoxAlias.Text);
                InsertCliente.Parameters.AddWithValue("@Cedula", c_mktBoxCedula.Text);
                InsertCliente.Parameters.AddWithValue("@FechaNacimiento", c_dtpFechaNacimiento.Value.ToShortDateString());
                InsertCliente.Parameters.AddWithValue("@Edad", c_numericBoxEdad.Value.ToString());
                InsertCliente.Parameters.AddWithValue("@Sexo", c_cBoxSexo.Text.ToString());
                InsertCliente.Parameters.AddWithValue("@EstadoCivil", c_tBoxEstadoCivil.Text);
                InsertCliente.Parameters.AddWithValue("@Profesion", c_tBoxProfesion.Text);
                InsertCliente.Parameters.AddWithValue("@Calle", c_tBoxCalle.Text);
                InsertCliente.Parameters.AddWithValue("@NumeroCasaApto", c_tBoxNumeroCasaApto.Text);
                InsertCliente.Parameters.AddWithValue("@CorreoElectronico", c_tBoxCorreo.Text);
                InsertCliente.Parameters.AddWithValue("@Telefono", c_mktBoxTelefono.Text);
                InsertCliente.Parameters.AddWithValue("@Celular", c_mktBoxCelular.Text);
                InsertCliente.Parameters.AddWithValue("@Sector", c_tBoxSector.Text);
                InsertCliente.Parameters.AddWithValue("@Ciudad", c_tBoxCiudad.Text);
                InsertCliente.Parameters.AddWithValue("@Provincia", c_tBoxProvincia.Text);
                InsertCliente.Parameters.AddWithValue("@LugarTrabajo", c_tBoxLugarTrabajo.Text);
                InsertCliente.Parameters.AddWithValue("@Puesto", c_tBoxPuesto.Text);
                InsertCliente.Parameters.AddWithValue("@TelefonoLaboral", c_mktTelefonoLaboral.Text);
                InsertCliente.Parameters.AddWithValue("@IngresosMensuales", c_tBoxIngresosMensuales.Text);
                InsertCliente.Parameters.AddWithValue("@FechaIngresoLabor", C_dTpFechaIngreso.Value.ToString());
                InsertCliente.Parameters.AddWithValue("@TiempoLaborando", C_txbTiempoLaborando.Text);
                InsertCliente.Parameters.AddWithValue("@cFacebook", c_tBoxFacebook.Text);
                InsertCliente.Parameters.AddWithValue("@cInstagram", c_tBoxInstagram.Text);
                InsertCliente.Parameters.AddWithValue("@cTwitter", c_tBoxTwitter.Text);
                InsertCliente.Parameters.AddWithValue("@Rp1_Nombre", cRp1_tBoxNombre.Text);
                InsertCliente.Parameters.AddWithValue("@Rp1_Celular", cRp1_mtBoxCelular.Text);
                InsertCliente.Parameters.AddWithValue("@Rp1_Parentezco", cRp1_tBoxParentezco.Text);
                InsertCliente.Parameters.AddWithValue("@Rp2_Nombre", cRp2_tBoxNombre.Text);
                InsertCliente.Parameters.AddWithValue("@Rp2_Celular", cRp2_mtBoxCelular.Text);
                InsertCliente.Parameters.AddWithValue("@Rp2_Parentezco", cRp2_tBoxParentezco.Text);
                InsertCliente.Parameters.AddWithValue("@Rp3_Nombre", cRp3_tBoxNombre.Text);
                InsertCliente.Parameters.AddWithValue("@Rp3_Celular", cRp3_mtBoxCelular.Text);
                InsertCliente.Parameters.AddWithValue("@Rp3_Parentezco", cRp3_tBoxParentezco.Text);
                InsertCliente.Parameters.AddWithValue("@FechaRegistro", DateTime.Now.ToString());
                InsertCliente.Parameters.AddWithValue("@esUsuario", menu.LabelUsuarioValue.Text);
                InsertCliente.ExecuteNonQuery();
                
                MessageBox.Show("Cliente [" + c_tBoxNombre.Text + "] Registrado Exitosamente");
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

        private void vCliente_FormClosed(object sender, FormClosedEventArgs e)
        {

            DialogResult res = BtnRegistrarCliente.DialogResult;
            if (res == DialogResult.OK)
            {
                menu.GetClientes();
                menu.dgvClientes.Refresh();
            }
        }

        private void C_dTpFechaIngreso_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                C_txbTiempoLaborando.Text = DiferenciaFechas(DateTime.Now, C_dTpFechaIngreso.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
