namespace AutoManager.Forms
{
    partial class EditarAsignacionForm
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
            this.cmbPersonas = new System.Windows.Forms.ComboBox();
            this.labelPersona = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPersonas
            // 
            this.cmbPersonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonas.FormattingEnabled = true;
            this.cmbPersonas.Location = new System.Drawing.Point(100, 25);
            this.cmbPersonas.Name = "cmbPersonas";
            this.cmbPersonas.Size = new System.Drawing.Size(161, 24);
            this.cmbPersonas.TabIndex = 3;
            // 
            // labelPersona
            // 
            this.labelPersona.AutoSize = true;
            this.labelPersona.Location = new System.Drawing.Point(23, 28);
            this.labelPersona.Name = "labelPersona";
            this.labelPersona.Size = new System.Drawing.Size(67, 17);
            this.labelPersona.TabIndex = 0;
            this.labelPersona.Text = "Persona:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(100, 110);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // EditarAsignacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbPersonas);
            this.Controls.Add(this.labelPersona);
            this.Name = "EditarAsignacionForm";
            this.Text = "Editar Asignación";
            this.Load += new System.EventHandler(this.EditarAsignacionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPersonas;
        private System.Windows.Forms.Label labelPersona;
        private System.Windows.Forms.Button btnGuardar;
    }
}
