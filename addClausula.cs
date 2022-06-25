using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zPrestman.Views
{
    public partial class addClausula : Form
    {
        private Menu menu;
        public string varClausula;
        public addClausula(Menu m)
        {
            InitializeComponent();
            menu = m;
        }
        private void addClausula_Load(object sender, EventArgs e)
        {
            richTboxClausula.Text = menu.P_richTboxClausula.Text;
        }
        private void BtnGuardarClausula_Click(object sender, EventArgs e)
        {
            varClausula = richTboxClausula.Text;
            //MessageBox.Show(menu.P_richTboxClausula.Text);
            richTboxClausula.ReadOnly = true;
            this.Close();
        }

        private void addClausula_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show(menu.P_richTboxClausula.Text);
        }

        private void richTboxClausula_TextChanged(object sender, EventArgs e)
        {
            //menu.P_richTboxClausula.Text = richTboxClausula.Text;
        }
    }
}
