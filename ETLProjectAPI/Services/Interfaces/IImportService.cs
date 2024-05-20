using ETLProjectAPI.Services.Data;

namespace ETLProjectAPI.Services.Interfaces
{
    public interface IImportService
    {
        Task SaveDataFromCSV();
    }
}
