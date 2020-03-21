using control_copias.Utilidades;
using FontAwesome.Sharp;
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

namespace control_copias.Formularios
{
    public partial class MasterPage : Form
    {
        IconButton botonSeleccionado;
        Panel leftPanel;
        private Form formSeleccionado;
        public MasterPage()
        {
            InitializeComponent();
            //iniciamos el panel de borde izquierdo
            leftPanel = new Panel();
            leftPanel.Size = new Size(7, 60);
            PanelMenu.Controls.Add(leftPanel);

            //form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

     

        private void ActivarBoton(object sender)
        {
            if (sender != null)
            {
                DesactivarBoton();
                botonSeleccionado = (IconButton)sender;
                botonSeleccionado.BackColor = ClsUtilidadesTema.GetColor(botonSeleccionado.Text);
                botonSeleccionado.TextAlign = ContentAlignment.MiddleCenter;
                botonSeleccionado.TextImageRelation = TextImageRelation.TextBeforeImage;
                botonSeleccionado.ImageAlign = ContentAlignment.MiddleRight;

                IconBtnSeleccionado.IconChar = botonSeleccionado.IconChar;
                lblTitulo.Text = botonSeleccionado.Text;
                PanelTitulo.BackColor = ClsUtilidadesTema.GetColor(botonSeleccionado.Text);
                PanelSombra.BackColor = ClsUtilidadesTema.GetColorSombra(botonSeleccionado.Text);
                PanelSombra.Visible = true;
                //left border
                leftPanel.BackColor = ClsUtilidadesTema.ForeColorDefault;
                leftPanel.Location = new Point(0, botonSeleccionado.Location.Y);
                leftPanel.Visible = true;
                leftPanel.BringToFront();
            }
        }

        private void AbrirFormInicio(Form childForm)
        {
            if (formSeleccionado != null)
            {
                formSeleccionado.Close();
            }
            DesactivarBoton();
            formSeleccionado = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(childForm);
            this.PanelContenedor.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void DesactivarBoton()
        {
            if (botonSeleccionado != null)
            {
                botonSeleccionado.BackColor = ClsUtilidadesTema.BackColorDefault;
                botonSeleccionado.TextAlign = ContentAlignment.MiddleLeft;
                botonSeleccionado.TextImageRelation = TextImageRelation.ImageBeforeText;
                botonSeleccionado.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void Reset()
        {
            DesactivarBoton();
            leftPanel.Visible = false;
            IconBtnSeleccionado.IconChar = IconChar.Home;
            lblTitulo.Text = "Inicio";
            PanelTitulo.BackColor = ClsUtilidadesTema.BackColorDefault;
            PanelSombra.Visible = false;
        }

        private void btnFotocopiadoras_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormularioHijo(new Formularios.FrmFotocopiadoras(), sender);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormularioHijo(new Formularios.FrmUsuarios(), sender);
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormularioHijo(new Formularios.FrmRegistro(), sender);
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormularioHijo(new Formularios.FrmInforme(), sender);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Reset();
            AbrirFormInicio(new Formularios.FrmInicio());
        }

        //drag form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormularioHijo(Form childForm, object btnSender)
        {
            if (formSeleccionado != null)
            {
                formSeleccionado.Close();
            }

            ActivarBoton(btnSender);
            formSeleccionado = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(childForm);
            this.PanelContenedor.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MasterPage_Load(object sender, EventArgs e)
        {
            AbrirFormInicio(new Formularios.FrmInicio());
        }
    }
}
