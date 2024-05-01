namespace AutoManager.Forms
{
    partial class AsignarCochesForm
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
            this.lblSeleccionarPersona = new System.Windows.Forms.Label();
            this.cboPersonas = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarCoche = new System.Windows.Forms.Label();
            this.cboCoches = new System.Windows.Forms.ComboBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSeleccionarPersona
            // 
            this.lblSeleccionarPersona.AutoSize = true;
            this.lblSeleccionarPersona.Location = new System.Drawing.Point(12, 21);
            this.lblSeleccionarPersona.Name = "lblSeleccionarPersona";
            this.lblSeleccionarPersona.Size = new System.Drawing.Size(122, 15);
            this.lblSeleccionarPersona.TabIndex = 0;
            this.lblSeleccionarPersona.Text = "Seleccionar Persona:";
            // 
            // cboPersonas
            // 
            this.cboPersonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonas.FormattingEnabled = true;
            this.cboPersonas.Location = new System.Drawing.Point(140, 18);
            this.cboPersonas.Name = "cboPersonas";
            this.cboPersonas.Size = new System.Drawing.Size(200, 23);
            this.cboPersonas.TabIndex = 1;
            // 
            // lblSeleccionarCoche
            // 
            this.lblSeleccionarCoche.AutoSize = true;
            this.lblSeleccionarCoche.Location = new System.Drawing.Point(12, 63);
            this.lblSeleccionarCoche.Name = "lblSeleccionarCoche";
            this.lblSeleccionarCoche.Size = new System.Drawing.Size(110, 15);
            this.lblSeleccionarCoche.TabIndex = 2;
            this.lblSeleccionarCoche.Text = "Seleccionar Coche:";
            // 
            // cboCoches
            // 
            this.cboCoches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoches.FormattingEnabled = true;
            this.cboCoches.Location = new System.Drawing.Point(140, 60);
            this.cboCoches.Name = "cboCoches";
            this.cboCoches.Size = new System.Drawing.Size(200, 23);
            this.cboCoches.TabIndex = 3;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(140, 101);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(75, 23);
            this.btnAsignar.TabIndex = 4;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // AsignarCochesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 146);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.cboCoches);
            this.Controls.Add(this.lblSeleccionarCoche);
            this.Controls.Add(this.cboPersonas);
            this.Controls.Add(this.lblSeleccionarPersona);
            this.Name = "AsignarCochesForm";
            this.Text = "Asignar Coches a Persona";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeleccionarPersona;
        private System.Windows.Forms.ComboBox cboPersonas;
        private System.Windows.Forms.Label lblSeleccionarCoche;
        private System.Windows.Forms.ComboBox cboCoches;
        private System.Windows.Forms.Button btnAsignar;
    }
}
