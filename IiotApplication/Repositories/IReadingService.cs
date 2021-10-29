using System;
using System.Collections.Generic;
using IiotContract.Requests;
using IiotDomain;

namespace IiotApplication.Repositories
{
    public interface IReadingService
    {
        IEnumerable<Reading> GetReadingByDevice(int id, int? timeStampStart, int? timeStampEnd);
        Reading InsertReading(Reading_Request reading);
    }
}
