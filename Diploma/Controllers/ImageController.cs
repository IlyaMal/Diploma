using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using Diploma.BLL;
using Diploma.QueryMappers;
using Diploma.QueryModels;
using OfficeOpenXml;

[Route("/image/")]
[ApiController]
public class ImageController : Controller
{
    public readonly IDiplomaBLL _DiplomaBll;


    public ImageController(IDiplomaBLL diplomaBll)
    {
        _DiplomaBll = diplomaBll;
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadExcel(IFormFile file)
    {
        if (file == null || file.Length <= 0)
        {
            return BadRequest("Invalid file");
        }

        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);
            using (var package = new ExcelPackage(stream))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                
                for (int row = 1; row <= rowCount; row++) 
                {
                    QueryTeacherModel model = new QueryTeacherModel()
                    {
                        Name = worksheet.Cells[row, 2].Value?.ToString(),
                        Place = worksheet.Cells[row, 1].Value?.ToString(),
                        Organisation = worksheet.Cells[row, 4].Value?.ToString(),
                        Nomination= worksheet.Cells[row, 5].Value?.ToString(),
                        Position= worksheet.Cells[row, 3].Value?.ToString(),
                        
                    };
                    await _DiplomaBll.AddTeacherAsync(QueryMapper.MapExcelToTeacher(model));
                    
                }
                
            }
            using (var package = new ExcelPackage(stream))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                
                for (int row = 1; row <= rowCount; row++)
                {
                    QueryStudentModel model = new QueryStudentModel()
                    {
                        Name = worksheet.Cells[row, 2].Value?.ToString(),
                        Place = worksheet.Cells[row, 1].Value?.ToString(),
                        Organisation = worksheet.Cells[row, 3].Value?.ToString(),
                        Nomination= worksheet.Cells[row, 4].Value?.ToString(),
                        
                    };
                    await _DiplomaBll.AddStudentAsync(QueryMapper.MapExcelToStudent(model));

                   
                }
                
            }
            
        }

        return Ok("File uploaded successfully");
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}

    
