using System;
using System.Collections.Generic;
using IiotApi.Helpers;
using IiotApi.Models;
using Microsoft.Extensions.Options;

namespace IiotApi.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly AppSettings _appSettings;

        public DeviceService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Device> GetAll()
        {
            using (var context = new IiotContext())
            {
                IEnumerable<Device> devices = context.Devices;
                return devices;
            }
        }

        Device IDeviceService.GetDevice(int id)
        {
            using (var context = new IiotContext())
            {
                return context.Devices.Find(id);
            }
        }


        public Device AddDevice(Device_Request requested_device)
        {
            /*
             * Any validation
             */

            var device = new Device
            {
                Name = requested_device.Name,
                Location = requested_device.Location
            };

            using (var context = new IiotContext())
            {
                context.Devices.Add(device);
                context.SaveChanges();
            }
            return device;
        }

        public Device UpdateDevice(int id,Device device)
        {
            using (var context = new IiotContext())
            {
                Device existingDevice = context.Devices.Find(id);
                if(existingDevice != null)
                {
                    existingDevice.Location = device.Location;
                    existingDevice.Name = device.Name;
                    context.Devices.Update(existingDevice);
                    context.SaveChanges();
                }
                else
                    throw new ArgumentOutOfRangeException("Device id is wrong");
            }
            return device;
        }

        public bool DeleteDevice(int id)
        {
            using (var context = new IiotContext())
            {
                Device device = context.Devices.Find(id);
                if (device != null)
                {
                    context.Devices.Remove(device);
                    context.SaveChanges();
                }
                else
                    throw new ArgumentOutOfRangeException("Device id is wrong");
            }
            return false;
        }
    }
}
