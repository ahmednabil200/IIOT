using System;
using System.Collections.Generic;
using System.Linq;
using IiotApplication.Repositories;
using IiotContract.Requests;
using IiotDomain;
using IiotInfrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IiotInfrastructure.Reposatories
{
    public class ReadingService : IReadingService
    {
        private readonly AppSettings _appSettings;

        public ReadingService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Reading> GetReadingByDevice(int id,int? timeStampStart,int? timeStampEnd)
        {
            using (var context = new IiotContext())
            {
                IEnumerable<Reading> readings  = context.Readings.Include(r => r.Device)
                    .Where(r => r.DeviceID == id)
                    .ToList();
                if (timeStampStart.HasValue)
                    readings = readings.Where(x => x.TimeStamp >= timeStampStart.Value).ToList();
                if (timeStampEnd.HasValue)
                    readings = readings.Where(x => x.TimeStamp >= timeStampEnd.Value);
                return readings;

            }
        }

        public Reading InsertReading(Reading_Request reading_request)
        {

            var reading = new Reading
            {
                TimeStamp = reading_request.TimeStamp,
                Type = reading_request.Type,
                RawValue = reading_request.RawValue,
                DeviceID = reading_request.DeviceID
            };

            using (var context = new IiotContext())
            {
                context.Readings.Add(reading);
                context.SaveChanges();
            }
            return reading;
        }
    }
}
