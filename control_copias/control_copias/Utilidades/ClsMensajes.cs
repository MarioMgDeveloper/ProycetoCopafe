using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace control_copias.Utilidades
{
    class ClsMensajes
    {
        public void MostrarInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public bool MostrarConfirmacion(string mensaje)
        {
            MessageBoxResult messageBoxResult;
            bool resultConfirm = true;
            messageBoxResult = MessageBox.Show(mensaje, "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.No)
            {
                resultConfirm = false;
            }

            return resultConfirm;
        }

        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
