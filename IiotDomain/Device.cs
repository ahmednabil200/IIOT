using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IiotDomain
{
    public class Device
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [JsonIgnore]
        public virtual ICollection<Reading> Readings { get; set; }
    }
}