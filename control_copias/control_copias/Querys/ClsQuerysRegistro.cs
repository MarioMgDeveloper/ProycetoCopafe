using control_copias.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace control_copias.Querys
{
    public class ClsQuerysRegistro
    {
        private ClsUtilidadesSqlite utilidades = new ClsUtilidadesSqlite();

        public string InsertRegistro(List<string> parametros)
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" insert into registro (cod_fotocopiadora, cod_usuario, fecha, tipo_registro, cantidad_buenas, cantidad_malas, precio, observaciones)");
            strQuery.Append(" values (@parametro1, @parametro2, @parametro3, @parametro4, @parametro5, @parametro6, @parametro7, @parametro8)");

            if (parametros[3].Equals("1"))
            {
                return utilidades.InsertRegistroFotocopias(strQuery.ToString(), parametros);
            }
            else
            {
                return utilidades.Insert(strQuery.ToString(), parametros);
            }
        }
        public DataTable getReporte(string codFotocopiadora, string codusuario, string codTipoRegistro, string fechaInicio, string fechaFin)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select");
            strSql.Append(" f.nombre as FOTOCOPIADORA,");
            strSql.Append(" (u.nombres || u.apellidos) as \"USUARIO REGISTRO\",");
            strSql.Append(" (case ");
            strSql.Append("  when r.tipo_registro = 1 then 'FOTOCOPIAS' ");
            strSql.Append("  when r.tipo_registro = 2 then 'IMPRESIONES A COLOR' ");
            strSql.Append("  WHEN r.tipo_registro = 3 THEN 'IMPRESIONES BLANCO Y NEGRO'");
            strSql.Append("  WHEN r.tipo_registro = 4 THEN 'ESCANEOS'");
            strSql.Append("  WHEN r.tipo_registro = 6 THEN 'EMPLASTICADO'");
            strSql.Append("  WHEN r.tipo_registro = 5 THEN 'ENCUADERNADOS' END) AS [TIPO REGISTRO],");
            strSql.Append(" cast(r.fecha as text) AS \"FECHA REGISTRO\",");
            strSql.Append(" r.cantidad_buenas AS [HOJAS BUENAS],");
            strSql.Append(" r.cantidad_malas AS [HOJAS DEFECTUOSAS],");
            strSql.Append(" printf(\"%.2f\",r.precio) AS \"PRECIO (Q.)\",");
            strSql.Append(" printf(\"%.2f\",(CASE WHEN r.tipo_registro >= 5  THEN  r.precio ELSE round( (r.cantidad_buenas * r.precio), 2) END)) AS [TOTAL (Q.)]");
            strSql.Append(" from ");
            strSql.Append(" registro r");
            strSql.Append(" left join fotocopiadora f on r.cod_fotocopiadora = f.cod_fotocopiadora");
            strSql.Append(" inner join usuarios u on r.cod_usuario = u.cod_usuario");
            strSql.Append(" where");
            strSql.Append(" 1=1");


            if (!codFotocopiadora.Equals(""))
            {
                strSql.Append(" and r.cod_fotocopiadora = " + codFotocopiadora);
            }

            if (!codusuario.Equals(""))
            {
                strSql.Append(" and r.cod_usuario = '" + codusuario + "'");
            }

            if (!codTipoRegistro.Equals(""))
            {
                strSql.Append(" and r.tipo_registro = " + codTipoRegistro);
            }

            if (!fechaInicio.Equals(""))
            {
                strSql.Append(" and r.fecha >= '" + fechaInicio + "'");
            }

            if (!fechaFin.Equals(""))
            {
                strSql.Append(" and r.fecha <= '" + fechaFin + "'");
            }

            strSql.Append(" order by f.nombre, u.nombres || u.apellidos asc");

            DataTable data = utilidades.Select(strSql.ToString());

            if (data.Rows.Count > 0)
            {
                AgregarTotales(ref data);
            }


            return data;
        }
        private void AgregarTotales(ref DataTable data)
        {
            int cantidad = 0;
            int defectuosas = 0;
            float total = 0;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row = data.Rows[i];

                cantidad = cantidad + Convert.ToInt32(row["HOJAS BUENAS"].ToString());
                defectuosas = defectuosas + Convert.ToInt32(row["HOJAS DEFECTUOSAS"].ToString());
                total = total + float.Parse(row["TOTAL (Q.)"].ToString());
            }

            DataRow rowAdd = data.NewRow();

            rowAdd["FOTOCOPIADORA"] = DBNull.Value;
            rowAdd["USUARIO REGISTRO"] = DBNull.Value;
            rowAdd["TIPO REGISTRO"] = "TOTALES";
            rowAdd["FECHA REGISTRO"] = DBNull.Value;
            rowAdd["HOJAS BUENAS"] = cantidad;
            rowAdd["HOJAS DEFECTUOSAS"] = defectuosas;
            rowAdd["PRECIO (Q.)"] = DBNull.Value;
            rowAdd["TOTAL (Q.)"] = total;

            data.Rows.Add(rowAdd);
        }
    }
}
