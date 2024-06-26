using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll
{
    public partial class FrmPrincipal : Form
    {
        private readonly ApiClient _apiClient;
        public FrmPrincipal(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            AbrirFormHija(new FrmHome());
        }
        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private void PBCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PBMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panelContenedor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FrmLogin login = new();
            login.Show();
            this.Hide();
        }
        private void AbrirFormHija(object formulario)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formulario as Form;
            fh.TopLevel = false;
            fh.MouseDown += FrmPrincipal_MouseDown;
            fh.Controls.Add(PBCerrar);
            fh.Controls.Add(PBMinimizar);
            PBCerrar.Visible = true;
            PBMinimizar.Visible = true;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
     
        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmHome frmhome = new FrmHome();
            AbrirFormHija(frmhome);
        }
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            subMenuEmpleado.Visible = true;
        }
        private void btnAgregarEmp_Click(object sender, EventArgs e)
        {
            subMenuEmpleado.Visible = false;
            var  frmAggEmp = new FrmAgregarEmpleado(_apiClient);
            PBCerrar.Visible = false;
            PBMinimizar.Visible = false;
            AbrirFormHija(frmAggEmp);
        }
       
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
        }
        private void PBCerrar_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PBMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnEmpleadosNoActivos_Click(object sender, EventArgs e)
        {
            subMenuEmpleado.Visible = false;
        }

       
        private void btnPlanilla_Click(object sender, EventArgs e)
        {
            var frmAggEmp = new FrmPlanilla(_apiClient);
            PBCerrar.Visible = false;
            PBMinimizar.Visible = false;
            AbrirFormHija(frmAggEmp);
        }
    }
}
