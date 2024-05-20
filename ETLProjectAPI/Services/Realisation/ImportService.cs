using CsvHelper;
using Dapper;
using ETLProjectAPI.Infrastructure.Database;
using ETLProjectAPI.Infrastructure.Mappers;
using ETLProjectAPI.Services.Data;
using ETLProjectAPI.Services.Interfaces;
using Microsoft.OpenApi.Extensions;
using System.Data;
using System.Globalization;

namespace ETLProjectAPI.Services.Realisation
{
    public class ImportService : IImportService
    {
        private readonly DataContext _context;
        public ImportService(DataContext context)
        {
            _context = context;
        }
        public async Task SaveDataFromCSV(string file)
        {

            var duplicates = new List<TaxiTrip>();
            var records = new List<TaxiTrip>();
            using (var reader = new StreamReader("sample-cab-data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                try
                {
                    records =  csv.GetRecords<TaxiTrip>().ToList();
                }
                catch(Exception ex) 
                {
                    throw new Exception("file has error format", ex);
                }
                var distinctRecords = records
                   .GroupBy(r => new { r.tpep_pickup_datetime, r.tpep_dropoff_datetime, r.passenger_count })
                   .Select(g => g.First())
                   .ToList();

                duplicates.AddRange(records.Except(distinctRecords));
                
                using (var writer = new StreamWriter("duplicates.csv"))
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(duplicates);
                }
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(StoredProcedures.InsertTaxiTrip, TaxiTripMapper.MapToDTO(records), commandType: CommandType.StoredProcedure);
                }
            }
        }
    }
}
