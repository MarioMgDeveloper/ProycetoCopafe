using control_copias.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace control_copias.Querys
{
    public class ClsQuerysUsuario
    {
        private ClsUtilidadesSqlite utilidades = new ClsUtilidadesSqlite();

        public string InsertUsuario(List<string> parametros)
        {
            return utilidades.Insert("insert into usuarios (cod_usuario,nombres,apellidos) values(@parametro1, @parametro2, @parametro3)", parametros);
        }
        public DataTable getUsuarios()
        {
            return utilidades.Select("select u.cod_usuario as CÓDIGO, u.nombres AS NOMBRES, u.apellidos AS APELLLIDOS from usuarios u order by u.nombres asc");
        }
        public int getNextCod()
        {
            DataTable data = utilidades.Select("select u.cod_usuario from usuarios u");
            int nextCod = 0;
            if (data.Rows.Count > 0)
            {
                nextCod = data.Rows.Count + 1;
            }
            else
            {
                nextCod = 1;
            }

            return nextCod;
        }
        public int ExistCod(string cod)
        {
            return utilidades.Exist("select * from usuarios u where u.cod_usuario = '" + cod + "'");
        }
        public DataTable getForCbx()
        {
            StringBuilder strQuery = new StringBuilder();

            strQuery.Append(" select");
            strQuery.Append(" u.cod_usuario,");
            strQuery.Append(" u.nombres||' '||u.apellidos as nombre");
            strQuery.Append(" from usuarios u");
            strQuery.Append(" order by u.nombres||u.apellidos asc");


            return utilidades.Select(strQuery.ToString());
        }

    }
}
