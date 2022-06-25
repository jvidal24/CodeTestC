
namespace zPrestman.Views
{
    partial class addClausula
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
            this.richTboxClausula = new System.Windows.Forms.RichTextBox();
            this.BtnGuardarClausula = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTboxClausula
            // 
            this.richTboxClausula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTboxClausula.ForeColor = System.Drawing.Color.Navy;
            this.richTboxClausula.Location = new System.Drawing.Point(12, 12);
            this.richTboxClausula.Name = "richTboxClausula";
            this.richTboxClausula.Size = new System.Drawing.Size(363, 189);
            this.richTboxClausula.TabIndex = 0;
            this.richTboxClausula.Text = "";
            this.richTboxClausula.TextChanged += new System.EventHandler(this.richTboxClausula_TextChanged);
            // 
            // BtnGuardarClausula
            // 
            this.BtnGuardarClausula.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnGuardarClausula.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnGuardarClausula.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnGuardarClausula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardarClausula.ForeColor = System.Drawing.Color.White;
            this.BtnGuardarClausula.Image = global::zPrestman.Properties.Resources.add_clausula_24px;
            this.BtnGuardarClausula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardarClausula.Location = new System.Drawing.Point(105, 216);
            this.BtnGuardarClausula.Name = "BtnGuardarClausula";
            this.BtnGuardarClausula.Size = new System.Drawing.Size(160, 38);
            this.BtnGuardarClausula.TabIndex = 79;
            this.BtnGuardarClausula.Text = "Guardar Claúsula ";
            this.BtnGuardarClausula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardarClausula.UseVisualStyleBackColor = false;
            this.BtnGuardarClausula.Click += new System.EventHandler(this.BtnGuardarClausula_Click);
            // 
            // addClausula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(387, 266);
            this.Controls.Add(this.BtnGuardarClausula);
            this.Controls.Add(this.richTboxClausula);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "addClausula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Claúsula";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.addClausula_FormClosed);
            this.Load += new System.EventHandler(this.addClausula_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button BtnGuardarClausula;
        public System.Windows.Forms.RichTextBox richTboxClausula;
    }
}