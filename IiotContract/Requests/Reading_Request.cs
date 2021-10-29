using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IiotContract.Requests
{
    public class Reading_Request
    {
        public int ID { get;  set; }
        public int TimeStamp { get;  set; }
        public string Type { get;  set; }
        public string RawValue { get; set; }
        public int DeviceID { get; set; }
    }
}