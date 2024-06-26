namespace UIPayroll
{
    partial class FrmLogin
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
            pictureBox1 = new PictureBox();
            txtUser = new TextBox();
            pictureBox2 = new PictureBox();
            txtPass = new TextBox();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            btnLogin = new Button();
            linkRegistro = new LinkLabel();
            PBCerrar = new PictureBox();
            PBMinimizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBMinimizar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Dashboard_Login;
            pictureBox1.Location = new Point(52, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(641, 277);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // txtUser
            // 
            txtUser.BackColor = Color.FromArgb(33, 72, 193);
            txtUser.BorderStyle = BorderStyle.None;
            txtUser.Font = new Font("Microsoft Sans Serif", 12F);
            txtUser.ForeColor = Color.WhiteSmoke;
            txtUser.Location = new Point(203, 98);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(342, 19);
            txtUser.TabIndex = 1;
            txtUser.Text = "Usuario";
            txtUser.Enter += txtUser_Enter;
            txtUser.Leave += txtUser_Leave;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(33, 72, 193);
            pictureBox2.Enabled = false;
            pictureBox2.Location = new Point(203, 124);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(391, 10);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // txtPass
            // 
            txtPass.BackColor = Color.FromArgb(33, 72, 193);
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.Font = new Font("Microsoft Sans Serif", 12F);
            txtPass.ForeColor = Color.WhiteSmoke;
            txtPass.Location = new Point(203, 156);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(342, 19);
            txtPass.TabIndex = 2;
            txtPass.Text = "Contraseña";
            txtPass.Enter += txtPass_Enter;
            txtPass.Leave += txtPass_Leave;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(33, 72, 193);
            pictureBox3.Enabled = false;
            pictureBox3.Location = new Point(203, 182);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(391, 10);
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(33, 72, 193);
            label1.Font = new Font("Microsoft Sans Serif", 15.75F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(361, 58);
            label1.Name = "label1";
            label1.Size = new Size(76, 25);
            label1.TabIndex = 5;
            label1.Text = "LOGIN";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(40, 40, 40);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Microsoft Sans Serif", 9F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(203, 211);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(391, 30);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Acceder";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // linkRegistro
            // 
            linkRegistro.ActiveLinkColor = Color.White;
            linkRegistro.AutoSize = true;
            linkRegistro.BackColor = Color.FromArgb(33, 72, 193);
            linkRegistro.ForeColor = Color.White;
            linkRegistro.LinkColor = Color.FromArgb(40, 40, 40);
            linkRegistro.Location = new Point(302, 264);
            linkRegistro.Name = "linkRegistro";
            linkRegistro.Size = new Size(203, 15);
            linkRegistro.TabIndex = 0;
            linkRegistro.TabStop = true;
            linkRegistro.Text = "¿Aún no te has registrado? Click Aquí";
            linkRegistro.VisitedLinkColor = Color.White;
            linkRegistro.LinkClicked += linkRegistro_LinkClicked;
            // 
            // PBCerrar
            // 
            PBCerrar.Image = Properties.Resources.cerrar;
            PBCerrar.Location = new Point(712, 7);
            PBCerrar.Name = "PBCerrar";
            PBCerrar.Size = new Size(32, 27);
            PBCerrar.TabIndex = 8;
            PBCerrar.TabStop = false;
            PBCerrar.Click += PBCerrar_Click;
            // 
            // PBMinimizar
            // 
            PBMinimizar.Image = Properties.Resources.minimizar_signo;
            PBMinimizar.Location = new Point(660, 7);
            PBMinimizar.Name = "PBMinimizar";
            PBMinimizar.Size = new Size(33, 27);
            PBMinimizar.TabIndex = 9;
            PBMinimizar.TabStop = false;
            PBMinimizar.Click += PBMinimizar_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(744, 348);
            Controls.Add(PBMinimizar);
            Controls.Add(PBCerrar);
            Controls.Add(linkRegistro);
            Controls.Add(btnLogin);
            Controls.Add(label1);
            Controls.Add(txtPass);
            Controls.Add(pictureBox3);
            Controls.Add(txtUser);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmLogin";
            Load += FrmLogin_Load;
            MouseDown += FrmLogin_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private TextBox txtUser;
        private PictureBox pictureBox2;
        private TextBox txtPass;
        private PictureBox pictureBox3;
        private Label label1;
        private Button btnLogin;
        private LinkLabel linkRegistro;
        private PictureBox PBCerrar;
        private PictureBox PBMinimizar;
    }
}