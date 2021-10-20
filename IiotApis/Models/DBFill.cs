using System;
using IiotApi.Helpers;
using Microsoft.Extensions.Options;

namespace IiotApi.Models
{
    public class DBFill
    {
        
        public void InsertData()
        {

            using (var context = new IiotContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();
                var device1  = new Device
                {
                    Name = "gas tank bp",
                    Location = "porto"
                };
                var device2 = new Device
                {
                    Name = "fuel tank alameda",
                    Location = "gaia"
                };
                context.Devices.Add(device1);

                context.Devices.Add(device2);

                context.Readings.Add(new Reading
                {
                    TimeStamp = 1601456548,
                    Type = "battery",
                    Device = device1,
                    RawValue = "80"
                });
                context.Readings.Add(new Reading
                {
                    TimeStamp = 1601456606,
                    Type = "tank_level",
                    Device = device1,
                    RawValue = "80"
                });
                context.Readings.Add(new Reading
                {
                    TimeStamp = 1601456548,
                    Type = "battery",
                    Device = device1,
                    RawValue = "82"
                });
                context.Readings.Add(new Reading
                {
                    TimeStamp = 1601456606,
                    Type = "tank_level",
                    Device = device2,
                    RawValue = "84"
                });

                context.SaveChanges();
            }
        }

    }
}
