namespace AutoManager.Forms
{
    partial class Form1
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
            this.dataGridViewPersonas = new System.Windows.Forms.DataGridView();
            this.dataGridViewCoches = new System.Windows.Forms.DataGridView();
            this.labelPersonas = new System.Windows.Forms.Label();
            this.labelCoches = new System.Windows.Forms.Label();
            this.labelAsignaciones = new System.Windows.Forms.Label();
            this.btnAgregarPersona = new System.Windows.Forms.Button();
            this.btnEditarPersona = new System.Windows.Forms.Button();
            this.btnEliminarPersona = new System.Windows.Forms.Button();
            this.btnAgregarCoche = new System.Windows.Forms.Button();
            this.btnEditarCoche = new System.Windows.Forms.Button();
            this.btnEliminarCoche = new System.Windows.Forms.Button();
            this.btnCrearAsignacion = new System.Windows.Forms.Button();
            this.btnEditarAsignacion = new System.Windows.Forms.Button();
            this.btnEliminarAsignacion = new System.Windows.Forms.Button();
            this.dataGridViewAsignaciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPersonas
            // 
            this.dataGridViewPersonas.AllowUserToAddRows = false;
            this.dataGridViewPersonas.AllowUserToDeleteRows = false;
            this.dataGridViewPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPersonas.Location = new System.Drawing.Point(12, 29);
            this.dataGridViewPersonas.MultiSelect = false;
            this.dataGridViewPersonas.Name = "dataGridViewPersonas";
            this.dataGridViewPersonas.ReadOnly = true;
            this.dataGridViewPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPersonas.Size = new System.Drawing.Size(400, 150);
            this.dataGridViewPersonas.TabIndex = 0;
            // 
            // dataGridViewCoches
            // 
            this.dataGridViewCoches.AllowUserToAddRows = false;
            this.dataGridViewCoches.AllowUserToDeleteRows = false;
            this.dataGridViewCoches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoches.Location = new System.Drawing.Point(12, 234);
            this.dataGridViewCoches.MultiSelect = false;
            this.dataGridViewCoches.Name = "dataGridViewCoches";
            this.dataGridViewCoches.ReadOnly = true;
            this.dataGridViewCoches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCoches.Size = new System.Drawing.Size(400, 150);
            this.dataGridViewCoches.TabIndex = 1;
            // 
            // labelPersonas
            // 
            this.labelPersonas.AutoSize = true;
            this.labelPersonas.Location = new System.Drawing.Point(12, 9);
            this.labelPersonas.Name = "labelPersonas";
            this.labelPersonas.Size = new System.Drawing.Size(54, 13);
            this.labelPersonas.TabIndex = 2;
            this.labelPersonas.Text = "Personas:";
            // 
            // labelCoches
            // 
            this.labelCoches.AutoSize = true;
            this.labelCoches.Location = new System.Drawing.Point(12, 218);
            this.labelCoches.Name = "labelCoches";
            this.labelCoches.Size = new System.Drawing.Size(48, 13);
            this.labelCoches.TabIndex = 3;
            this.labelCoches.Text = "Coches:";
            // 
            // labelAsignaciones
            // 
            this.labelAsignaciones.AutoSize = true;
            this.labelAsignaciones.Location = new System.Drawing.Point(12, 427);
            this.labelAsignaciones.Name = "labelAsignaciones";
            this.labelAsignaciones.Size = new System.Drawing.Size(75, 13);
            this.labelAsignaciones.TabIndex = 3;
            this.labelAsignaciones.Text = "Asignaciones:";
            // 
            // btnAgregarPersona
            // 
            this.btnAgregarPersona.Location = new System.Drawing.Point(418, 29);
            this.btnAgregarPersona.Name = "btnAgregarPersona";
            this.btnAgregarPersona.Size = new System.Drawing.Size(90, 23);
            this.btnAgregarPersona.TabIndex = 4;
            this.btnAgregarPersona.Text = "Añadir";
            this.btnAgregarPersona.UseVisualStyleBackColor = true;
            this.btnAgregarPersona.Click += new System.EventHandler(this.btnAgregarPersona_Click);
            // 
            // btnEditarPersona
            // 
            this.btnEditarPersona.Location = new System.Drawing.Point(418, 58);
            this.btnEditarPersona.Name = "btnEditarPersona";
            this.btnEditarPersona.Size = new System.Drawing.Size(90, 23);
            this.btnEditarPersona.TabIndex = 5;
            this.btnEditarPersona.Text = "Editar";
            this.btnEditarPersona.UseVisualStyleBackColor = true;
            this.btnEditarPersona.Click += new System.EventHandler(this.btnEditarPersona_Click);
            // 
            // btnEliminarPersona
            // 
            this.btnEliminarPersona.Location = new System.Drawing.Point(418, 87);
            this.btnEliminarPersona.Name = "btnEliminarPersona";
            this.btnEliminarPersona.Size = new System.Drawing.Size(90, 23);
            this.btnEliminarPersona.TabIndex = 6;
            this.btnEliminarPersona.Text = "Eliminar";
            this.btnEliminarPersona.UseVisualStyleBackColor = true;
            this.btnEliminarPersona.Click += new System.EventHandler(this.btnEliminarPersona_Click);
            // 
            // btnAgregarCoche
            // 
            this.btnAgregarCoche.Location = new System.Drawing.Point(418, 234);
            this.btnAgregarCoche.Name = "btnAgregarCoche";
            this.btnAgregarCoche.Size = new System.Drawing.Size(90, 23);
            this.btnAgregarCoche.TabIndex = 7;
            this.btnAgregarCoche.Text = "Añadir";
            this.btnAgregarCoche.UseVisualStyleBackColor = true;
            this.btnAgregarCoche.Click += new System.EventHandler(this.btnAgregarCoche_Click);
            // 
            // btnEditarCoche
            // 
            this.btnEditarCoche.Location = new System.Drawing.Point(418, 263);
            this.btnEditarCoche.Name = "btnEditarCoche";
            this.btnEditarCoche.Size = new System.Drawing.Size(90, 23);
            this.btnEditarCoche.TabIndex = 8;
            this.btnEditarCoche.Text = "Editar";
            this.btnEditarCoche.UseVisualStyleBackColor = true;
            this.btnEditarCoche.Click += new System.EventHandler(this.btnEditarCoche_Click);
            // 
            // btnEliminarCoche
            // 
            this.btnEliminarCoche.Location = new System.Drawing.Point(418, 292);
            this.btnEliminarCoche.Name = "btnEliminarCoche";
            this.btnEliminarCoche.Size = new System.Drawing.Size(90, 23);
            this.btnEliminarCoche.TabIndex = 9;
            this.btnEliminarCoche.Text = "Eliminar";
            this.btnEliminarCoche.UseVisualStyleBackColor = true;
            this.btnEliminarCoche.Click += new System.EventHandler(this.btnEliminarCoche_Click);
            // 
            // btnCrearAsignacion
            // 
            this.btnCrearAsignacion.Location = new System.Drawing.Point(418, 450);
            this.btnCrearAsignacion.Name = "btnCrearAsignacion";
            this.btnCrearAsignacion.Size = new System.Drawing.Size(90, 23);
            this.btnCrearAsignacion.TabIndex = 10;
            this.btnCrearAsignacion.Text = "Asignar";
            this.btnCrearAsignacion.UseVisualStyleBackColor = true;
            this.btnCrearAsignacion.Click += new System.EventHandler(this.btnCrearAsignacion_Click);
            // 
            // btnEditarAsignacion
            // 
            this.btnEditarAsignacion.Location = new System.Drawing.Point(418, 479);
            this.btnEditarAsignacion.Name = "btnEditarAsignacion";
            this.btnEditarAsignacion.Size = new System.Drawing.Size(90, 23);
            this.btnEditarAsignacion.TabIndex = 11;
            this.btnEditarAsignacion.Text = "Editar Asignación";
            this.btnEditarAsignacion.UseVisualStyleBackColor = true;
            this.btnEditarAsignacion.Click += new System.EventHandler(this.btnEditarAsignacion_Click);
            // 
            // btnEliminarAsignacion
            // 
            this.btnEliminarAsignacion.Location = new System.Drawing.Point(418, 508);
            this.btnEliminarAsignacion.Name = "btnEliminarAsignacion";
            this.btnEliminarAsignacion.Size = new System.Drawing.Size(90, 23);
            this.btnEliminarAsignacion.TabIndex = 12;
            this.btnEliminarAsignacion.Text = "Eliminar Asignación"; 
            this.btnEliminarAsignacion.UseVisualStyleBackColor = true;
            this.btnEliminarAsignacion.Click += new System.EventHandler(this.btnEliminarAsignacion_Click); 
            // 
            // dataGridViewAsignaciones
            // 
            this.dataGridViewAsignaciones.AllowUserToAddRows = false;
            this.dataGridViewAsignaciones.AllowUserToDeleteRows = false;
            this.dataGridViewAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAsignaciones.Location = new System.Drawing.Point(12, 447);
            this.dataGridViewAsignaciones.MultiSelect = false;
            this.dataGridViewAsignaciones.Name = "dataGridViewAsignaciones";
            this.dataGridViewAsignaciones.ReadOnly = true;
            this.dataGridViewAsignaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAsignaciones.Size = new System.Drawing.Size(400, 150);
            this.dataGridViewAsignaciones.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 600);
            this.Controls.Add(this.dataGridViewAsignaciones);
            this.Controls.Add(this.btnEditarAsignacion);
            this.Controls.Add(this.btnEliminarAsignacion);
            this.Controls.Add(this.btnEliminarCoche);
            this.Controls.Add(this.btnEditarCoche);
            this.Controls.Add(this.btnAgregarCoche);
            this.Controls.Add(this.btnEliminarPersona);
            this.Controls.Add(this.btnEditarPersona);
            this.Controls.Add(this.btnAgregarPersona);
            this.Controls.Add(this.btnCrearAsignacion);
            this.Controls.Add(this.labelCoches);
            this.Controls.Add(this.labelPersonas);
            this.Controls.Add(this.labelAsignaciones);
            this.Controls.Add(this.dataGridViewCoches);
            this.Controls.Add(this.dataGridViewPersonas);
            this.Name = "Form1";
            this.Text = "AutoManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPersonas;
        private System.Windows.Forms.DataGridView dataGridViewCoches;
        private System.Windows.Forms.Label labelPersonas;
        private System.Windows.Forms.Label labelCoches;
        private System.Windows.Forms.Label labelAsignaciones;
        private System.Windows.Forms.Button btnAgregarPersona;
        private System.Windows.Forms.Button btnEditarPersona;
        private System.Windows.Forms.Button btnEliminarPersona;
        private System.Windows.Forms.Button btnAgregarCoche;
        private System.Windows.Forms.Button btnEditarCoche;
        private System.Windows.Forms.Button btnEliminarCoche;
        private System.Windows.Forms.Button btnCrearAsignacion;
        private System.Windows.Forms.Button btnEditarAsignacion;
        private System.Windows.Forms.Button btnEliminarAsignacion;
        private System.Windows.Forms.DataGridView dataGridViewAsignaciones;
    }
}
