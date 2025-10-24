using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsReportes
{
    public static class StaticsFront
    {
        public static string GenerarNombreArchivoUnico(string baseName, string extension)
        {
            // Obtener la fecha y hora actual
            DateTime now = DateTime.Now;

            // Formatear la fecha y hora
            string dateTime = now.ToString("yyyyMMdd_HHmmss");

            // Crear el nombre de archivo único
            string fileName = $"{baseName}_{dateTime}.{extension}";

            return fileName;
        }

        public static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Guardar la imagen en el MemoryStream en formato JPEG (puedes cambiar el formato si es necesario)
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Devolver el array de bytes desde el MemoryStream
                return ms.ToArray();
            }
        }

    }
}
