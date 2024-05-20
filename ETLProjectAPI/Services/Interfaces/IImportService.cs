using ETLProjectAPI.Services.Data;

namespace ETLProjectAPI.Services.Interfaces
{
    public interface IImportService
    {
        //Task<IEnumerable<TaxiTrip>>
        Task SaveDataFromCSV(string file);
    }
}
