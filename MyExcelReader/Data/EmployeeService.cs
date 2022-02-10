using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace MyExcelReader.Data
{
    public class EmployeeService
    {
        //Read Excel File

        public List<MyData> GetMyDatas()
        {
            List<MyData> employees = new List<MyData>();
            string filePath = "C:/Users/Cara/Desktop/data.xls";

            FileInfo fileInfo = new FileInfo(filePath);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using(ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                int totalCollumn = excelWorksheet.Dimension.End.Column;
                int totalRow = excelWorksheet.Dimension.End.Row;

                for (int row = 0; row <= totalRow; row++)
                {
                    MyData emp = new MyData();
                    for (int col = 0; col <= totalCollumn; col++)
                    {
                        if (col == 1) emp.EmpId = Convert.ToInt32(excelWorksheet.Cells[row, col].Value.ToString());
                        if (col == 2) emp.Name = excelWorksheet.Cells[row, col].Value.ToString();
                        if (col == 3) emp.Department = excelWorksheet.Cells[row, col].Value.ToString();
                        if (col == 4) emp.Designation = excelWorksheet.Cells[row, col].Value.ToString();
                    }
                    employees.Add(emp);
                }
            }
            return employees;

        }
    }
}
