using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IiotContract.Requests
{
    public class Device_Request
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}