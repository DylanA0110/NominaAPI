namespace Payroll
{
    partial class FrmPlanilla
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
            label9 = new Label();
            panel1 = new Panel();
            tabPage2 = new TabPage();
            dgvNomina = new DataGridView();
            btnLimpiar = new Button();
            btnExportar = new Button();
            dtpFechaFin = new DateTimePicker();
            label13 = new Label();
            panelHorasExtras = new Panel();
            txtHora = new TextBox();
            label3 = new Label();
            dtpFecha = new DateTimePicker();
            label2 = new Label();
            tabPage1 = new TabPage();
            dgvdEmployees = new DataGridView();
            btnSeleccionEmp = new Button();
            btnRegresar = new Button();
            btnBuscar = new Button();
            txtBusqueda = new TextBox();
            label1 = new Label();
            tabNomina = new TabControl();
            btnCalcular = new Button();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNomina).BeginInit();
            panelHorasExtras.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdEmployees).BeginInit();
            tabNomina.SuspendLayout();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(514, 92);
            label9.Name = "label9";
            label9.Size = new Size(100, 15);
            label9.TabIndex = 8;
            label9.Text = "Viatico transporte";
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Group_39;
            panel1.Controls.Add(label9);
            panel1.Location = new Point(-7, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1123, 41);
            panel1.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnCalcular);
            tabPage2.Controls.Add(dgvNomina);
            tabPage2.Controls.Add(btnLimpiar);
            tabPage2.Controls.Add(btnExportar);
            tabPage2.Controls.Add(dtpFechaFin);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(panelHorasExtras);
            tabPage2.Controls.Add(dtpFecha);
            tabPage2.Controls.Add(label2);
            tabPage2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1105, 492);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Nomina";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // dgvNomina
            // 
            dgvNomina.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNomina.Location = new Point(23, 149);
            dgvNomina.Name = "dgvNomina";
            dgvNomina.Size = new Size(1055, 265);
            dgvNomina.TabIndex = 22;
            // 
            // btnLimpiar
            // 
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Image = Properties.Resources.limpiar;
            btnLimpiar.Location = new Point(406, 449);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(97, 34);
            btnLimpiar.TabIndex = 21;
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnExportar
            // 
            btnExportar.FlatAppearance.BorderSize = 0;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Image = Properties.Resources.sobresalir;
            btnExportar.Location = new Point(503, 442);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(88, 41);
            btnExportar.TabIndex = 19;
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.Location = new Point(212, 38);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(179, 21);
            dtpFechaFin.TabIndex = 18;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(212, 6);
            label13.Name = "label13";
            label13.Size = new Size(70, 15);
            label13.TabIndex = 17;
            label13.Text = "Fecha fin:";
            // 
            // panelHorasExtras
            // 
            panelHorasExtras.Controls.Add(txtHora);
            panelHorasExtras.Controls.Add(label3);
            panelHorasExtras.Location = new Point(421, 6);
            panelHorasExtras.Name = "panelHorasExtras";
            panelHorasExtras.Size = new Size(160, 73);
            panelHorasExtras.TabIndex = 4;
            // 
            // txtHora
            // 
            txtHora.Location = new Point(4, 33);
            txtHora.Name = "txtHora";
            txtHora.Size = new Size(153, 21);
            txtHora.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 15);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 3;
            label3.Text = "Horas Extras:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(23, 38);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(160, 21);
            dtpFecha.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 6);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 2;
            label2.Text = "Fecha:";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvdEmployees);
            tabPage1.Controls.Add(btnSeleccionEmp);
            tabPage1.Controls.Add(btnRegresar);
            tabPage1.Controls.Add(btnBuscar);
            tabPage1.Controls.Add(txtBusqueda);
            tabPage1.Controls.Add(label1);
            tabPage1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            tabPage1.ForeColor = Color.Black;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1105, 492);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Empleado";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvdEmployees
            // 
            dgvdEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdEmployees.Location = new Point(37, 288);
            dgvdEmployees.Name = "dgvdEmployees";
            dgvdEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvdEmployees.Size = new Size(1049, 197);
            dgvdEmployees.TabIndex = 58;
            // 
            // btnSeleccionEmp
            // 
            btnSeleccionEmp.FlatAppearance.BorderSize = 0;
            btnSeleccionEmp.FlatAppearance.MouseDownBackColor = Color.FromArgb(96, 60, 220);
            btnSeleccionEmp.FlatAppearance.MouseOverBackColor = Color.FromArgb(96, 60, 220);
            btnSeleccionEmp.FlatStyle = FlatStyle.Flat;
            btnSeleccionEmp.Image = Properties.Resources.editar__1___1_;
            btnSeleccionEmp.Location = new Point(1023, 137);
            btnSeleccionEmp.Name = "btnSeleccionEmp";
            btnSeleccionEmp.Size = new Size(63, 46);
            btnSeleccionEmp.TabIndex = 57;
            btnSeleccionEmp.UseVisualStyleBackColor = true;
            btnSeleccionEmp.Click += btnSeleccionEmp_Click;
            // 
            // btnRegresar
            // 
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.FlatAppearance.MouseDownBackColor = Color.FromArgb(96, 60, 220);
            btnRegresar.FlatAppearance.MouseOverBackColor = Color.FromArgb(96, 60, 220);
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.Location = new Point(338, 111);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(33, 28);
            btnRegresar.TabIndex = 56;
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatAppearance.MouseDownBackColor = Color.FromArgb(96, 60, 220);
            btnBuscar.FlatAppearance.MouseOverBackColor = Color.FromArgb(96, 60, 220);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(299, 111);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(33, 28);
            btnBuscar.TabIndex = 55;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(6, 116);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(287, 22);
            txtBusqueda.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 97);
            label1.Name = "label1";
            label1.Size = new Size(81, 16);
            label1.TabIndex = 1;
            label1.Text = "Busqueda:";
            // 
            // tabNomina
            // 
            tabNomina.Controls.Add(tabPage1);
            tabNomina.Controls.Add(tabPage2);
            tabNomina.Font = new Font("Microsoft Sans Serif", 9F);
            tabNomina.Location = new Point(2, 47);
            tabNomina.Name = "tabNomina";
            tabNomina.SelectedIndex = 0;
            tabNomina.Size = new Size(1113, 520);
            tabNomina.TabIndex = 0;
            tabNomina.Click += tabControl1_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.FlatAppearance.BorderSize = 0;
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.Image = Properties.Resources.calculadora;
            btnCalcular.Location = new Point(303, 452);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(97, 34);
            btnCalcular.TabIndex = 23;
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // FrmPlanilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1115, 559);
            Controls.Add(panel1);
            Controls.Add(tabNomina);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPlanilla";
            Text = "FrmPlanilla";
            Load += FrmPlanilla_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNomina).EndInit();
            panelHorasExtras.ResumeLayout(false);
            panelHorasExtras.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdEmployees).EndInit();
            tabNomina.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label9;
        private TabPage tabPage2;
        private Button btnLimpiar;
        private Button btnExportar;
        private DateTimePicker dtpFechaFin;
        private Label label13;
        private Panel panelHorasExtras;
        private TextBox txtHora;
        private Label label3;
        private DateTimePicker dtpFecha;
        private Label label2;
        private TabPage tabPage1;
        private Button btnSeleccionEmp;
        private Button btnRegresar;
        private Button btnBuscar;
        private TextBox txtBusqueda;
        private Label label1;
        private TabControl tabNomina;
        private DataGridView dgvdEmployees;
        private DataGridView dgvNomina;
        private Button btnCalcular;
    }
}