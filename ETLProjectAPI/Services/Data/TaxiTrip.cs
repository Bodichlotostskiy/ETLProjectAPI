﻿namespace ETLProjectAPI.Services.Data
{
    public class TaxiTrip
    {
        public int? VendorID { get; set; }
        public DateTime tpep_pickup_datetime { get; set; }
        public DateTime tpep_dropoff_datetime { get; set; }
        public int? passenger_count { get; set; }
        public double trip_distance { get; set; }
        public int? RatecodeID { get; set; }
        public string? store_and_fwd_flag { get; set; }
        public int PULocationID { get; set; }
        public int DOLocationID { get; set; }
        public string? payment_type { get; set; }
        public double fare_amount { get; set; }
        public double tip_amount { get; set; }
        public double extra { get; set; }
        public double mta_tax { get; set; }
        public double tolls_amount { get; set; }
        public double improvement_surcharge { get; set; }
        public double total_amount { get; set; }
        public double congestion_surcharge { get; set; }
    }
}
