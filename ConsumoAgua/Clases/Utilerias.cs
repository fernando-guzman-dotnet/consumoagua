using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Clases;
using Microsoft.Office.Interop.Excel;


namespace SAPA.Clases
{
    internal static class Utilerias
    {

        private static readonly ConvertidorLetrasV2.Class1 ConvertidorLetras = new ConvertidorLetrasV2.Class1();

        public static string CantidadEnLetras(decimal cantidad)
        {
            return ConvertidorLetras.enletras(cantidad.ToString());
        }

        // Este método devuelve un solo DateTime a partir de dos controles separados (uno para la fecha, otro para la hora)

        public static DateTime GetDateTimeFromControls(DateTimePicker ctrlFecha, DateTimePicker ctrlHora)
        {
            var valorFecha = ctrlFecha.Value;
            var valorHora = ctrlHora.Value;

            return new DateTime(valorFecha.Year, valorFecha.Month, valorFecha.Day, valorHora.Hour, valorHora.Minute, valorHora.Second);
        }

        public static string NormalizarEspacios(string input)
        {
            int len = input.Length,
                index = 0,
                i = 0;

            var src = input.ToCharArray();

            bool skip = false;

            char ch;

            for (; i < len; i++)
            {
                ch = src[i];
                switch (ch)
                {
                    case '\u0020':
                    case '\u00A0':
                    case '\u1680':
                    case '\u2000':
                    case '\u2001':
                    case '\u2002':
                    case '\u2003':
                    case '\u2004':
                    case '\u2005':
                    case '\u2006':
                    case '\u2007':
                    case '\u2008':
                    case '\u2009':
                    case '\u200A':
                    case '\u202F':
                    case '\u205F':
                    case '\u3000':
                    case '\u2028':
                    case '\u2029':
                    case '\u0009':
                    case '\u000A':
                    case '\u000B':
                    case '\u000C':
                    case '\u000D':
                    case '\u0085':
                        if (skip) continue;
                        src[index++] = ch;
                        skip = true;
                        continue;
                    default:
                        skip = false;
                        src[index++] = ch;
                        continue;
                }
            }
            return new string(src, 0, index).Trim();
        }



        public static string EncriptarContrasena(string contrasena)
        {
            string vaa = contrasena;

            var apiKey = vaa;
            var apiSecret = "VVhwTmVVNHlVbWhPVjFsNVVrRTlQUT09";
            var key = Convert.FromBase64String(apiSecret);
            var provider = new System.Security.Cryptography.HMACSHA256(key);
            var hash = provider.ComputeHash(Encoding.UTF8.GetBytes(apiKey));
            var signature = Convert.ToBase64String(hash);

            return signature;
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }

        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }


        public static Image Resize(this Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            
            //Get the image current height  
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            
            //Calulate  width with new desired size  

            nPercentW = ((float)size.Width / (float)sourceWidth);
            
            //Calculate height with new desired size  

            nPercentH = ((float)size.Height / (float)sourceHeight);

            nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

            //New Width  

            int destWidth = (int)(sourceWidth * nPercent);
            
            //New Height  

            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);

            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            
            // Draw image with new width and height  

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return b;
        }

        public static List<Porcentajes> DividirEntreCien(this List<Porcentajes> porcentajes)
        {
            // Dividimos entre 100 las cantidades para que puedan usarse en los cálculos correctamente

            foreach (Porcentajes porcentaje in porcentajes)
            {
                porcentaje.IVA /= 100;
                porcentaje.Alcantarillado /= 100;
                porcentaje.Saneamiento /= 100;
                porcentaje.DescuentoAnual /= 100;
                porcentaje.Multas /= 100;
                porcentaje.Recargos /= 100;
                porcentaje.AumentoAnual /= 100;
            }

            return porcentajes;
        }

        public static DateTime GetInicioPeriodoBimestral(DateTime Fecha)
        {
            int bimestrePeriodo = GetBimestre(Fecha);
            int mesInicioPeriodo = 0;

            switch (bimestrePeriodo)
            {
                case 1:
                    mesInicioPeriodo = 1;
                    break;
                case 2:
                    mesInicioPeriodo = 3;
                    break;
                case 3:
                    mesInicioPeriodo = 5;
                    break;
                case 4:
                    mesInicioPeriodo = 7;
                    break;
                case 5:
                    mesInicioPeriodo = 9;
                    break;
                case 6:
                    mesInicioPeriodo = 11;
                    break;
                default:
                    throw new InvalidOperationException("No se puede generar una fecha con el parametro especificado.");
            }

            return DateTime.Parse($"01/{mesInicioPeriodo}/{Fecha.Year}");
        }

        public static DateTime GetFinPeriodoBimestral(DateTime Fecha)
        {
            int bimestrePeriodo = GetBimestre(Fecha);
            int mesInicioPeriodo = 0;

            switch (bimestrePeriodo)
            {
                case 1:
                    mesInicioPeriodo = 2;
                    break;
                case 2:
                    mesInicioPeriodo = 4;
                    break;
                case 3:
                    mesInicioPeriodo = 6;
                    break;
                case 4:
                    mesInicioPeriodo = 8;
                    break;
                case 5:
                    mesInicioPeriodo = 10;
                    break;
                case 6:
                    mesInicioPeriodo = 12;
                    break;
                default:
                    throw new InvalidOperationException("No se puede generar una fecha con el parametro especificado.");
            }

            return DateTime.Parse($"{DateTime.DaysInMonth(Fecha.Year, mesInicioPeriodo)}/{mesInicioPeriodo}/{Fecha.Year}");
        }



        public static int GetBimestre(DateTime Fecha)
        {
            int periodoActual = 0;
            switch (Fecha.Month)
            {
                case 1:
                case 2:
                    periodoActual = 1;
                    break;
                case 3:
                case 4:
                    periodoActual = 2;
                    break;
                case 5:
                case 6:
                    periodoActual = 3;
                    break;
                case 7:
                case 8:
                    periodoActual = 4;
                    break;
                case 9:
                case 10:
                    periodoActual = 5;
                    break;
                case 11:
                case 12:
                    periodoActual = 6;
                    break;
            }
            return periodoActual;
        }


        public static DateTime FirstDayOfWeek(this DateTime dt)
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-diff).Date;
        }

        public static DateTime LastDayOfWeek(this DateTime dt) => dt.FirstDayOfWeek().AddDays(6);


        public static void ExportToExcel(this System.Data.DataTable DataTable, string ExcelFilePath = null)
        {
            try
            {
                int ColumnsCount;

                if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Excel.Workbooks.Add();

                // single worksheet
                _Worksheet Worksheet = Excel.ActiveSheet;

                object[] Header = new object[ColumnsCount];

                // column headings               
                for (int i = 0; i < ColumnsCount; i++)
                    Header[i] = DataTable.Columns[i].ColumnName;

                Range HeaderRange = Worksheet.get_Range((Range)(Worksheet.Cells[1, 1]), (Range)(Worksheet.Cells[1, ColumnsCount]));
                HeaderRange.Value = Header;
                HeaderRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                HeaderRange.Font.Bold = true;

                // DataCells
                int RowsCount = DataTable.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];

                for (int j = 0; j < RowsCount; j++)
                    for (int i = 0; i < ColumnsCount; i++)
                        Cells[j, i] = DataTable.Rows[j][i];

                Worksheet.Range[(Range)(Worksheet.Cells[2, 1]), (Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])].Value = Cells;

                if (!string.IsNullOrEmpty(ExcelFilePath))
                {
                    try
                    {
                        Worksheet.SaveAs(ExcelFilePath, XlFileFormat.xlWorkbookDefault);
                        Excel.Quit();

                        Marshal.FinalReleaseComObject(Worksheet);
                        Marshal.FinalReleaseComObject(HeaderRange);
                        Marshal.FinalReleaseComObject(Excel);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo exportar el archivo de excel. Contacte al área de soporte de SAPA.\n"
                            + ex.Message);
                    }
                }
                else
                {
                    Excel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo exportar el archivo de excel. Contacte al área de soporte de SAPA. \n" + ex.Message);
            }
        }

        public static List<DateTime> GenerarFechasParcialidades(Convenio.Periodicidades periodicidad, DateTime fechaInicio, int noParcialidades)
        {

            List<DateTime> parcialidades = new List<DateTime>();

            DateTime ultimaFecha = new DateTime();
            int conteoParcialidades = 0;

            switch (periodicidad)
            {
                case Convenio.Periodicidades.Diaria:
                    ultimaFecha = fechaInicio.AddDays(-1);

                    while (conteoParcialidades < noParcialidades)
                    {
                        // Generar proyecciones a partir del mismo día
                        ultimaFecha = ultimaFecha.AddDays(1);

                        // No se cobra sabado y domingo, ignoramos estos días y buscamos un día hábil próximo
                        while (ultimaFecha.DayOfWeek == DayOfWeek.Saturday || ultimaFecha.DayOfWeek == DayOfWeek.Sunday)
                        {
                            ultimaFecha = ultimaFecha.AddDays(1);
                        }

                        parcialidades.Add(ultimaFecha);

                        conteoParcialidades++;
                    }
                    break;

                case Convenio.Periodicidades.Semanal:

                    ultimaFecha = fechaInicio;

                    while (conteoParcialidades < noParcialidades)
                    {
                        // Generar proyecciones a partir del mismo día
                        if (parcialidades.Count > 0)
                            ultimaFecha = ultimaFecha.AddDays(7);

                        parcialidades.Add(ultimaFecha);
                        conteoParcialidades++;
                    }
                    break;

                case Convenio.Periodicidades.Quincenal:

                    ultimaFecha = fechaInicio;

                    while (conteoParcialidades < noParcialidades)
                    {
                        if (ultimaFecha.Day == DateTime.DaysInMonth(ultimaFecha.Year, ultimaFecha.Month))
                        {
                            ultimaFecha = ultimaFecha.AddMonths(1);
                            ultimaFecha = new DateTime(ultimaFecha.Year, ultimaFecha.Month, 1);
                        }

                        if (ultimaFecha.Day == 15)
                            ultimaFecha = new DateTime(ultimaFecha.Year, ultimaFecha.Month,
                                DateTime.DaysInMonth(ultimaFecha.Year, ultimaFecha.Month));

                        if (ultimaFecha.Day < 15)
                            ultimaFecha = new DateTime(ultimaFecha.Year, ultimaFecha.Month, 15);

                        if(ultimaFecha.Day > 15)
                            ultimaFecha = new DateTime(ultimaFecha.Year, ultimaFecha.Month,
                                DateTime.DaysInMonth(ultimaFecha.Year, ultimaFecha.Month));

                        parcialidades.Add(ultimaFecha);

                        conteoParcialidades++;
                    }
                    break;

                case Convenio.Periodicidades.Mensual:
                    ultimaFecha = fechaInicio.AddMonths(1);

                    while (conteoParcialidades < noParcialidades)
                    {
                        // Generar proyecciones a partir del mismo día
                        if (parcialidades.Count > 0)
                            ultimaFecha = ultimaFecha.AddMonths(1);

                        parcialidades.Add(ultimaFecha);
                        conteoParcialidades++;
                    }

                    break;

                case Convenio.Periodicidades.Anual:
                    ultimaFecha = fechaInicio;

                    while (conteoParcialidades < noParcialidades)
                    {
                        if (parcialidades.Count > 0)
                            ultimaFecha = ultimaFecha.AddYears(1);

                        parcialidades.Add(ultimaFecha);
                        conteoParcialidades++;
                    }
                    break;
            }

            return parcialidades;
        }
    }
}

