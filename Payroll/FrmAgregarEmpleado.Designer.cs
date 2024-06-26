namespace Payroll
{
    partial class FrmAgregarEmpleado
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            txtPrimerNombre = new TextBox();
            txtPrimerApellido = new TextBox();
            pictureBox3 = new PictureBox();
            dtpFechaNac = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            RBHombre = new RadioButton();
            RBMujer = new RadioButton();
            RBSoltero = new RadioButton();
            RBCasado = new RadioButton();
            label4 = new Label();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtCelular = new TextBox();
            label5 = new Label();
            dtpFechaContratacion = new DateTimePicker();
            txtSalarioBase = new TextBox();
            pictureBox11 = new PictureBox();
            btnAgregarEmpleado = new Button();
            pictureBox12 = new PictureBox();
            panel1 = new Panel();
            RBViudo = new RadioButton();
            panel3 = new Panel();
            RBOtro = new RadioButton();
            txtINSS = new MaskedTextBox();
            label6 = new Label();
            txtEmployeeNumber = new TextBox();
            pictureBox10 = new PictureBox();
            label7 = new Label();
            txtNumeroCedula = new MaskedTextBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();
            cbActivo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.Location = new Point(439, 100);
            label1.Name = "label1";
            label1.Size = new Size(196, 24);
            label1.TabIndex = 0;
            label1.Text = "Agregar Empleados";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Loading;
            pictureBox1.Location = new Point(10, 242);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(199, 22);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtPrimerNombre
            // 
            txtPrimerNombre.BackColor = Color.White;
            txtPrimerNombre.BorderStyle = BorderStyle.None;
            txtPrimerNombre.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtPrimerNombre.ForeColor = Color.Black;
            txtPrimerNombre.Location = new Point(41, 217);
            txtPrimerNombre.Name = "txtPrimerNombre";
            txtPrimerNombre.Size = new Size(168, 15);
            txtPrimerNombre.TabIndex = 2;
            txtPrimerNombre.Text = "Primer nombre";
            txtPrimerNombre.Enter += txtPrimerNombre_Enter;
            txtPrimerNombre.Leave += txtPrimerNombre_Leave;
            // 
            // txtPrimerApellido
            // 
            txtPrimerApellido.BackColor = Color.White;
            txtPrimerApellido.BorderStyle = BorderStyle.None;
            txtPrimerApellido.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtPrimerApellido.ForeColor = Color.Black;
            txtPrimerApellido.Location = new Point(288, 217);
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Size = new Size(168, 15);
            txtPrimerApellido.TabIndex = 6;
            txtPrimerApellido.Text = "Primer apellido";
            txtPrimerApellido.Enter += txtPrimerApellido_Enter;
            txtPrimerApellido.Leave += txtPrimerApellido_Leave;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Loading;
            pictureBox3.Location = new Point(258, 242);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(211, 22);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // dtpFechaNac
            // 
            dtpFechaNac.Format = DateTimePickerFormat.Short;
            dtpFechaNac.Location = new Point(212, 353);
            dtpFechaNac.Name = "dtpFechaNac";
            dtpFechaNac.Size = new Size(211, 22);
            dtpFechaNac.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F);
            label2.Location = new Point(212, 328);
            label2.Name = "label2";
            label2.Size = new Size(116, 16);
            label2.TabIndex = 15;
            label2.Text = "Fecha Nacimiento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F);
            label3.Location = new Point(36, 10);
            label3.Name = "label3";
            label3.Size = new Size(58, 18);
            label3.TabIndex = 16;
            label3.Text = "Genero";
            // 
            // RBHombre
            // 
            RBHombre.AutoSize = true;
            RBHombre.Font = new Font("Microsoft Sans Serif", 9.75F);
            RBHombre.Location = new Point(42, 37);
            RBHombre.Name = "RBHombre";
            RBHombre.Size = new Size(74, 20);
            RBHombre.TabIndex = 17;
            RBHombre.TabStop = true;
            RBHombre.Text = "Hombre";
            RBHombre.UseVisualStyleBackColor = true;
            // 
            // RBMujer
            // 
            RBMujer.AutoSize = true;
            RBMujer.Font = new Font("Microsoft Sans Serif", 9.75F);
            RBMujer.Location = new Point(42, 65);
            RBMujer.Name = "RBMujer";
            RBMujer.Size = new Size(58, 20);
            RBMujer.TabIndex = 18;
            RBMujer.TabStop = true;
            RBMujer.Text = "Mujer";
            RBMujer.UseVisualStyleBackColor = true;
            // 
            // RBSoltero
            // 
            RBSoltero.AutoSize = true;
            RBSoltero.Font = new Font("Microsoft Sans Serif", 9.75F);
            RBSoltero.Location = new Point(24, 82);
            RBSoltero.Name = "RBSoltero";
            RBSoltero.Size = new Size(68, 20);
            RBSoltero.TabIndex = 21;
            RBSoltero.TabStop = true;
            RBSoltero.Text = "Soltero";
            RBSoltero.UseVisualStyleBackColor = true;
            // 
            // RBCasado
            // 
            RBCasado.AutoSize = true;
            RBCasado.Font = new Font("Microsoft Sans Serif", 9.75F);
            RBCasado.Location = new Point(24, 53);
            RBCasado.Name = "RBCasado";
            RBCasado.Size = new Size(73, 20);
            RBCasado.TabIndex = 20;
            RBCasado.TabStop = true;
            RBCasado.Text = "Casado";
            RBCasado.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F);
            label4.Location = new Point(24, 17);
            label4.Name = "label4";
            label4.Size = new Size(86, 18);
            label4.TabIndex = 19;
            label4.Text = "Estado Civil";
            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = Color.White;
            txtDireccion.BorderStyle = BorderStyle.None;
            txtDireccion.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtDireccion.ForeColor = Color.Black;
            txtDireccion.Location = new Point(500, 323);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(168, 15);
            txtDireccion.TabIndex = 23;
            txtDireccion.Text = "Dirección";
            txtDireccion.Enter += txtDireccion_Enter;
            txtDireccion.Leave += txtDireccion_Leave;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtTelefono.ForeColor = Color.Black;
            txtTelefono.Location = new Point(697, 328);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(168, 15);
            txtTelefono.TabIndex = 25;
            txtTelefono.Text = "Telefono";
            txtTelefono.Enter += txtTelefono_Enter;
            txtTelefono.Leave += txtTelefono_Leave;
            // 
            // txtCelular
            // 
            txtCelular.BackColor = Color.White;
            txtCelular.BorderStyle = BorderStyle.None;
            txtCelular.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCelular.ForeColor = Color.Black;
            txtCelular.Location = new Point(927, 328);
            txtCelular.Name = "txtCelular";
            txtCelular.Size = new Size(168, 15);
            txtCelular.TabIndex = 27;
            txtCelular.Text = "Celular";
            txtCelular.Enter += txtCelular_Enter;
            txtCelular.Leave += txtCelular_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F);
            label5.Location = new Point(323, 439);
            label5.Name = "label5";
            label5.Size = new Size(158, 18);
            label5.TabIndex = 29;
            label5.Text = "Fecha de Contratación";
            // 
            // dtpFechaContratacion
            // 
            dtpFechaContratacion.Format = DateTimePickerFormat.Short;
            dtpFechaContratacion.Location = new Point(323, 462);
            dtpFechaContratacion.Name = "dtpFechaContratacion";
            dtpFechaContratacion.Size = new Size(211, 22);
            dtpFechaContratacion.TabIndex = 28;
            // 
            // txtSalarioBase
            // 
            txtSalarioBase.BackColor = Color.White;
            txtSalarioBase.BorderStyle = BorderStyle.None;
            txtSalarioBase.Font = new Font("Microsoft Sans Serif", 11.25F);
            txtSalarioBase.ForeColor = Color.Black;
            txtSalarioBase.Location = new Point(578, 441);
            txtSalarioBase.Name = "txtSalarioBase";
            txtSalarioBase.Size = new Size(168, 17);
            txtSalarioBase.TabIndex = 31;
            txtSalarioBase.Text = "Salario Base";
            txtSalarioBase.Enter += txtSalarioBase_Enter;
            txtSalarioBase.Leave += txtSalarioBase_Leave;
            // 
            // pictureBox11
            // 
            pictureBox11.Image = Properties.Resources.empleado;
            pictureBox11.Location = new Point(323, 83);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(88, 71);
            pictureBox11.TabIndex = 38;
            pictureBox11.TabStop = false;
            // 
            // btnAgregarEmpleado
            // 
            btnAgregarEmpleado.BackgroundImage = Properties.Resources.agregar;
            btnAgregarEmpleado.BackgroundImageLayout = ImageLayout.Center;
            btnAgregarEmpleado.FlatAppearance.BorderSize = 0;
            btnAgregarEmpleado.FlatStyle = FlatStyle.Flat;
            btnAgregarEmpleado.Location = new Point(452, 575);
            btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            btnAgregarEmpleado.Size = new Size(97, 52);
            btnAgregarEmpleado.TabIndex = 39;
            btnAgregarEmpleado.UseVisualStyleBackColor = true;
            btnAgregarEmpleado.Click += btnAgregarEmpleado_Click;
            // 
            // pictureBox12
            // 
            pictureBox12.Image = Properties.Resources.Group_39;
            pictureBox12.Location = new Point(-1, -1);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(1123, 56);
            pictureBox12.TabIndex = 40;
            pictureBox12.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(RBViudo);
            panel1.Controls.Add(RBSoltero);
            panel1.Controls.Add(RBCasado);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(169, 430);
            panel1.Name = "panel1";
            panel1.Size = new Size(136, 142);
            panel1.TabIndex = 41;
            // 
            // RBViudo
            // 
            RBViudo.AutoSize = true;
            RBViudo.Font = new Font("Microsoft Sans Serif", 9.75F);
            RBViudo.Location = new Point(24, 110);
            RBViudo.Name = "RBViudo";
            RBViudo.Size = new Size(60, 20);
            RBViudo.TabIndex = 22;
            RBViudo.TabStop = true;
            RBViudo.Text = "Viudo";
            RBViudo.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(RBOtro);
            panel3.Controls.Add(RBMujer);
            panel3.Controls.Add(RBHombre);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(22, 439);
            panel3.Name = "panel3";
            panel3.Size = new Size(128, 133);
            panel3.TabIndex = 43;
            // 
            // RBOtro
            // 
            RBOtro.AutoSize = true;
            RBOtro.Font = new Font("Microsoft Sans Serif", 9.75F);
            RBOtro.Location = new Point(42, 93);
            RBOtro.Name = "RBOtro";
            RBOtro.Size = new Size(50, 20);
            RBOtro.TabIndex = 19;
            RBOtro.TabStop = true;
            RBOtro.Text = "Otro";
            RBOtro.UseVisualStyleBackColor = true;
            // 
            // txtINSS
            // 
            txtINSS.BorderStyle = BorderStyle.None;
            txtINSS.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtINSS.Location = new Point(22, 354);
            txtINSS.Mask = "0000000-0";
            txtINSS.Name = "txtINSS";
            txtINSS.Size = new Size(197, 15);
            txtINSS.TabIndex = 44;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 323);
            label6.Name = "label6";
            label6.Size = new Size(89, 16);
            label6.TabIndex = 45;
            label6.Text = "Numero INSS";
            // 
            // txtEmployeeNumber
            // 
            txtEmployeeNumber.BackColor = Color.White;
            txtEmployeeNumber.BorderStyle = BorderStyle.None;
            txtEmployeeNumber.Font = new Font("Microsoft Sans Serif", 11.25F);
            txtEmployeeNumber.ForeColor = Color.Black;
            txtEmployeeNumber.Location = new Point(697, 217);
            txtEmployeeNumber.Name = "txtEmployeeNumber";
            txtEmployeeNumber.Size = new Size(168, 17);
            txtEmployeeNumber.TabIndex = 47;
            txtEmployeeNumber.Text = "Numero empleado";
            // 
            // pictureBox10
            // 
            pictureBox10.Image = Properties.Resources.Loading;
            pictureBox10.Location = new Point(692, 242);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(211, 22);
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.TabIndex = 46;
            pictureBox10.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(500, 217);
            label7.Name = "label7";
            label7.Size = new Size(118, 16);
            label7.TabIndex = 49;
            label7.Text = "Numero de cedula";
            // 
            // txtNumeroCedula
            // 
            txtNumeroCedula.BorderStyle = BorderStyle.None;
            txtNumeroCedula.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNumeroCedula.Location = new Point(500, 248);
            txtNumeroCedula.Mask = "000-000000-0000L";
            txtNumeroCedula.Name = "txtNumeroCedula";
            txtNumeroCedula.Size = new Size(197, 15);
            txtNumeroCedula.TabIndex = 48;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.Loading;
            pictureBox5.Location = new Point(452, 350);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(211, 22);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 50;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.Loading;
            pictureBox6.Location = new Point(689, 354);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(211, 22);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 51;
            pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.Loading;
            pictureBox7.Location = new Point(906, 354);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(211, 22);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 52;
            pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = Properties.Resources.Loading;
            pictureBox8.Location = new Point(549, 465);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(211, 22);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 53;
            pictureBox8.TabStop = false;
            // 
            // cbActivo
            // 
            cbActivo.AutoSize = true;
            cbActivo.Location = new Point(979, 242);
            cbActivo.Name = "cbActivo";
            cbActivo.Size = new Size(63, 20);
            cbActivo.TabIndex = 54;
            cbActivo.Text = "Activo";
            cbActivo.UseVisualStyleBackColor = true;
            // 
            // FrmAgregarEmpleado
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1115, 623);
            Controls.Add(cbActivo);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(label7);
            Controls.Add(txtNumeroCedula);
            Controls.Add(txtEmployeeNumber);
            Controls.Add(pictureBox10);
            Controls.Add(label6);
            Controls.Add(txtINSS);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(pictureBox12);
            Controls.Add(btnAgregarEmpleado);
            Controls.Add(pictureBox11);
            Controls.Add(txtSalarioBase);
            Controls.Add(label5);
            Controls.Add(dtpFechaContratacion);
            Controls.Add(txtCelular);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(label2);
            Controls.Add(dtpFechaNac);
            Controls.Add(txtPrimerApellido);
            Controls.Add(pictureBox3);
            Controls.Add(txtPrimerNombre);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 9.75F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmAgregarEmpleado";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "FrmAgregarEmpleado";
            Load += FrmAgregarEmpleado_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox txtPrimerNombre;
        private TextBox txtPrimerApellido;
        private PictureBox pictureBox3;
        private DateTimePicker dtpFechaNac;
        private Label label2;
        private Label label3;
        private RadioButton RBHombre;
        private RadioButton RBMujer;
        private RadioButton RBSoltero;
        private RadioButton RBCasado;
        private Label label4;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtCelular;
        private Label label5;
        private DateTimePicker dtpFechaContratacion;
        private TextBox txtSalarioBase;
        private PictureBox pictureBox11;
        private Button btnAgregarEmpleado;
        private PictureBox pictureBox12;
        private Panel panel1;
        private Panel panel3;
        private RadioButton RBViudo;
        private RadioButton RBOtro;
        private MaskedTextBox txtINSS;
        private Label label6;
        private TextBox txtEmployeeNumber;
        private PictureBox pictureBox10;
        private Label label7;
        private MaskedTextBox txtNumeroCedula;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private CheckBox cbActivo;
    }
}