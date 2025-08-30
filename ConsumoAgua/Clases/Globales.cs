using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using SAPA.Properties;

namespace SAPA.Clases
{
    public static class Globales
    {
        public enum EntryPoints
        {
            Pruebas,
            SAPA
        }

        public static EntryPoints CurrentEntryPoint = EntryPoints.SAPA;
        
        public static ResourceManager ResourceManager { get; set; }

        public static Icon GetIcon(string key) => (Icon)ResourceManager.GetObject(key);
        public static Color GetColor(string key) => ColorTranslator.FromHtml(GetString(key));
        public static string GetString(string key) => ResourceManager.GetString(key);
        public static Bitmap GetImage(string key) => (Bitmap)ResourceManager.GetObject(key);

        public static void CargarEsquemaColores()
        {
            List<string> keysPropiedadesColores = new List<string>()
            {
                "FondoMenuInferior",
                "FondoMenuSuperior",
                "FondoMenuPrincipal",
                "FondoVentanaCaptura",
            };

            foreach (string key in keysPropiedadesColores)
            {
                if (Settings.Default[key] == null) continue;
                Settings.Default[key] = GetColor(key);
            }
        }



        public enum Municipios
        {
            Jacona,
            Pruebas,
            Tinguindin
        }

        public static Municipios MunicipioActual { get; set; }

    }
}

