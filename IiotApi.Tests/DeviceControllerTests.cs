using System;
using System.Collections.Generic;
using System.Linq;
using IiotApi.Controllers;
using IiotApi.Models;
using IiotApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IiotApi.Tests
{
    public class DeviceControllerTests
    {
        [Fact]
        public void TestGetAll ()
        {
            var mocService = new Mock<IDeviceService>();
            mocService.Setup(service => service.GetAll())
                .Returns(GetDevices());


            var controller = new DeviceController(mocService.Object);

            var result = controller.GetAll();

            Assert.Equal(2, ((IEnumerable<Device>)(((OkObjectResult)result.Result).Value)).Count());

        }

        [Fact]
        public void TestGetByID()
        {
            var mocService = new Mock<IDeviceService>();
            int testID = 1;
            mocService.Setup(service => service.GetDevice(1))
                .Returns(new Device() { ID = testID });


            var controller = new DeviceController(mocService.Object);

            var result = controller.GetDevice(testID);

            Assert.Equal(testID, ((Device)(((OkObjectResult)result.Result).Value)).ID);

        }



        private IEnumerable<Device> GetDevices()
        {
            return new List<Device>() {
                new Device() { Name = "",Location = ""},
                new Device() { Name = "",Location = ""}
            };
        }
    }
}
