using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace control_copias.Utilidades
{
    class ClsUtilidadesSistema
    {
        private string getFileConfigDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "config_directory.txt";
        }
        public string getDirectoryArchivosConfiguracion()
        {
            string pathDirectory = "";
            using (StreamReader lector = new StreamReader(getFileConfigDirectory()))
            {
                
                pathDirectory = lector.ReadLine();
            }

            return pathDirectory;
        }

        public string getClave()
        {
            string clave = "";
            string directorioPassword = getDirectoryArchivosConfiguracion() + "passwordconfig.txt";

            using (StreamReader lector = new StreamReader(directorioPassword))
            {
               while(lector.Peek() > -1)
                {
                    string linea = lector.ReadLine();

                    if (!String.IsNullOrEmpty(linea))
                    {
                        string[] lineaDividida = linea.Split(';');

                        if (lineaDividida[0].Equals("password"))
                        {
                            clave = lineaDividida[1];
                        }
                    }
                }
            }

            return clave;
        }
        public bool ValidarClave(string clave)
        {
            ClsMensajes mensajes = new ClsMensajes();
            bool ok = false;
            if (clave.Equals(getClave()))
            {
                ok = true;
            }
            else
            {
                mensajes.MostrarError("Contraseña incorrecta.");
            }


            return ok;
        }

        ClsMensajes mensajes = new ClsMensajes();
        public void LlenarCbx(ref ComboBox cbx, DataTable data, string textDefault)
        {
            try
            {
                if(data.Rows.Count > 0)
                {
                    DataRow nueva_filaA = data.NewRow();
                    nueva_filaA[data.Columns[0].ColumnName] = "-1";
                    nueva_filaA[data.Columns[1].ColumnName] = textDefault;
                    data.Rows.InsertAt(nueva_filaA, 0);
                    cbx.DataSource = data;
                    cbx.ValueMember = data.Columns[0].ColumnName;
                    cbx.DisplayMember = data.Columns[1].ColumnName;
                }
               
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
