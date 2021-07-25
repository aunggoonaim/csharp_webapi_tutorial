using AutoMapper;
using EntityFramework.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial1.Dtoa;
using tutorial1.Models;
using tutorial1.Services.Interface;

namespace tutorial1.Services.Dependency
{
    public class DRoleInfo : IRoleInfo
    {
        private readonly db_tutorialContext _context;

        public DRoleInfo(db_tutorialContext context)
        {
            _context = context;
        }

        ~DRoleInfo()
        {
            GC.Collect();
        }

        public async Task<List<role_info>> GetQueryRoleList()
        {

            var query = _context.role_infos
                    .AsQueryable();

            var role = await query
                    .ToListAsync();

            return role;
        }

        public async Task<role_info> CreateRoleInfo(role_info_create role_create)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<role_info_create, role_info>());
            var mapper = new Mapper(config);
            var role = mapper.Map<role_info_create, role_info>(role_create);
            _context.role_infos.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public void CreateExcel(List<role_info> role)
        {
            using (var excel = new OfficeOpenXml.ExcelPackage())
            {
                var worksheet = excel.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells["A1"].Formula = "vlookup(D1, master!R1:S1)";

                var rows = worksheet.Dimension.Rows;

                excel.SaveAs(new System.IO.FileInfo("filename.xls"));
            }
        }

        public void ReadExcel()
        {
            using (var excel = new OfficeOpenXml.ExcelPackage(new System.IO.FileInfo("filename.xls")))
            {
                var worksheet = excel.Workbook.Worksheets["Sheet1"];

                var rows = worksheet.Dimension.Rows;
                var ascii = Convert.ToInt32('A');
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        var columnName = Convert.ToChar(ascii + col);
                        var value = worksheet.Cells[$"{columnName}{row}"].Text;
                    }
                }
                var colName = Convert.ToChar(ascii + 5);
            }
        }
    }
}
