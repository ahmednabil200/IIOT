using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IiotDomain
{
    public class Reading
    {
        public int ID { get; set; }
        public int TimeStamp { get;  set; }
        [JsonIgnore]
        public virtual Device Device { get; set; }
        public string Type { get;  set; }
        public string RawValue { get; set; }
        [JsonIgnore]
        public int DeviceID { get; set; }
    }
}