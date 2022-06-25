
namespace zPrestman.Views
{
    partial class viewsSolicitud
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewsSolicitud));
            this.tBoxBusquedaRapida = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvViewsContainer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewsContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // tBoxBusquedaRapida
            // 
            this.tBoxBusquedaRapida.Location = new System.Drawing.Point(263, 12);
            this.tBoxBusquedaRapida.Name = "tBoxBusquedaRapida";
            this.tBoxBusquedaRapida.Size = new System.Drawing.Size(345, 21);
            this.tBoxBusquedaRapida.TabIndex = 19;
            this.tBoxBusquedaRapida.TextChanged += new System.EventHandler(this.tBoxBusquedaRapida_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(128, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "Busqueda Rápida :";
            // 
            // dgvViewsContainer
            // 
            this.dgvViewsContainer.AllowUserToAddRows = false;
            this.dgvViewsContainer.AllowUserToDeleteRows = false;
            this.dgvViewsContainer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvViewsContainer.Location = new System.Drawing.Point(11, 39);
            this.dgvViewsContainer.Name = "dgvViewsContainer";
            this.dgvViewsContainer.ReadOnly = true;
            this.dgvViewsContainer.RowHeadersVisible = false;
            this.dgvViewsContainer.Size = new System.Drawing.Size(697, 356);
            this.dgvViewsContainer.TabIndex = 17;
            this.dgvViewsContainer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewsContainer_CellClick);
            this.dgvViewsContainer.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvViewsContainer_CellPainting);
            // 
            // viewsSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(719, 407);
            this.Controls.Add(this.tBoxBusquedaRapida);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvViewsContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "viewsSolicitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitudes";
            this.Load += new System.EventHandler(this.viewsSolicitud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewsContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tBoxBusquedaRapida;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.DataGridView dgvViewsContainer;
    }
}