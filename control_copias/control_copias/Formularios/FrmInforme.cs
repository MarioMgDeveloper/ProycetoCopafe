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
    public partial class FrmInforme : Form
    {
        ClsQuerysFotocopiadora fotocopiadoras = new ClsQuerysFotocopiadora();
        ClsUtilidadesSistema utilidades = new ClsUtilidadesSistema();
        ClsQuerysUsuario usuarios = new ClsQuerysUsuario();
        ClsQuerysRegistro registros = new ClsQuerysRegistro();
        ClsMensajes mensajes = new ClsMensajes();
        ClsUtilidadesExcel excel = new ClsUtilidadesExcel();
        string codFotocopiadora = "";
        string codUsuario = "";
        string codTipo = "";
        string fechaInicio = "";
        string fechaFin = "";
        public FrmInforme()
        {
            InitializeComponent();
        }

        private void FrmInforme_Load(object sender, EventArgs e)
        {
            cargarFotocopiadoras();
            cargarUsuarios();
            cargarTipoRegistro();
        }

        #region Metodos
        private void cargarFotocopiadoras()
        {
            DataTable data = fotocopiadoras.getForCbx();
            utilidades.LlenarCbx(ref cbxFotocopiadoras, data, "---TODAS---");
        }
        private void cargarUsuarios()
        {
            DataTable data = usuarios.getForCbx();
            utilidades.LlenarCbx(ref cbxUsuarios, data, "---TODOS---");
        }
        private void cargarTipoRegistro()
        {
            DataTable data = new DataTable("tipo");
            data.Columns.Add("cod", Type.GetType("System.String"));
            data.Columns.Add("nombre", Type.GetType("System.String"));

            DataRow row1 = data.NewRow();
            row1["cod"] = "1";
            row1["nombre"] = "FOTOCOPIAS";

            DataRow row2 = data.NewRow();
            row2["cod"] = "2";
            row2["nombre"] = "IMPRESIONES A COLOR";

            DataRow row3 = data.NewRow();
            row3["cod"] = "3";
            row3["nombre"] = "IMPRESIONES BLANCO Y NEGRO";

            DataRow row4 = data.NewRow();
            row4["cod"] = "4";
            row4["nombre"] = "ESCANEOS";


            data.Rows.Add(row1);
            data.Rows.Add(row2);
            data.Rows.Add(row3);
            data.Rows.Add(row4);

            utilidades.LlenarCbx(ref cbxRegistro, data, "---TODOS---");


        }
        private void adminChecks()
        {
            FechaInicio.Enabled = chkActInicio.Checked;
            FechaFin.Enabled = chkActFin.Checked;
        }
        private void obtenerContador()
        {
            if (cbxFotocopiadoras.SelectedIndex > 0)
            {
                btnContador.Text = fotocopiadoras.getContadorActual(cbxFotocopiadoras.SelectedValue.ToString());
            }
            else
            {
                btnContador.Text = "";
            }
        }
        private void getFiltros()
        {
            if (cbxFotocopiadoras.SelectedIndex > 0)
            {
                codFotocopiadora = cbxFotocopiadoras.SelectedValue.ToString();
            }
            else
            {
                codFotocopiadora = "";
            }

            if (cbxUsuarios.SelectedIndex > 0)
            {
                codUsuario = cbxUsuarios.SelectedValue.ToString();
            }
            else
            {
                codUsuario = "";
            }

            if (cbxRegistro.SelectedIndex > 0)
            {
                codTipo = cbxRegistro.SelectedValue.ToString();
            }
            else
            {
                codTipo = "";
            }

            if (chkActInicio.Checked)
            {
                fechaInicio = FechaInicio.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                fechaInicio = "";
            }

            if (chkActFin.Checked)
            {
                fechaFin = FechaFin.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                fechaFin = "";
            }
        }
        private void limpiarResultados()
        {
            grdResultados.DataSource = null;
        }
        private void limpiarTodo()
        {
            cbxFotocopiadoras.SelectedIndex = 0;
            cbxUsuarios.SelectedIndex = 0;
            cbxUsuarios.SelectedIndex = 0;

            FechaInicio.Value = DateTime.Now;
            FechaInicio.Value = DateTime.Now;
            chkActFin.Checked = false;
            chkActInicio.Checked = false;
            btnContador.Text = "";

            adminChecks();
            limpiarResultados();
            
        }

        private DataTable getData()
        {
            getFiltros();
            DataTable data = registros.getReporte(codFotocopiadora, codUsuario, codTipo, fechaInicio, fechaFin);
            data.TableName = "Registros";
            return data;
        }
        private void buscar()
        {
            grdResultados.DataSource = getData();

            colorearTotales();
        }
        private void colorearTotales()
        {
            if (grdResultados.Rows.Count > 1)
            {
                int indice = grdResultados.Rows.Count - 2;
                grdResultados.Rows[indice].DefaultCellStyle.BackColor = ClsUtilidadesTema.ColorFilaTotales;
            }
        }
        private string getDefinicionReporte()
        {
            string definicion = "";

            if (cbxFotocopiadoras.SelectedIndex > 0)
            {
                definicion += cbxFotocopiadoras.Text;
            }

            if (cbxUsuarios.SelectedIndex > 0)
            {
                if (definicion.Equals(""))
                {
                    definicion += (cbxUsuarios.Text);
                }
                else
                {
                    definicion += (" - " + cbxUsuarios.Text);
                }

            }

            if (cbxRegistro.SelectedIndex > 0)
            {
                if (definicion.Equals(""))
                {
                    definicion += (cbxRegistro.Text);
                }
                else
                {
                    definicion += (" - " + cbxRegistro.Text);
                }

            }


            if (chkActInicio.Checked)
            {
                if (definicion.Equals(""))
                {
                    definicion += ("del " + FechaInicio.Value.ToString("dd/MM/yyyy"));
                    if (!chkActFin.Checked)
                    {
                        definicion += " - al -----";
                    }
                }
                else
                {
                    definicion += (" - del " + FechaInicio.Value.ToString("dd/MM/yyyy"));
                    if (!chkActFin.Checked)
                    {
                        definicion += " - al -----";
                    }
                }
            }

            if (chkActFin.Checked)
            {
                if (definicion.Equals(""))
                {
                    if (!chkActInicio.Checked)
                    {
                        definicion += " del: -----";
                    }
                    definicion += (" al " + FechaFin.Value.ToString("dd/MM/yyyy"));
                   
                }
                else
                {
                    if (!chkActInicio.Checked)
                    {
                        definicion += " del: -----";
                    }
                    definicion += (" - al " + FechaFin.Value.ToString("dd/MM/yyyy"));
                }
            }


            if (definicion.Equals(""))
            {
                definicion = "---GENERAL---";
            }


            return definicion;



        }

        private void Exportar()
        {
            if(grdResultados.Rows.Count > 1)
            {
                DataTable data = getData();
                excel.ExportarRpExcel(ref data, getDefinicionReporte());
            }
            else
            {
                mensajes.MostrarAdvertencia("Debe realizar una búsqueda para esportar los datos.");
            }
        }
        #endregion

        private void chkActInicio_CheckedChanged(object sender, EventArgs e)
        {
            adminChecks();
            limpiarResultados();
        }

        private void chkActFin_CheckedChanged(object sender, EventArgs e)
        {
            adminChecks();
            limpiarResultados();
        }

        private void cbxFotocopiadoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenerContador();
            limpiarResultados();
        }

        private void FechaInicio_ValueChanged(object sender, EventArgs e)
        {
            limpiarResultados();
        }

        private void FechaFin_ValueChanged(object sender, EventArgs e)
        {
            limpiarResultados();
        }

        private void cbxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarResultados();
        }

        private void cbxRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarResultados();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarTodo();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }
    }
}
