using CsvHelper;
using Dapper;
using ETLProjectAPI.Infrastructure.Database;
using ETLProjectAPI.Services.Data;
using ETLProjectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Globalization;

namespace ETLProjectAPI.Services.Realisation
{
    public class QueryService : IQueryService
    {
        private readonly DataContext _context;
        public QueryService(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HighestTipLocation>> GetHighestTipLocation()
        {
            using var connection = _context.CreateConnection();
            var items =  await connection.QueryAsync<HighestTipLocation>(StoredProcedures.GetHighestTipLocation, commandType: CommandType.StoredProcedure);
            return items;
        }
        public async Task<IEnumerable<TaxiTripDTO>> GetTop100LongestFares()
        {
            using var connection = _context.CreateConnection();
            var items =  await connection.QueryAsync<TaxiTripDTO>(StoredProcedures.GetTop100LongestFares, commandType: CommandType.StoredProcedure);
            return items;
        }
        public async Task<IEnumerable<TaxiTripDTO>> GetTop100LongestTime()
        {
            using var connection = _context.CreateConnection();
            var items =  await connection.QueryAsync<TaxiTripDTO>(StoredProcedures.GetTop100LongestTime, commandType: CommandType.StoredProcedure);
            return items;
        }
        public async Task<IEnumerable<TaxiTripDTO>> SearchByPULocationId(int pULocationId)
        {
            var parameters = new { PULocationId = pULocationId };
            using var connection = _context.CreateConnection();
            var items =  await connection.QueryAsync<TaxiTripDTO>(StoredProcedures.SearchByPULocationId, parameters, commandType: CommandType.StoredProcedure);
            return items;
        }
      
    }
}
