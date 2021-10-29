using System;
using System.Collections.Generic;
using IiotContract.Requests;
using IiotDomain;

namespace IiotApplication.Repositories
{
    public interface IDeviceService
    {
        IEnumerable<Device> GetAll();

        Device GetDevice(int id);

        Device AddDevice(Device_Request device);

        Device UpdateDevice(int id, Device device);

        bool DeleteDevice(int id);
    }
}
