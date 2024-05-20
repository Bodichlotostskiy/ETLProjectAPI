using System.Runtime.Serialization;

namespace ETLProjectAPI.Services.Data
{
    [DataContract]
    public class HighestTipLocation
    {
        [DataMember(Name = "PULocationID")]
        public int PULocationID { get; set; }
        [DataMember(Name = "AvgTip")]
        public double AvgTip { get; set; }
    }
}
