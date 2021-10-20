using System;
using System.Collections.Generic;
using IiotApi.Models;

namespace IiotApi.Services
{
    public interface IReadingService
    {
        IEnumerable<Reading> GetReadingByDevice(int id, int? timeStampStart, int? timeStampEnd);
        Reading InsertReading(Reading_Request reading);
    }
}
