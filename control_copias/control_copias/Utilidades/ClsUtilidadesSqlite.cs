using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace control_copias.Utilidades
{
    public class ClsUtilidadesSqlite
    {
        public string getStringConection()
        {
            ClsUtilidadesSistema sistema = new ClsUtilidadesSistema();
            string strPathConexion = "Data Source = " + sistema.getDirectoryArchivosConfiguracion() + "bd_copafe.db";

            return strPathConexion;
        }

        public string Insert(string query, List<string> parametros)
        {
            string result = "";

            try
            {
                SQLiteConnection cnx = new SQLiteConnection(getStringConection());
                SQLiteCommand command;
                cnx.Open();
                command = cnx.CreateCommand();
                command.CommandText = query;

                for (int cont = 0; cont < parametros.Count; cont++)
                {
                    string nombreParametro = "@parametro" + (cont + 1).ToString();

                    command.Parameters.Add(new SQLiteParameter(nombreParametro, parametros[cont].ToUpper()));
                }

                command.ExecuteNonQuery();
                cnx.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

           
            return result;
        }

        public string InsertRegistroFotocopias(string query, List<string> parametros)
        {
            string result = "";

            try
            {

                string ok = Insert(query, parametros);

                if (ok.Equals(""))
                {
                    string codFotocopiadora = parametros[0];
                    DataTable data = Select("SELECT * FROM fotocopiadora f WHERE f.cod_fotocopiadora = " + codFotocopiadora);

                    if (data.Rows.Count > 0)
                    {
                        DataRow row = data.Rows[0];
                        string nuevoContador = (Convert.ToInt32(row["contador"].ToString()) + Convert.ToInt32(parametros[4])).ToString();

                        List<string> paramUpdate = new List<string>();
                        paramUpdate.Add(nuevoContador + ";asignar");
                        paramUpdate.Add(codFotocopiadora + ";comparar");


                        string updateQuery = "update fotocopiadora set contador = :parametro1 where cod_fotocopiadora = @parametro2";

                        result = Update(updateQuery, paramUpdate);

                        if (!result.Equals(""))
                        {
                            string queryMax = "select max(r.cod_registro) as cod from registro r";
                            DataTable dataMax = Select(queryMax);
                            DataRow rowmax = dataMax.Rows[0];
                            string codEliminar = rowmax["cod"].ToString();

                            string queryDelete = "delete from registro where cod_registro = :parametro";
                            Delete(codEliminar, queryDelete);
                        }
                    }
                }
                else
                {
                    result = ok;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        public DataTable Select(string query)
        {
            DataTable data = new DataTable("Categorias");

            try
            {

                SQLiteConnection cnx = new SQLiteConnection(getStringConection());
                SQLiteDataAdapter adapter;
                DataSet ds = new DataSet();
                cnx.Open();




                adapter = new SQLiteDataAdapter(query, cnx);

                adapter.Fill(ds);
                data = ds.Tables[0];


                cnx.Close();
            }
            catch (Exception ex)
            {
                data.TableName = "error";
            }
            return data;
        }
        public string Update(string query, List<string> parametros)
        {
            string result = "";

            try
            {
                SQLiteConnection cnx = new SQLiteConnection(getStringConection());
                SQLiteCommand command;
                cnx.Open();
                command = cnx.CreateCommand();
                command.CommandText = query;

                for (int cont = 0; cont < parametros.Count; cont++)
                {
                    string[] infoParametro = parametros[cont].Split(';');
                    string nombreParametro = "";

                    if (infoParametro[1].Equals("asignar"))
                    {
                        nombreParametro = "parametro" + (cont + 1).ToString();
                    }
                    else if (infoParametro[1].Equals("comparar"))
                    {
                        nombreParametro = "@parametro" + (cont + 1).ToString();
                    }


                    command.Parameters.Add(new SQLiteParameter(nombreParametro, infoParametro[0].ToUpper()));
                }

                command.ExecuteNonQuery();
                cnx.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        public int Exist(string query)
        {
            DataTable data = new DataTable("Categorias");
            int exist = 0;
            try
            {
                SQLiteConnection cnx = new SQLiteConnection(getStringConection());
                SQLiteDataAdapter adapter;
                DataSet ds = new DataSet();
                cnx.Open();

                adapter = new SQLiteDataAdapter(query, cnx);
                adapter.Fill(ds);
                data = ds.Tables[0];
                cnx.Close();

                if (data.Rows.Count > 0)
                {
                    exist = 1;
                }
            }
            catch (Exception ex)
            {
                data.TableName = "error";
                exist = -1;
            }
            return exist;
        }
        public void Delete(string parametro, string query)
        {
            string result = "";

            try
            {
                SQLiteConnection cnx = new SQLiteConnection(getStringConection());
                SQLiteCommand command;
                cnx.Open();
                command = cnx.CreateCommand();
                command.CommandText = query;

                command.Parameters.Add(new SQLiteParameter("parametro", parametro));
                command.ExecuteNonQuery();
                cnx.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

        }
    }
}
