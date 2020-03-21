using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace control_copias.Utilidades
{
    class ClsUtilidadesExcel
    {
        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
        private void eliminarFilaTotales(ref DataTable data)
        {
            DataRow rowDelete = data.Rows[data.Rows.Count - 1];

            data.Rows.Remove(rowDelete);
        }
        private void agregarEncabezado(ref ExcelWorksheet worksheet, DataTable data, string definicion)
        {
            worksheet.Cells[1, 1, 1, data.Columns.Count].Merge = true;
            if (data.TableName.Equals("Ganancias"))
            {
                worksheet.Cells[1, 1].Value = "Reporte de Entradas y Salidas";
            }
            else
            {
                worksheet.Cells[1, 1].Value = "Reporte de " + data.TableName;
            }

            worksheet.Cells[1, 1].Style.Font.Size = 18;
            worksheet.Cells[1, 1].Style.Font.Bold = true;
            worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            worksheet.Cells[2, 1, 2, data.Columns.Count].Merge = true;
            worksheet.Cells[2, 1].Value = definicion;
            worksheet.Cells[2, 1].Style.Font.Size = 12;
            worksheet.Cells[2, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        }
        private void agregarFilaTotales(ref ExcelWorksheet worksheet, int fi, int ci, int ff, int cf)
        {
            worksheet.Cells[fi, ci, ff, cf].Merge = true;
            worksheet.Cells[fi, ci].Value = "TOTALES";
            worksheet.Cells[fi, ci].Style.Font.Bold = true;
            worksheet.Cells[fi, ci].Style.Font.Italic = true;
            worksheet.Cells[fi, ci].Style.Font.UnderLine = true;
            worksheet.Cells[fi, ci].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

        }
        private void agregarFormula(ref ExcelWorksheet worksheet, string celda, string formula)
        {
            worksheet.Cells[celda].Formula = formula;
            worksheet.Cells[celda].Style.Font.Bold = true;
            worksheet.Cells[celda].Style.Font.Italic = true;
        }
        private string crearRangoLetras(int fi, int ci, int ff, int cf)
        {
            string result = "";
            string col1 = GetExcelColumnName(ci);

            if (ff == 0 && cf == 0)
            {
                result = col1 + fi.ToString();
            }
            else
            {
                string col2 = GetExcelColumnName(cf);

                result = col1 + fi.ToString() + ":" + col2 + ff.ToString();
            }

            return result;
        }
        private void agregarTotales(ref ExcelWorksheet worksheet, int finalFilas, int finalColumnas)
        {
            //agregar titulo totales
            agregarFilaTotales(ref worksheet, finalFilas + 1, 1, finalFilas + 1, 4);

            //agregar borde superior - separador totales
            worksheet.Cells[finalFilas + 1, 1, finalFilas + 1, finalColumnas].Style.Border.Top.Style = ExcelBorderStyle.Medium;

            //agregar formulas de sumatoria
            string formula1 = "=SUM(" + crearRangoLetras(5, 5, finalFilas, 5) + ")";
            agregarFormula(ref worksheet, crearRangoLetras(finalFilas + 1, 5, 0, 0), formula1);

            string formula2 = "=SUM(" + crearRangoLetras(5, 6, finalFilas, 6) + ")";
            agregarFormula(ref worksheet, crearRangoLetras(finalFilas + 1, 6, 0, 0), formula2);

            string formula3 = "=SUM(" + crearRangoLetras(5, 8, finalFilas, 8) + ")";
            agregarFormula(ref worksheet, crearRangoLetras(finalFilas + 1, 8, 0, 0), formula3);
        }

        public void ExportarRpExcel(ref DataTable data, string definicionReporte)
        {

            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    //delete row totales
                    eliminarFilaTotales(ref data);
                    int finalFilas = data.Rows.Count + 4;
                    int finalColumnas = data.Columns.Count;

                    //create a new Worksheet
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Hoja 1");

                    //Agregar encabezado
                    agregarEncabezado(ref worksheet, data, definicionReporte);

                    //agregar tabla
                    worksheet.Cells["A4"].LoadFromDataTable(data, true, TableStyles.Medium6);
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();


                    //cofigruar formato y totales

                        agregarTotales(ref worksheet, finalFilas, finalColumnas);



                    //create a SaveFileDialog instance with some properties
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Title = "Save Excel sheet";
                    saveFileDialog1.Filter = "Excel files|*.xlsx|All files|*.*";
                    saveFileDialog1.FileName = "ExcelSheet_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                    //check if user clicked the save button
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //Get the FileInfo
                        FileInfo fi = new FileInfo(saveFileDialog1.FileName);
                        //write the file to the disk
                        excelPackage.SaveAs(fi);
                    }
                }
            }
            catch (Exception ex)
            {
                string msj = ex.Message;

            }
        }
    }
}
