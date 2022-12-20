using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using MvvmHelpers;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Office.Interop.Excel;

namespace Seguimiento.MVVM.Model
{
    internal class ExcelModel
    {

        public void GenerarExcel(ObservableRangeCollection<Incidencia> Incidencias)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "Producción";
                oSheet.Cells[1, 2] = "Hora Inicio";
                oSheet.Cells[1, 3] = "Hora Fin";
                oSheet.Cells[1, 4] = "Tiempo";
                oSheet.Cells[1, 5] = "Instalación";
                oSheet.Cells[1, 6] = "Incidencia";

                //Format A1:F1 as bold
                oSheet.get_Range("A1", "F1").Font.Bold = true;

                //Rellenar celdas
                int puntero = 2;
                int ultimainc = 0;
                foreach (Incidencia incidencia in Incidencias)
                {
                    oSheet.Cells[puntero,1] = incidencia.Produccion;
                    oSheet.Cells[puntero, 2] = incidencia.HoraInicio;
                    oSheet.Cells[puntero, 3] = incidencia.HoraFin;
                    oSheet.Cells[puntero, 4] = $"=C{puntero}-B{puntero}";
                    oSheet.Cells[puntero, 5] = incidencia.Instalacion;
                    oSheet.Cells[puntero, 6] = incidencia.Texto;

                    ultimainc = puntero;
                    puntero++;
                    
                }

                //Calculo final de tiempo Total
                oSheet.Cells[puntero, 1] = "Total";
                oSheet.get_Range($"A{puntero}").Font.Bold = true;
                oSheet.Cells[puntero, 4] = $"=SUM(D2:D{puntero - 1})";
                oSheet.get_Range($"D{puntero}").Font.Bold = true;

                //Estilo de tabla
                //oWB.DefaultTableStyle = oWB.TableStyles["TableStyleLight1"];
                //Rango de celdas con datos
                oRng = oSheet.Range["A1", $"F{puntero}"];
                oRng.Select();
                
                // Dar formato a la tabla
                oRng.Worksheet.ListObjects.AddEx(
                    SourceType: Excel.XlListObjectSourceType.xlSrcRange,
                    Source: oRng,
                    XlListObjectHasHeaders: Excel.XlYesNoGuess.xlYes);


                puntero += 2;
                //Calculo de tiempo por instalación
                var instalaciones = Incidencias.Select(o => o.Instalacion).Distinct();
                foreach(var instalacion in instalaciones)
                {
                    //Titulo
                    oSheet.Cells[puntero, 1] = $"Total en {instalacion}:";
                    oSheet.get_Range($"A{puntero}").Font.Bold = true;
                    //Tiempo
                    oSheet.Cells[puntero, 2] = $"=SUMIF(E2:E{ultimainc},\"{instalacion}\",D2:D{ultimainc})";
                    oSheet.Cells[puntero, 2].NumberFormat = "h:mm";
                    oSheet.get_Range($"A{puntero}").Font.Bold = true;
                    puntero++;
                }

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }
    }
}



