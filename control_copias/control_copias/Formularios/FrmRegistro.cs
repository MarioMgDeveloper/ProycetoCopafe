using control_copias.Querys;
using control_copias.Utilidades;
using FontAwesome.Sharp;
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
    public partial class FrmRegistro : Form
    {
        ClsUtilidadesSistema sistema = new ClsUtilidadesSistema();
        ClsMensajes mensajes = new ClsMensajes();
        ClsQuerysFotocopiadora fotocopiadora = new ClsQuerysFotocopiadora();
        ClsQuerysUsuario usuario = new ClsQuerysUsuario();
        ClsQuerysRegistro registro = new ClsQuerysRegistro();
        private string CodFotocopiadora = "";
        private string NombreFotocopiadora = "";
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            CargarInfoBotones();
        }

        #region Metodos
        private void CargarInfoBotones()
        {
            DataTable data = fotocopiadora.getForButtons();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                int NoBtn = i + 1;
                DataRow row = data.Rows[i];
                switch (NoBtn)
                {
                    case 1:
                        btnFotocopiadora1.Text = row["nombre"].ToString();
                        txtDescripcion1.Text = row["descripcion"].ToString();
                        CodigoFotocopiadora1.Text = row["cod_fotocopiadora"].ToString();
                        break;

                    case 2:
                        btnFotocopiadora2.Text = row["nombre"].ToString();
                        txtDescripcion2.Text = row["descripcion"].ToString();
                        CodigoFotocopiadora2.Text = row["cod_fotocopiadora"].ToString();
                        break;

                    case 3:
                        btnFotocopiadora3.Text = row["nombre"].ToString();
                        txtDescripcion3.Text = row["descripcion"].ToString();
                        CodigoFotocopiadora3.Text = row["cod_fotocopiadora"].ToString();
                        break;

                    case 4:
                        btnFotocopiadora4.Text = row["nombre"].ToString();
                        txtDescripcion4.Text = row["descripcion"].ToString();
                        CodigoFotocopiadora4.Text = row["cod_fotocopiadora"].ToString();
                        break;

                    case 5:
                        btnFotocopiadora5.Text = row["nombre"].ToString();
                        txtDescripcion5.Text = row["descripcion"].ToString();
                        CodigoFotocopiadora5.Text = row["cod_fotocopiadora"].ToString();
                        break;

                    default: break;
                }
            }
        }
        private void CargarInfoClickBtn(object sender)
        {
            IconButton btn = (IconButton)sender;

            NombreFotocopiadora = btn.Text;
            txtFotocopiadoraSeleccionada.Text = NombreFotocopiadora;

            switch (btn.Name)
            {
                case "btnFotocopiadora1":
                    CodFotocopiadora = CodigoFotocopiadora1.Text;
                    break;
                case "btnFotocopiadora2":
                    CodFotocopiadora = CodigoFotocopiadora2.Text;
                    break;
                case "btnFotocopiadora3":
                    CodFotocopiadora = CodigoFotocopiadora3.Text;
                    break;
                case "btnFotocopiadora4":
                    CodFotocopiadora = CodigoFotocopiadora4.Text;
                    break;
                case "btnFotocopiadora5":
                    CodFotocopiadora = CodigoFotocopiadora5.Text;
                    break;
                default: break;
            }
        }
        private void VerificarCodigo()
        {
            if (!txtUsuario.Text.Trim().Equals(""))
            {
                int exist = usuario.ExistCod(txtUsuario.Text.Trim().ToUpper());

                if (exist == 0)
                {
                    mensajes.MostrarError("El usuario ingresado no existe.");
                    txtUsuario.Text = "";
                    txtUsuario.Focus();
                }
            }
        }
        private void adminCheck()
        {
            txtPrecio.Enabled = chkActPrecio.Checked;
            txtPrecio.ReadOnly = !chkActPrecio.Checked;
        }
        private void DetrminarPrecio()
        {
            if (!txtCantidad.Text.Trim().Equals(""))
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                if (rbtFotocopias.Checked)
                {
                    if (cantidad <= 24)
                    {
                        txtPrecio.Text = "0.25";
                    }
                    else if (cantidad >= 25 && cantidad <= 99)
                    {
                        txtPrecio.Text = "0.20";
                    }
                    else if (cantidad >= 100)
                    {
                        txtPrecio.Text = "0.15";
                    }
                }
                else if (rbtColor.Checked)
                {
                    txtPrecio.Text = "1.00";
                }
                else if (rbtByN.Checked)
                {
                    txtPrecio.Text = "0.50";
                }
                else if (rbtEscaneo.Checked)
                {
                    txtPrecio.Text = "0.50";
                }

            }
            else
            {
                txtPrecio.Text = "";
            }
        }
        private string GetDefectuosas()
        {
            string defectuosas = "";
            if (txtDefectuosas.Text.Trim().Equals(""))
            {
                defectuosas = "0";
            }
            else
            {
                defectuosas = txtDefectuosas.Text;
            }

            return defectuosas;
        }
        private string getTipoRegistro()
        {
            string tipoRegistro = "";

            if (rbtColor.Checked)
            {
                tipoRegistro = rbtColor.Text;
            }
            else if (rbtByN.Checked)
            {
                tipoRegistro = rbtByN.Text;
            }
            else if (rbtFotocopias.Checked)
            {
                tipoRegistro = rbtFotocopias.Text;
            }
            else if (rbtEscaneo.Checked)
            {
                tipoRegistro = rbtEscaneo.Text;
            }

            return tipoRegistro;
        }
        private bool validarGuardar()
        {
            bool ok = false;

            if (!txtFotocopiadoraSeleccionada.Text.Equals(""))
            {
                if (!txtUsuario.Text.Trim().Equals(""))
                {
                    if (!txtCantidad.Text.Trim().Equals(""))
                    {
                        if (!txtPrecio.Text.Trim().Equals(""))
                        {
                            if (!rbtFotocopias.Checked && !rbtColor.Checked && !rbtByN.Checked && !rbtEscaneo.Checked)
                            {
                                mensajes.MostrarAdvertencia("Seleccione un tipo de registro.");
                            }
                            else
                            {
                                ok = true;
                            }
                        }
                        else
                        {
                            mensajes.MostrarAdvertencia("El campo Precio c/u, no puede quedar vacio.");
                        }
                    }
                    else
                    {
                        mensajes.MostrarAdvertencia("El campo Cantidad, no puede quedar vacio.");
                    }
                }
                else
                {
                    mensajes.MostrarAdvertencia("El campo Usuario, no puede quedar vacio..");
                }

            }
            else
            {
                mensajes.MostrarAdvertencia("Seleccione un fotocopiadora.");
            }

            return ok;
        }
        private void Guardar()
        {
            if (validarGuardar())
            {
                bool Confirm = mensajes.MostrarConfirmacion("Agregará un registro con la siguiente información. \n\n Impresora: " + NombreFotocopiadora + "\n Tipo registro: " + getTipoRegistro() + ".\n Cantidad: "
                    + txtCantidad.Text + "\n Defectuosas: " + GetDefectuosas() + "\n Precio: " + txtPrecio.Text + "\n\n La información no podrá ser editada. ¿Desea continuar?");

                if (Confirm)
                {
                    string result = registro.InsertRegistro(getParametros());

                    if (result.Equals(""))
                    {
                        limpiar();
                        mensajes.MostrarInformacion("Registro guardado.");
                    }
                    else
                    {
                        mensajes.MostrarError("Registro no guardado.\n" + result);
                    }
                }
            }
        }
        private void limpiar()
        {
            NombreFotocopiadora = "";
            CodFotocopiadora = "";

            txtFotocopiadoraSeleccionada.Text = "";
            txtUsuario.Text = "";
            txtCantidad.Text = "";
            txtDefectuosas.Text = "";
            txtPrecio.Text = "";
            txtObservaciones.Text = "";
            fecha.Value = DateTime.Now;

            chkActPrecio.Checked = false;
            rbtFotocopias.Checked = false;
            rbtColor.Checked = false;
            rbtEscaneo.Checked = false;
            rbtByN.Checked = false;

            adminCheck();
        }
        private List<string> getParametros()
        {
            List<string> parametros = new List<string>();

            parametros.Add(CodFotocopiadora);
            parametros.Add(txtUsuario.Text.Trim().ToUpper());
            string date = fecha.Value.ToString("dd/MM/yyyy");
            parametros.Add(date);
            parametros.Add(getCodTipoRegistro());
            parametros.Add(txtCantidad.Text);
            parametros.Add(GetDefectuosas());
            parametros.Add(txtPrecio.Text);
            parametros.Add(txtObservaciones.Text);

            return parametros;
        }
        private string getCodTipoRegistro()
        {
            string tipoRegistro = "";

            if (rbtFotocopias.Checked)
            {
                tipoRegistro = "1";
            }
            else if (rbtColor.Checked)
            {
                tipoRegistro = "2";
            }
            else if (rbtByN.Checked)
            {
                tipoRegistro = "3";
            }
            else if (rbtEscaneo.Checked)
            {
                tipoRegistro = "4";
            }

            return tipoRegistro;
        }
        #endregion

        private void btnFotocopiadora1_Click(object sender, EventArgs e)
        {
            CargarInfoClickBtn(sender);
        }

        private void btnFotocopiadora2_Click(object sender, EventArgs e)
        {
            CargarInfoClickBtn(sender);
        }

        private void btnFotocopiadora3_Click(object sender, EventArgs e)
        {
            CargarInfoClickBtn(sender);
        }

        private void btnFotocopiadora4_Click(object sender, EventArgs e)
        {
            CargarInfoClickBtn(sender);
        }

        private void btnFotocopiadora5_Click(object sender, EventArgs e)
        {
            CargarInfoClickBtn(sender);
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            VerificarCodigo();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = sistema.ValidarSoloNumerosConPuntoDecimal(e);
        }

        private void txtDefectuosas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = sistema.ValidarSoloNumerosConPuntoDecimal(e);
        }

        private void chkActPrecio_CheckedChanged(object sender, EventArgs e)
        {
            adminCheck();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            DetrminarPrecio();
        }

        private void rbtColor_CheckedChanged(object sender, EventArgs e)
        {
            DetrminarPrecio();
        }

        private void rbtByN_CheckedChanged(object sender, EventArgs e)
        {
            DetrminarPrecio();
        }

        private void rbtFotocopias_CheckedChanged(object sender, EventArgs e)
        {
            DetrminarPrecio();
        }

        private void rbtEscaneo_CheckedChanged(object sender, EventArgs e)
        {
            DetrminarPrecio();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
