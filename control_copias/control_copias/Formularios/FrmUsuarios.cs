using control_copias.Querys;
using control_copias.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace control_copias.Formularios
{
    public partial class FrmUsuarios : Form
    {
        ClsUtilidadesSistema sistema = new ClsUtilidadesSistema();
        ClsMensajes mensajes = new ClsMensajes();
        ClsQuerysUsuario usuarios = new ClsQuerysUsuario();
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        #region Metodos
        private void ValidaClave()
        {
            if (!txtClave.Text.Trim().Equals(""))
            {
                if (sistema.ValidarClave(txtClave.Text))
                {
                    PanelClave.Visible = false;
                    PanelControles.Visible = true;
                    CargarGrid();
                }
            }
        }
        private string GenerarCodigo()
        {
            int codInt = usuarios.getNextCod();

            string LetraNombre = txtApellidos.Text.Substring(0, 1).ToUpper();
            string LetraApellido = txtNombres.Text.Substring(0, 1).ToUpper();

            string codigo = LetraNombre + LetraApellido + codInt.ToString();

            return codigo;
        }
        private void ValidarGeneraCodigo()
        {
            if (!txtApellidos.Text.Trim().Equals("") && !txtNombres.Text.Trim().Equals(""))
            {
                txtCodigo.Text = GenerarCodigo();
            }
            else
            {
                txtCodigo.Text = "";
            }
        }
        private void CargarGrid()
        {
            DataTable data = usuarios.getUsuarios();

            grdUsuarios.DataSource = data;
        }
        private bool ValidarAgregar()
        {
            bool ok = false;

            if (!txtApellidos.Text.Trim().Equals(""))
            {
                if (!txtNombres.Text.Trim().Equals(""))
                {
                    ok = true;
                }
                else
                {
                    mensajes.MostrarAdvertencia("El campo Apellidos, es obligatorio");
                }
            }
            else
            {
                mensajes.MostrarAdvertencia("El campo Nombres,es obligatorio");
            }

            return ok;
        }
        private List<string> getParametros()
        {
            List<string> parametros = new List<string>();
            parametros.Add(txtCodigo.Text);
            parametros.Add(txtNombres.Text.ToUpper());
            parametros.Add(txtApellidos.Text.ToUpper());

            return parametros;
        }
        private void Agregar()
        {

            bool Confirm = mensajes.MostrarConfirmacion("Agregará un usuario con la siguente información.\n Nombres: " + txtNombres.Text + ".\n Apellidos: " + txtApellidos.Text + ".\n La información no podrá ser modificada. ¿Desea continuar?");

            if (Confirm)
            {
                string result = usuarios.InsertUsuario(getParametros());

                if (result.Equals(""))
                {
                    limpiar();
                    CargarGrid();
                }
                else
                {
                    mensajes.MostrarError("El usuario no fue agregado. \n" + result);
                }
            }
        }
        private void limpiar()
        {
            txtCodigo.Text = "";
            txtApellidos.Text = "";
            txtNombres.Text = "";

            grdUsuarios.DataSource = null;
        }
        #endregion
        private void BtnOkClave_Click(object sender, EventArgs e)
        {
            ValidaClave();
        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            ValidarGeneraCodigo();
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            ValidarGeneraCodigo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarAgregar())
            {
                Agregar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            CargarGrid();
        }
    }
}
