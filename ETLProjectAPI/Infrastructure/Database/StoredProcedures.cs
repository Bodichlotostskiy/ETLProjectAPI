namespace ETLProjectAPI.Infrastructure.Database
{
    public static class StoredProcedures
    {
        public const string GetHighestTipLocation = "GetHighestTipLocation";
        public const string GetTop100LongestFares = "GetTop100LongestFares";
        public const string GetTop100LongestTime = "GetTop100LongestTime";
        public const string SearchByPULocationId = "SearchByPULocationId";
        public const string InsertTaxiTrip = "InsertTaxiTrip";
    }
}
