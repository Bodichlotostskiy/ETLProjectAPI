﻿using CsvHelper;
using ETLProjectAPI.Infrastructure.Database;
using ETLProjectAPI.Services.Data;
using ETLProjectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;

namespace ETLProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportController : ControllerBase
    {
        private readonly IImportService _importService;

        public ImportController(IImportService importService)
        {
            _importService = importService;
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportData()
        {
            await _importService.SaveDataFromCSV();

            return Ok("Data imported successfully.");
        }
    }
}
