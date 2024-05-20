using ETLProjectAPI.Services.Data;

namespace ETLProjectAPI.Services.Interfaces
{
    public interface IQueryService
    {
        Task<IEnumerable<HighestTipLocation>> GetHighestTipLocation();
        Task<IEnumerable<TaxiTripDTO>> GetTop100LongestFares();
        Task<IEnumerable<TaxiTripDTO>> GetTop100LongestTime();
        Task<IEnumerable<TaxiTripDTO>> SearchByPULocationId(int pULocationId);
    }
}
