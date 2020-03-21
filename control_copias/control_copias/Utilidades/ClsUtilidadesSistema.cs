using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace control_copias.Utilidades
{
    class ClsUtilidadesSistema
    {
        private static string ClaveSistema = "123";
        public bool ValidarClave(string clave)
        {
            bool ok = false;
            if (clave.Equals(ClaveSistema))
            {
                ok = true;
            }

            return ok;
        }

        ClsMensajes mensajes = new ClsMensajes();
        public void LlenarCbx(ref ComboBox cbx, DataTable data, string textDefault)
        {
            try
            {
                DataRow nueva_filaA = data.NewRow();
                nueva_filaA[data.Columns[0].ColumnName] = "-1";
                nueva_filaA[data.Columns[1].ColumnName] = textDefault;
                data.Rows.InsertAt(nueva_filaA, 0);
                cbx.DataSource = data;
                cbx.ValueMember = data.Columns[0].ColumnName;
                cbx.DisplayMember = data.Columns[1].ColumnName;
            }
            catch (Exception ex)
            {
                mensajes.MostrarError("Error al cargar datos de control. " + ex.Message);
            }

        }
        public bool ValidarSoloNumero(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                return false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidarSoloNumerosConPuntoDecimal(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                return false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                return false;
            }
            else if (e.KeyChar == 46)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
