using control_copias.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace control_copias.Querys
{
    public class ClsQuerysFotocopiadora
    {
        private ClsUtilidadesSqlite utilidades = new ClsUtilidadesSqlite();
        public string InsertFotocopiadora(List<string> parametros)
        {
            return utilidades.Insert("INSERT INTO fotocopiadora (nombre, contador, descripcion) VALUES (@parametro1, @parametro2, @parametro3)", parametros);
        }
        public DataTable getAll()
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" select");
            strQuery.Append(" f.cod_fotocopiadora as CÓDIGO,");
            strQuery.Append(" f.nombre as NOMBRE,");
            strQuery.Append(" f.contador as \"CONTADOR INICIAL\",");
            strQuery.Append(" f.descripcion as DESCRIPCION");
            strQuery.Append(" from fotocopiadora f");
            strQuery.Append(" order by f.cod_fotocopiadora asc");

            return utilidades.Select(strQuery.ToString());
        }
        public string UpdateFotocopiadora(List<string> parametros)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("update fotocopiadora set nombre = :parametro1, contador = :parametro2, descripcion = :parametro3");
            strQuery.Append(" where cod_fotocopiadora = @parametro4");

            return utilidades.Update(strQuery.ToString(), parametros);
        }
        public DataTable getForButtons()
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" select");
            strQuery.Append(" f.cod_fotocopiadora,");
            strQuery.Append(" f.nombre,");
            strQuery.Append(" f.descripcion");
            strQuery.Append(" from fotocopiadora f");
            strQuery.Append(" order by cod_fotocopiadora asc");


            return utilidades.Select(strQuery.ToString());
        }
        public int getCantidad()
        {
            int cantidad = 0;

            DataTable data = utilidades.Select("select count(*) as cantidad from fotocopiadora");

            DataRow row = data.Rows[0];

            string strCantidad = row["cantidad"].ToString();

            if (!strCantidad.Equals(""))
            {
                cantidad = Convert.ToInt32(strCantidad);
            }

            return cantidad;
        }
        public DataTable getForCbx()
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" select");
            strQuery.Append(" f.cod_fotocopiadora,");
            strQuery.Append(" f.nombre");
            strQuery.Append(" from fotocopiadora f");
            strQuery.Append(" order by f.nombre asc");

            return utilidades.Select(strQuery.ToString());
        }
        public string getContadorActual(string codFotocopiadora)
        {
            string contador = "";
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select *");
            strSql.Append(" from fotocopiadora f");
            strSql.Append(" where f.cod_fotocopiadora = " + codFotocopiadora);

            DataTable data = utilidades.Select(strSql.ToString());
            DataRow row = data.Rows[0];

            contador = row["contador"].ToString();


            return contador;
        }
    }
}
