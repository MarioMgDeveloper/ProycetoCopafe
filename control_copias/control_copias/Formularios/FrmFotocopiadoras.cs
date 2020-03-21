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
    public partial class FrmFotocopiadoras : Form
    {
        ClsUtilidadesSistema sistema = new ClsUtilidadesSistema();
        ClsMensajes mensajes = new ClsMensajes();
        ClsQuerysFotocopiadora fotocopiadora = new ClsQuerysFotocopiadora();
        string CodFotocopiadora = "";
        
        public FrmFotocopiadoras()
        {
            InitializeComponent();
        }

        private void FrmFotocopiadoras_Load(object sender, EventArgs e)
        {
            //btnGuardar.BackColor = ClsUtilidadesTema.GetColor("Fotocopiadoras");
            //btnCancelar.BackColor = ClsUtilidadesTema.GetColor("Fotocopiadoras");

            //btnGuardar.IconColor = Color.White;
            //btnGuardar.ForeColor = Color.White;

            //btnCancelar.IconColor = Color.White;
            //btnCancelar.ForeColor = Color.White;
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

        private bool ValidarGuardar()
        {
            bool ok = false;
            if (!txtNombre.Text.Trim().Equals(""))
            {
                if (!txtContador.Text.Trim().Equals(""))
                {
                    if (fotocopiadora.getCantidad() < 5)
                    {
                        ok = true;
                    }
                    else
                    {
                        mensajes.MostrarError("Ha llegado al límite permitido (5)");
                    }
                }
                else
                {
                    mensajes.MostrarAdvertencia("El campo Contador, es obligatorio.");
                }

            }
            else
            {
                mensajes.MostrarAdvertencia("El campo Nombre, es obligatorio.");
            }

            return ok;
        }

        private void LimpiarResultados()
        {
            grdFotocopiadoras.DataSource = null;
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtContador.Text = "";
            txtDescripcion.Text = "";
            CodFotocopiadora = "";

            LimpiarResultados();

            btnGuardar.Text = "Guardar";
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
        }
        private List<string> getParametros()
        {
            List<string> parametros = new List<string>();

            parametros.Add(txtNombre.Text.ToUpper());
            parametros.Add(txtContador.Text);
            parametros.Add(txtDescripcion.Text.ToUpper());

            return parametros;
        }

        private List<string> getParametrosModificar()
        {
            List<string> parametros = new List<string>();

            parametros.Add(txtNombre.Text.ToUpper() + ";asignar");
            parametros.Add(txtContador.Text + ";asignar");
            parametros.Add(txtDescripcion.Text.ToUpper() + ";asignar");
            parametros.Add(CodFotocopiadora + ";comparar");
            return parametros;
        }
        private void CargarGrid()
        {
            DataTable data = fotocopiadora.getAll();

            grdFotocopiadoras.DataSource = data;
        }
        private void Guardar()
        {
            if (ValidarGuardar())
            {
                bool confirmar = mensajes.MostrarConfirmacion("Agregará un registro con la siguiente información:\n\n" +
                    "Nombre: " + txtNombre.Text + "\nContador: " + txtContador.Text + "\n¿Desea continuar?");

                if (confirmar)
                {
                    string result = fotocopiadora.InsertFotocopiadora(getParametros());

                    if (result.Equals(""))
                    {
                        Limpiar();
                        CargarGrid();
                    }
                    else
                    {
                        mensajes.MostrarError("El registro no fue guardado.\n" + result);
                    }
                }
            }
        }
        private bool ValidarModificar()
        {
            bool ok = false;
            if (!txtNombre.Text.Trim().Equals(""))
            {
                if (!txtContador.Text.Trim().Equals(""))
                {
                    ok = true;
                }
                else
                {
                    mensajes.MostrarAdvertencia("El campo Contador, es obligatorio.");
                }

            }
            else
            {
                mensajes.MostrarAdvertencia("El campo Nombre, es obligatorio.");
            }

            return ok;
        }
        private void CargarModificar(int index)
        {
            txtNombre.Text = grdFotocopiadoras.Rows[index].Cells[1].Value.ToString();
            txtContador.Text = grdFotocopiadoras.Rows[index].Cells[2].Value.ToString();
            txtDescripcion.Text = grdFotocopiadoras.Rows[index].Cells[3].Value.ToString();

            CodFotocopiadora = grdFotocopiadoras.Rows[index].Cells[0].Value.ToString();

            btnGuardar.Text = "Modificar";
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Edit;
        }

        private void DeterminarGuardarModificar()
        {
            if (btnGuardar.Text.Equals("Guardar"))
            {
                Guardar();
            }
            else
            {
                Modificar();
            }
        }

        private void Modificar()
        {
            if (ValidarModificar())
            {
                bool confirmar = mensajes.MostrarConfirmacion("Modificará un registro con la siguiente información:\n\n" +
                    "Nombre: " + txtNombre.Text + "\nContador: " + txtContador.Text + "\n¿Desea continuar?");

                if (confirmar)
                {
                    string result = fotocopiadora.UpdateFotocopiadora(getParametrosModificar());

                    if (result.Equals(""))
                    {
                        Limpiar();
                        CargarGrid();
                    }
                    else
                    {
                        mensajes.MostrarError("El registro no fue modificado.\n" + result);
                    }
                }
            }
        }
        #endregion

        private void BtnOkClave_Click(object sender, EventArgs e)
        {
            ValidaClave();   
        }
        private void txtContador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = sistema.ValidarSoloNumero(e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DeterminarGuardarModificar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            CargarGrid();
        }

        private void grdFotocopiadoras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarModificar(e.RowIndex);
        }

        
    }
}
