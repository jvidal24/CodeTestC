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
    public partial class Login : Form
    {
        public SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings[@"dataSourceConection"]);
        
        public Login()
        {
            InitializeComponent();
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Close(); sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT * FROM Login WHERE Usuario = '" + tBoxUsuario.Text + "' AND Clave = '" + tBoxContrasena.Text + "'";

                SqlDataReader sqlDread;
                sqlDread = sqlCmd.ExecuteReader();
                if (sqlDread.Read())
                {
                    Menu menu = new Menu();

                    //Administrador
                    if (Convert.ToInt32(sqlDread["IdRol"]) == 1)
                    {
                        MessageBox.Show("Bienvenido Administrativo > " + tBoxUsuario.Text);
                        menu.LabelRolValue.Text = "Administrador";
                    }
                    //Contador
                    if (Convert.ToInt32(sqlDread["IdRol"]) == 2)
                    {
                        menu.CajaToolMenuItem.Enabled = false;
                        MessageBox.Show("Bienvenido Contador > " + tBoxUsuario.Text);
                        menu.LabelRolValue.Text = "Contador";
                    }
                    //Reportero
                    if (Convert.ToInt32(sqlDread["IdRol"]) == 3)
                    {
                        menu.ClientesToolMenuItem.Enabled = false;
                        menu.CajaToolMenuItem.Enabled = false;
                        MessageBox.Show("Bienvenido Reportero > " + tBoxUsuario.Text);
                        menu.LabelRolValue.Text = "Reportero";
                    }

                    //Usuario/Rol
                    menu.LabelUsuarioValue.Text = sqlDread["Usuario"].ToString();
                    
                    this.Hide();
                    menu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Verifiqué la información con Administración", "Atención");
                }

                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ckbox_ViewContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if (Ckbox_ViewContrasena.CheckState == CheckState.Checked)
            {
                tBoxContrasena.UseSystemPasswordChar = false;
            }
            else
            {
                tBoxContrasena.UseSystemPasswordChar = true;
            }
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿ Desea cerrar Login | zPrestman ?",
                       "Salir de Login | zPrestman", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogo == DialogResult.OK) { Application.Exit(); }
            else { e.Cancel = true; }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
