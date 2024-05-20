using ETLProjectAPI.Services.Data;

namespace ETLProjectAPI.Infrastructure.Mappers
{
    public class TaxiTripMapper
    {
        public static List<TaxiTripDTO> MapToDTO(List<TaxiTrip> trips)
        {
            var dtos = new List<TaxiTripDTO>();
            foreach (var trip in trips)
            {
                Infrastructure.Extensions.StringExtension.TrimStrings(trip);
               
                dtos.Add(new TaxiTripDTO
                {
                    tpep_pickup_datetime = TimeZoneInfo.ConvertTimeToUtc(trip.tpep_pickup_datetime, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")),
                    tpep_dropoff_datetime = TimeZoneInfo.ConvertTimeToUtc(trip.tpep_dropoff_datetime, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")),
                    passenger_count = trip.passenger_count,
                    trip_distance = trip.trip_distance,
                    store_and_fwd_flag = trip.store_and_fwd_flag switch
                    {
                        "N" => "NO",
                        "Y" => "YES",
                        _ => trip.store_and_fwd_flag
                    },
                    PULocationID = trip.PULocationID,
                    DOLocationID = trip.DOLocationID,
                    fare_amount = trip.fare_amount,
                    tip_amount = trip.tip_amount
                });
            }
            return dtos;
        }  
    }
}
