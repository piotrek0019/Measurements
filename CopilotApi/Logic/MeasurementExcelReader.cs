namespace CopilotApi.Logic
{
    using ClosedXML.Excel;
    using CopilotApi.Models;
    using DocumentFormat.OpenXml.Spreadsheet;
    using OfficeOpenXml;
    using System.Collections.Generic;

    //public interface IExcelReader<T>
    //{
    //    IEnumerable<T> Read(Stream excelStream);
    //}

    //public class MeasurementExcelReader : IExcelReader<MeasurementDto>
    public class MeasurementExcelReader
    {
        public IEnumerable<MeasurementDto> Read()
        {
            using var workBook = new XLWorkbook("DataSets/Data_Collection_18057426.xlsx");
            var workSheet = workBook.Worksheet(1);

            foreach (var row in workSheet.RowsUsed())
            {
                var rowToReturn = new List<string>();
                foreach (var cell in row.Cells())
                {
                    rowToReturn.Add(cell.GetFormattedString());
                }

                var measurementDto = new MeasurementDto();
                measurementDto.Cells.AddRange(rowToReturn);
                yield return measurementDto;
                //dick
            }
        }
    }
}
