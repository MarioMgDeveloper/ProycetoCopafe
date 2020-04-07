using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace control_copias.Utilidades
{
    public static class ClsUtilidadesTema
    {
        public static  Color GetColor(string BtnName)
        {
            Color color;

            if (BtnName.Equals("Fotocopiadoras"))
            {
                color = Color.FromArgb(53, 39, 75);//morado
            }
            else if (BtnName.Equals("Usuarios"))
            {
                color = Color.FromArgb(245, 213, 39);//amarillo
            }
            else if (BtnName.Equals("Registros"))
            {
                color = Color.FromArgb(53, 39, 75);//morado
            }
            else if (BtnName.Equals("Informes"))
            {
                color = Color.FromArgb(166, 46, 46);//corinto
            }
            else
            {
                color = Color.FromArgb(70, 111, 166);//celeste
            }

            return color;
        }

        public static Color GetColorSombra(string BtnName)
        {
            Color color;

            if (BtnName.Equals("Fotocopiadoras"))
            {
                color = Color.FromArgb(43, 29, 65);//morado
            }
            else if (BtnName.Equals("Usuarios"))
            {
                color = Color.FromArgb(235, 203, 29);//amarillo
            }
            else if (BtnName.Equals("Registros"))
            {
                color = Color.FromArgb(43, 29, 65);//morado
            }
            else if (BtnName.Equals("Informes"))
            {
                color = Color.FromArgb(156, 36, 36);//corinto
            }
            else
            {
                color = Color.FromArgb(60, 101, 156);//celeste
            }

            return color;
        }

        public static Color ForeColorDefault = Color.White;
        public static Color BackColorDefault = Color.FromArgb(36, 135, 57);
        public static Color ColorFilaTotales = Color.FromArgb(255, 235, 156);


    }
}
